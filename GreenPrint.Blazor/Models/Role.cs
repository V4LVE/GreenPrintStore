namespace GreenPrint.Blazor.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Navigation Properties
        public List<User> Users { get; set; }
    }
}
