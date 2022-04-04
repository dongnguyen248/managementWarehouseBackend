using System;

namespace DTO
{
    public class InspectionDTO
    {
        public int ImportId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Inspector { get; set; }
        public bool? Result { get; set; }

        public virtual ImportHistoryDTO Import { get; set; }
    }
}