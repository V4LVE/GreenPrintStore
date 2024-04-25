namespace GreenPrint.Blazor.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Guid SessionToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }

        //navigation property
        public User User { get; set; }
    }
}
