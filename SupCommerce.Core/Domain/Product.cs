namespace SupCommerce.Core.Domain
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public int? CategoryId { get; set; }
    }
}