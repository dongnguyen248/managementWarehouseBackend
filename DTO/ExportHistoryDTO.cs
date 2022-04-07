using System;

namespace DTO
{
    public class ExportHistoryDTO
    {
        public int Id { get; set; }
        public int Material { get; set; }
        public DateTime ExportDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Receiver { get; set; }
        public string Requestor { get; set; }
        public int Handler { get; set; }
        public int Department { get; set; }
        public string Remark { get; set; }
        public int costAccount { get; set; }
        public int costAccountItem { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual EmployeeDTO HandlerNavigation { get; set; }
        public virtual MaterialDTO MaterialNavigation { get; set; }
        public virtual LineDTO ReceiverNavigation { get; set; }
        public virtual DepartmentDTO DepartmentNavigation { get; set; }
        public virtual CostAccountDTO CostAccountNavigation { get; set; }
        public virtual CostAccountItemDTO CostAccountItemNavigation { get; set; }

    }
}