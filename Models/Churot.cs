using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace Daily_Sales.Models
{
    public enum ChurotPacket
    {
        Surya = 1,
        ShikharIce = 2,
        Captain = 3,
        Pilot = 4,
        Camel = 5,
        CamelBrust = 6,
        Others = 7

    }
    public class Churot
    {
        public int ChurotId { get; set; }

        public ChurotPacket Brand { get; set; }




        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public string Remarks { get; set; }
        public int Quantity { get; set; }


    }
}

