namespace Domain.Dtos.Contact
{
    public class ContactDto
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? Phone { get; set; }
        public bool? IsReading { get; set; }
    }
}
