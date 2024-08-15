using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "Ürün Id")]
        public int ProductId { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Fiyat")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Resim")]
        [Required]
        public string? Image { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Display(Name = "Kategori Id")]
        public int CategoryId { get; set; }
    }
}