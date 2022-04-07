using System;

#nullable disable

namespace Data
{
    public partial class ImportHistory
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
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employee HandlerNavigation { get; set; }
        public virtual Line LineRequestNavigation { get; set; }
        public virtual Material MaterialNavigation { get; set; }
        public virtual Inspection InspectionNavigation { get; set; }
    }
}