using PetCafeCustomerWebApp.Data.Enum;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.ViewModel
{
    public class CreateDogViewModel
    {
        public int Id { get; set; }    
        public string DogName { get; set; } 
        
        public string Introduction { get; set; } 
        
        public VisitTime VisitTime { get; set; }
        public IFormFile Image { get; set; }    
        public DogCategory DogCategory { get; set; }
    }
}
