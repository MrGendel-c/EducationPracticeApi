using System.ComponentModel.DataAnnotations;

namespace EducationPractice.dtos
{
    public class ProductCreate
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Maker { get; set; }
        public string Supplier { get; set; } = string.Empty;
    }
}
