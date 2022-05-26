using PetCafeCustomerWebApp.Data.Enum;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.ViewModel
{
    public class CreateSharingViewModel
    {
        public int Id { get; set; }    
        public string SharingName { get; set; } 
        
        public string Introduction { get; set; }
        public VisitTime VisitTime { get; set; }

        public IFormFile Image { get; set; }    
        public SharingCategory SharingCategory { get; set; }
    }
}
