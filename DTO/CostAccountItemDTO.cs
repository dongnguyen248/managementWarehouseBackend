namespace DTO
{
    public class CostAccountItemDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int CostAccount { get; set; }

        public virtual CostAccountDTO CostAccountNavigation { get; set; }
    }
}