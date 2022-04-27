using System;

namespace DTO
{
    public class ImportHistoryDTOUpdate
    {
        public int Id { get; set; }
        public DateTime ImportDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Supplier { get; set; }
        public int LineRequest { get; set; }
        public string Buyer { get; set; }
        public string Po { get; set; }
        public bool Allocated { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
//Allocated: true
//​​
//Buyer: "Nguyen van A"
//​​
//LineRequest: 64
//​​
//Po: "456546546"
//​​
//id: 3329
//​​
//price: 3987
//​​
//remark: "                       aaaa                           "
//​​
//supplier: "GUILD                              