using System;
using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class ClientOrder
    {
        [Key]
        public int IdClientOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        [MaxLength(300)]
        public string? Comments { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}