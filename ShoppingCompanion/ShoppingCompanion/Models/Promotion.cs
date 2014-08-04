using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCompanion.Models
{
    public class Promotion
    {
         [Key]
        public int PromotionId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}