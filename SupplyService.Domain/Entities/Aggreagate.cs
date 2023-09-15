namespace SupplyService.Domain.Entities
{
    public class Aggreagate<T> : Entity<T>
    {
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
