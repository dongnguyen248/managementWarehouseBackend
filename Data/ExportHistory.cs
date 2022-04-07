using System;

#nullable disable

namespace Data
{
    public partial class ExportHistory
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
        public DateTime CreatedDate { get; set; }
        public string Remark { get; set; }
        public virtual Employee HandlerNavigation { get; set; }
        public virtual Material MaterialNavigation { get; set; }
        public virtual Line ReceiverNavigation { get; set; }
        public virtual Department DepartmentNavigation { get; set; }
    }
}