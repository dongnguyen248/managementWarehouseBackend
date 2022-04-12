using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExportHistoryService : IExportService
    {
        private readonly IRepository<ExportHistory> _exportRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ImportHistory> _importtRepository;
        public ExportHistoryService(IRepository<ExportHistory> exportRepository, IMapper mapper,IUnitOfWork unitOfWork , IRepository<ImportHistory> importtRepository)
        {
            _exportRepository = exportRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _importtRepository = importtRepository;
        }
        public void Add(ExportHistoryDTO exportHistory)
        {
            _exportRepository.Add(_mapper.Map<ExportHistory>(exportHistory));
            _unitOfWork.Commit();
        }
        public IEnumerable<ExportHistoryDTO> GetReportExcel(DateTime formDate,DateTime toDate)
        {
            Expression<Func<ExportHistory, bool>> predicateExport = x => (x.ExportDate >= formDate && x.ExportDate <= toDate.AddDays(1));
            IEnumerable <ExportHistory> resultExport = _exportRepository.FindAll(predicateExport, x=>x.ReceiverNavigation,x=>x.CostAccountNavigation,x=>x.CostAccountItemNavigation,x=>x.MaterialNavigation,x=>x.MaterialNavigation.ZoneNavigation, x => x.MaterialNavigation.UnitNavigation,x=>x.MaterialNavigation.ExportHistories);
            Expression<Func<ImportHistory, bool>> predicateImport = x => (x.ImportDate >= formDate && x.ImportDate <= toDate.AddDays(1));
            IEnumerable<ImportHistory> resultImport = _importtRepository.FindAll(predicateImport);
            Expression<Func<ExportHistory, bool>> predicateTotalInADay = x => (x.ExportDate == formDate);
            int diff1 =(toDate.AddDays(1) - formDate).Days;

            for (int i = 0; i < diff1; i++)
            {
                var exps = resultExport.Where(x=>x.ExportDate==formDate.AddDays(i));
                var imps = resultImport.Where(x=>x.ImportDate == formDate.AddDays(i));
                var totalQcodeExp = exps.GroupBy(x => x.MaterialNavigation.Qcode).ToList();
                var totalQcodeImp = imps.GroupBy(x=>x.MaterialNavigation.Qcode).ToList();
                foreach(var imp in totalQcodeImp)
                {
                    var sumqtim = imp.Sum(x=>x.Quantity);
                }

                foreach(var tt in totalQcodeExp)
                {
                    var sumqtex = tt.Sum(x => x.Quantity);
                    
                }

            }


            return _mapper.Map<IEnumerable<ExportHistoryDTO>>(resultExport);
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
            throw new NotImplementedException();
        }

        public void UpdateExmportHistory(ExportHistoryDTO exportHistory, string qCode, string remark)
        {
            throw new NotImplementedException();
        }
    }
}
