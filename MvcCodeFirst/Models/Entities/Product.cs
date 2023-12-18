namespace MvcCodeFirst.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int? UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
