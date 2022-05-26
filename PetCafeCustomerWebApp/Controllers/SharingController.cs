using Microsoft.AspNetCore.Mvc;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Models;
namespace PetCafeCustomerWebApp.Controllers
{
    public class SharingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SharingController(ApplicationDbContext context)
        {
            _context = context;
        }
        //will go into applicationDbContext

        public IActionResult Index()
        {
            List<Sharing> sharings = _context.Sharings.ToList();
            //Dogs the name of icollection of dog in customers
            //tolist = to make table to be a list
            return View(sharings);
        }
    }
}