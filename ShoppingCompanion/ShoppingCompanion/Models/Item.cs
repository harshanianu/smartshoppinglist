using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCompanion.Models
{
    public class Item
    {
         [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual  ICollection<Category> Categories { get; set; }
    }
}