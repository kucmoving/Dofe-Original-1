using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Interfaces;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepository;

        public DogController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        //will go into applicationDbContext

        public async Task<IActionResult> Index()
        {
            IEnumerable<Dog> dogs = await _dogRepository.GetAll();
            //Dogs the name of icollection of dog in customers
            //tolist = to make table to be a list
            return View(dogs);
        }

        public async Task<IActionResult> Detail(int id) //input id
        {
            Dog dog = await _dogRepository.GetByIdAsync(id); //from table to one query
            return View(dog);
        }
        public IActionResult Create()   //can do it as async
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return View(dog);
            }
            _dogRepository.Add(dog);
            return RedirectToAction("index");
        }
    }
}
