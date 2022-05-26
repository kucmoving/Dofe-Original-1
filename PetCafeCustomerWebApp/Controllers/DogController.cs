using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Controllers
{
    public class DogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogController(ApplicationDbContext context)
        {
            _context = context;
        }
        //will go into applicationDbContext

        public IActionResult Index()
        {
            List<Dog> dogs = _context.Dogs.ToList();
            //Dogs the name of icollection of dog in customers
            //tolist = to make table to be a list
            return View(dogs);
        }

        public IActionResult Detail(int id) //input id
        {
            Dog dog = _context.Dogs.Include(a => a.VisitTime).FirstOrDefault(c => c.Id == id); //from table to one query
            return View(dog);
        }
    }
}
