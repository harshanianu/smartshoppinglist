using System.ComponentModel.DataAnnotations;

namespace ShoppingCompanion.Models
{
    public class Store
    {
         [Key]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public float Lattitude { get; set; }
        public float Longitute { get; set; }
        public string Address { get; set; }
        public bool IsOpened { get; set; }

        public int ParentStoreId { get; set; }
        public virtual ParentStore ParentStore { get; set; }

    }
}