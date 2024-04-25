namespace GreenPrint.Blazor.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation Properties
        public List<Item> Items { get; set; }
    }
}
