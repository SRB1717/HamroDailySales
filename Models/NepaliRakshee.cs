using System.ComponentModel.DataAnnotations;

namespace Daily_Sales.Models
{
    public enum RakhseeBrand
    {
        GoldenOak = 1, BlueDiamond = 2, Mustang = 3, Highlander = 4, khukri = 5,
        KhukriSpice = 6, OD = 7, BlackChimney = 8, Signature = 9, Nude = 10,
        Yeti = 11, RedBlack = 12, KalaPathar = 13, GurkhasAndGuns = 14,
        EightEightFourEight = 15, Ruslan = 16, Others = 17
    }

    public enum RakhseeQuantity
    {
        Quarter = 1, Half = 2, Full = 3, Ml90 = 4
    }

    public class NepaliRakshi
    {
        public int Rakhsi { get; set; }

        [Required(ErrorMessage = "Nepali Rakshi brand is required.")]
        public RakhseeBrand Brand { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public RakhseeQuantity Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public string Remarks { get; set; }
    }
}