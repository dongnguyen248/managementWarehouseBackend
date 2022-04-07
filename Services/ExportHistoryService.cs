using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExportHistoryService : IExportService
    {
        private readonly IRepository<ExportHistory> _exportRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ExportHistoryService(IRepository<ExportHistory> exportRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _exportRepository = exportRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Add(ExportHistoryDTO exportHistory)
        {
            _exportRepository.Add(_mapper.Map<ExportHistory>(exportHistory));
            _unitOfWork.Commit();
        }

        public IEnumerable<ExportHistoryDTO> GetAll(int page, int pageSize, out int totalRow)
        {
            IQueryable<ExportHistory> exportHistories = _exportRepository.FindAll(x => x.MaterialNavigation, x => x.HandlerNavigation, x => x.ReceiverNavigation, x => x.DepartmentNavigation);
            totalRow = exportHistories.Count();
            IEnumerable<ExportHistory> result = exportHistories.OrderByDescending(x=>x.CreatedDate).Skip(pageSize * (page - 1)).Take(pageSize).AsEnumerable();
            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(result);
            
        }

        public IEnumerable<ExportHistoryDTO> Search(DateTime dateFrom, DateTime dateTo, string Qcode, string PO, string Line, string Supplier, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public void UpdateExmportHistory(ExportHistoryDTO exportHistory, string qCode, string remark)
        {
            throw new NotImplementedException();
        }
    }
}
