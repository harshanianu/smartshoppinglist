using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCompanion.Models
{
    public class ParentStore
    {
        [Key]
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}