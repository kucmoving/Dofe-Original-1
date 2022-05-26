using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Detail(int id) //input id
        {
            Sharing sharing = _context.Sharings.Include(a => a.VisitTime).FirstOrDefault(c => c.Id == id); //from table to one query
            return View(sharing);
        }
    }
}
