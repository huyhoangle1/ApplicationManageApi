namespace WebApplicationManage.models.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }
        public DateTime? Created { get; set;}
    }
}
