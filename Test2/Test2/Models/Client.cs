using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
    }
}