using System;

namespace DTO
{
    public class ImportHistoryDTO
    {
        public int Id { get; set; }
        public int Material { get; set; }
        public DateTime ImportDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Supplier { get; set; }
        public int LineRequest { get; set; }
        public string Buyer { get; set; }
        public string Po { get; set; }
        public bool Allocated { get; set; }
        public int Handler { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual EmployeeDTO HandlerNavigation { get; set; }
        public virtual LineDTO LineRequestNavigation { get; set; }
        public virtual MaterialDTO MaterialNavigation { get; set; }
        public virtual InspectionDTO InspectionNavigation { get; set; }
    }
}