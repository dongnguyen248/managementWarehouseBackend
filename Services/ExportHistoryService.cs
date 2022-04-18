using AutoMapper;
using Data;
using DTO;
using OfficeOpenXml;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class ExportHistoryService : IExportService
    {
        private readonly IRepository<ExportHistory> _exportRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ExportHistoryService(IRepository<ExportHistory> exportRepository, IMapper mapper,IUnitOfWork unitOfWork )
        {
            _exportRepository = exportRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Add(ExportHistoryDTO exportHistory)
        {
            try
            {
                _exportRepository.Add(_mapper.Map<ExportHistory>(exportHistory));
                _unitOfWork.Commit();

            }catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
       
        public IEnumerable<ExportHistoryDTO> GetAll(int page, int pageSize, out int totalRow)
        {
            IQueryable<ExportHistory> exportHistories = _exportRepository.FindAll(x=>x.CostAccountNavigation,x=>x.CostAccountItemNavigation,x => x.MaterialNavigation,x=>x.MaterialNavigation.UnitNavigation,x=>x.MaterialNavigation.ZoneNavigation, x => x.HandlerNavigation, x => x.ReceiverNavigation, x => x.DepartmentNavigation);
            totalRow = exportHistories.Count();
            IEnumerable<ExportHistory> result = exportHistories.OrderByDescending(x=>x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(result);
            
        }
       
        public IEnumerable<ExportHistoryDTO> Search(DateTime dateFrom, DateTime dateTo, string Qcode, string PO, string Line, string Supplier, int page, int pageSize, out int totalRow)
        {
            Expression<Func<ExportHistory, bool>> predicate = x => x.MaterialNavigation.Qcode.Equals(Qcode) || x..Contains(PO) || x.LineRequestNavigation.Name.Contains(Line) || x.Supplier.Contains(Supplier) || (x.ImportDate >= dateFrom && x.ImportDate <= dateTo.AddDays(1));

            IQueryable<ExportHistory> exportHistories = _exportRepository.FindAll(predicate, x => x.InspectionNavigation, x => x.LineRequestNavigation, x => x.MaterialNavigation, x => x.HandlerNavigation);
            totalRow = exportHistories.Count();
            IEnumerable<ExportHistory> result = exportHistories.OrderByDescending(x => x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(result);
        }

        public void UpdateExportHistory(ExportHistoryDTO exportHistory)
        {
            try
            {
                _exportRepository.Update(_mapper.Map<ExportHistory>(exportHistory));
                _unitOfWork.Commit();
            }catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
