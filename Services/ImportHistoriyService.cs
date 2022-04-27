using AutoMapper;
using Data;
using DTO;

using Repositories.Interfaces;
using Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class ImportHistoriyService : IImportService
    {
        private readonly IRepository<ImportHistory> _importRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ImportHistoriyService(IRepository<ImportHistory> importRepository, IUnitOfWork unitOfWork,IMapper mapper, IRepository<Material> materialRepository)
        {
            _importRepository = importRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _materialRepository = materialRepository;

        }

        public void Add(ImportHistoryDTO importHistory)
        {
            try
            {
                _importRepository.Add(_mapper.Map<ImportHistory>(importHistory));

                _unitOfWork.Commit();

            }catch(Exception ex)
            {
                throw ;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var importHisDelete = _importRepository.FindById(id);
                _importRepository.Remove(_mapper.Map<ImportHistory>(importHisDelete));
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public IEnumerable<ImportHistoryDTO> GetAll(int page, int pageSize, out int totalRow)
        {
            IQueryable<ImportHistory> importHistories = _importRepository.FindAll(x => x.LineRequestNavigation,x=>x.MaterialNavigation.ZoneNavigation,m=>m.MaterialNavigation,h=>h.HandlerNavigation, i => i.InspectionNavigation);
            totalRow = importHistories.Count();
            IEnumerable<ImportHistory> result = importHistories.OrderByDescending(x => x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ImportHistoryDTO>>(result);
        }

       

        public IEnumerable<ImportHistoryDTO> Search(DateTime dateFrom, DateTime dateTo, string Qcode, string PO, string Line, string Supplier, int page, int pageSize, out int totalRow)
        {
            
            Expression<Func<ImportHistory, bool>> predicate = x => x.MaterialNavigation.Qcode.Equals(Qcode) || x.Po.Contains(PO) || x.LineRequestNavigation.Name.Contains(Line) || x.Supplier.Contains(Supplier) || (x.ImportDate >= dateFrom && x.ImportDate <= dateTo.AddDays(1));
            
            IQueryable<ImportHistory> importHistories = _importRepository.FindAll(predicate,x=>x.InspectionNavigation, x => x.LineRequestNavigation, x => x.MaterialNavigation, x => x.HandlerNavigation);
            totalRow = importHistories.Count();
            IEnumerable<ImportHistory> result = importHistories.OrderByDescending(x => x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ImportHistoryDTO>>(result);
        }

      
        public  void UpdateImportHistory(ImportHistoryDTO importHistory)
        {
            try
            {
                ImportHistory importUpdate =  _importRepository.FindSingle(x=>x.Id == importHistory.Id);
                if (importUpdate != null)
                {
                    importHistory.Material = importUpdate.Material;
                    _importRepository.Update(_mapper.Map<ImportHistory>(importHistory));
                }

               _unitOfWork.Commit();
            }catch (Exception ex)
            {

            }
            
          
        }
    }
}
