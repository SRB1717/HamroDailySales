using System;
using System.ComponentModel.DataAnnotations;

namespace Daily_Sales.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemType { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}