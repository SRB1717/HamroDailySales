using System.ComponentModel.DataAnnotations;

namespace Daily_Sales.Models
{
    // Enum for beer brands
    public enum BeerBrand
    {
        Gorkha = 1,
        Arna = 2,
        BarhaShinge = 3,
        Tuborg = 4,
        Carlsberg = 5,
        Iceberg = 6,
        NepalIce = 7,
        Others = 8
    }

    // Enum for quantities
    public enum BeerQuantity
    {
        ML650 = 1, // 650mL
        ML333 = 2, // 333mL
        CAN = 3    // CAN
    }

    public class Beer
    {
        public int BeerId { get; set; } // Maps to BeerId in the Beer table

        [Required(ErrorMessage = "Beer brand is required.")]
        public BeerBrand Brand { get; set; } // Dropdown for beer brands

        [Required(ErrorMessage = "Quantity is required.")]
        public BeerQuantity Quantity { get; set; } // Dropdown for quantities

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; } // Maps to Price in the Beer table

        // Optional: If you want to carry over the Name from the Sales model
        public string Remarks { get; set; }
    }
}