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
       public IEnumerable<ExportHistoryDTO> GetAllExpHis()
        {
            IEnumerable<ExportHistory> result = _exportRepository.FindAll(x=>x.CostAccountNavigation,x=>x.CostAccountNavigation,x=>x.MaterialNavigation,x =>x.ReceiverNavigation,x=>x.DepartmentNavigation,x=>x.CostAccountItemNavigation,x=>x.ReceiverNavigation);
            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(result);
        }
        public IEnumerable<ExportHistoryDTO> GetAll(int page, int pageSize, out int totalRow)
        {
            IQueryable<ExportHistory> exportHistories = _exportRepository.FindAll(x=>x.CostAccountNavigation,x=>x.CostAccountItemNavigation,x => x.MaterialNavigation,x=>x.MaterialNavigation.UnitNavigation,x=>x.MaterialNavigation.ZoneNavigation, x => x.HandlerNavigation, x => x.ReceiverNavigation, x => x.DepartmentNavigation);
            totalRow = exportHistories.Count();
            IEnumerable<ExportHistory> result = exportHistories.OrderByDescending(x=>x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(result);
            
        }
       
        public IEnumerable<ExportHistoryDTO> Search(DateTime dateFrom, DateTime dateTo, string Qcode, string item, string accountCost, string line, int page, int pageSize, out int totalRow)
        {
            Expression<Func<ExportHistory, bool>> predicate = x => x.MaterialNavigation.Qcode.Equals(Qcode) || (x.ExportDate >= dateFrom && x.ExportDate <= dateTo.AddDays(1));

            IQueryable<ExportHistory> exportHistories = _exportRepository.FindAll(predicate, x => x.CostAccountItemNavigation, x => x.CostAccountNavigation, x => x.MaterialNavigation, x => x.HandlerNavigation);
            totalRow = exportHistories.Count();
            IEnumerable<ExportHistory> result = exportHistories.OrderByDescending(x => x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(result);
        }

        public void UpdateExportHistory(ExportHistoryDTO exportHistory)
        {
            try
            {
                ExportHistory exportUpdate = _exportRepository.FindSingle(x => x.Id == exportHistory.Id);
                if(exportUpdate != null)
                {
                    exportHistory.Material = exportUpdate.Material;
                    _exportRepository.Update(_mapper.Map<ExportHistory>(exportHistory));
                    _unitOfWork.Commit();

                }
                else
                {
                    throw new InvalidOperationException("No have item. Please check again!");
                }
            }catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public void DeleteHistory(int id)
        {
            try
            {
                var exportHisDelete = _exportRepository.FindById(id);
                _exportRepository.Remove(_mapper.Map<ExportHistory>(exportHisDelete));
                _unitOfWork.Commit();
            }catch(Exception ex){
                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
