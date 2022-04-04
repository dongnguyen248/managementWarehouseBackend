using System;

#nullable disable

namespace Data
{
    public partial class Inspection
    {
        public int ImportId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Inspector { get; set; }
        public bool? Result { get; set; }

        public virtual ImportHistory Import { get; set; }
    }
}