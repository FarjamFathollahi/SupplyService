namespace SupplyService.Domain.Entities
{
    public class Aggreagate<T> : Entity<T>
    {
        public bool IsDeleted { get; set; }
    }
}
