using System.ComponentModel.DataAnnotations;

namespace Daily_Sales.Models
{

    public enum BideshiRakshiBrand
    {
        JD = 1,
        Jameson = 2,
        Absolute = 3,
        BlackLevel = 4,
        RedLevel = 5,
        DoubleBlackLevel = 6,
        GleanFedich = 7,
        Robertson = 8,
        Jackobs = 9,
        JPShenet = 10,
        Others = 11
    }
    public enum BidesiRaksiQuantity
    {
        ML1LTR = 1,
        ML750 = 2,

    }

    public class BidesiRakshi
    {
        public int BidesiRakhsi { get; set; } // Maps to BeerId in the Beer table

        [Required(ErrorMessage = "Beer brand is required.")]
        public BideshiRakshiBrand Brand { get; set; } // Dropdown for beer brands

        [Required(ErrorMessage = "Quantity is required.")]
        public BidesiRaksiQuantity Quantity { get; set; } // Dropdown for quantities

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; } // Maps to Price in the Beer table

        // Optional: If you want to carry over the Name from the Sales model
        public string Remarks { get; set; }
    }
}
