using System.ComponentModel.DataAnnotations;

namespace PetCafeCustomerWebApp.Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; } 
        public string? Name { get; set; }    

        public string? Gender { get; set; }

        public VisitTime? VisitTime { get; set; }

        public ICollection<Dog> Dogs { get; set; }

        public ICollection<Sharing> Sharings { get; set; }
    }
}
