using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class ConfectioneryClientOrder
    {
        [Key]
        [ForeignKey("ClientOrder")]
        public int IdClientOrder { get; set; }
        
        [Key]
        [ForeignKey("Confectionery")]
        public int IdConfectionery { get; set; }
        
        public int Amount { get; set; }

        [MaxLength(300)]
        public string? Comments { get; set; }
        
        public ClientOrder ClientOrder { get; set; }
        public Confectionery Confectionery { get; set; }
    }
}