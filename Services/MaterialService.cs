using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Utilities;
using Utilities.LinqExtensions;

namespace Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<Material> _materialRepository;
        private readonly IImportService _importService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public MaterialService(IRepository<Material> materialRepository, IUnitOfWork unitOfWork, IMapper mapper, IImportService importService)
        {
            _materialRepository = materialRepository;
            _importService = importService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(MaterialDTO material)
        {
            try
            {
                Material m =_materialRepository.FindSingle(x => x.Qcode == material.Qcode.Trim());
                if (m == null)
                {
                   _materialRepository.Add(_mapper.Map<Material>(material));
                }
                else
                {
                    return;
                }
                _unitOfWork.Commit();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<MaterialDTO> GetAll(int page, int pageSize, out int totalRow)
        {
            IQueryable<Material> materials = _materialRepository.FindAll(x => x.ImportHistories, x => x.ExportHistories, x => x.ZoneNavigation, x => x.UnitNavigation);
            totalRow = materials.Count();
            IEnumerable<Material> result = materials.OrderByDescending(x => x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<MaterialDTO>>(result);
        }

        public IEnumerable<MaterialDTO> GetAll()
        {
            IEnumerable<Material> result = _materialRepository.FindAll();
            return _mapper.Map<IEnumerable<MaterialDTO>>(result);
        }

        public IEnumerable<MaterialDTO> Search(string qCode, string zone, string location, string item, string specification, int page, int pageSize, out int totalRow)
        {
            string[] specs = specification.SplitByChar('%');
            Expression<Func<Material, bool>> predicate = x => x.Qcode.Equals(qCode) || x.ZoneNavigation.Description.Contains(zone) || x.Location.Contains(location) || x.Item.Contains(item);
            for (int i = 0; i < specs.Length; i++)
            {
                string condition = specs[i];
                predicate = predicate.Or(x => x.Specification.Contains(condition));
            }
            IQueryable<Material> materials = _materialRepository.FindAll(predicate, x => x.ImportHistories, x => x.ExportHistories, x => x.ZoneNavigation, x => x.UnitNavigation);
            totalRow = materials.Count();
            IEnumerable<Material> result = materials.OrderByDescending(x => x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<MaterialDTO>>(result);
        }
    }
}