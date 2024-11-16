namespace Domain.Dtos.Contact
{
    public class CreateContact
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? Phone { get; set; }
    }
}
