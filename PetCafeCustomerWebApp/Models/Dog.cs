using PetCafeCustomerWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCafeCustomerWebApp.Models
{
    public class Dog
    {
        [Key]

        public int Id { get; set; }     
        
        public string DogName { get; set; }

        public string Introduction { get; set; }

        public string Image { get; set; }

        [ForeignKey("VisitTime")]
        public int VisitTimeId { get; set; }    

        public VisitTime VisitTime { get; set; }

        public DogCategory DogCategory { get; set; }

        [ForeignKey("Customer")]

        public string? CustomerId { get; set; }

        public Customer? Customer { get; set; }

    }
}
