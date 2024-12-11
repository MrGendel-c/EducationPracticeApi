namespace EducationPractice.models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Maker { get; set; }
        public string Supplier {get; set; } = string.Empty;
    }
}
