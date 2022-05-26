using PetCafeCustomerWebApp.Data.Enum;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.ViewModel
{
    public class EditSharingViewModel
    {
        public int Id { get; set; }
        public string SharingName { get; set; }
        public string Introduction { get; set; }

        public IFormFile Image { get; set; }   

        public string? URL { get; set; }

        public int VisitTimeId { get; set; }    
        public VisitTime VisitTime { get; set; }

        public SharingCategory SharingCategory { get; set; }

    }
}
