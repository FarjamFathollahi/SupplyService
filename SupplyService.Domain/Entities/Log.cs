namespace SupplyService.Domain.Entities
{
    public class Log : Entity<string>
    {
        public Log()
        {
            
        }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public string Data { get; set; }
        public string UserId { get; set; }
    }
}
