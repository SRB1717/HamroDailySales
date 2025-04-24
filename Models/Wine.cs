using System.ComponentModel.DataAnnotations;

namespace Daily_Sales.Models
{
    public enum WineBrand
    {
        BigMasterReg = 1,
        BigMasterPremium = 2,
        Divine = 3,
        Akira = 4,
        Submarine = 5,
        TheRisingRoyal = 6,
        Hinwa = 7,
        ManangValley = 8,
        TheKings = 9,
        others = 10
    }
    public enum WineQuantity
    {
        Full = 1,
        Half = 2
    }

    public class Wine
    {
        public int Wineid { get; set; } // Maps to BeerId in the Beer table

        [Required(ErrorMessage = "Beer brand is required.")]
        public WineBrand Brand { get; set; } // Dropdown for beer brands

        [Required(ErrorMessage = "Quantity is required.")]
        public WineQuantity Quantity { get; set; } // Dropdown for quantities

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; } // Maps to Price in the Beer table

        // Optional: If you want to carry over the Name from the Sales model
        public string Remarks { get; set; }
    }
}
