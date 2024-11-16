namespace Domain.Common
{
    public class BaseEntity 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
