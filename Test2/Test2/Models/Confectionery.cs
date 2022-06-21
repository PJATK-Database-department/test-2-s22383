using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class Confectionery
    {
        [Key]
        public int IdConfectionery { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public float PricePerOne { get; set; }
    }
}