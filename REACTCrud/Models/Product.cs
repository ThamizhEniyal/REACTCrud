using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REACTCrud.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Required]

        public int Price { get; set; }

        public DateTime EntryDate { get; set; }

        public Product()
            {
            EntryDate = DateTime.Now;
        }
    }

    public enum Category
    {
        None = 0,
        Electronics,
        Grocery,

    }
}
