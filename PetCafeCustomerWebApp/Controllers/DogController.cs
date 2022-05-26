using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Interfaces;
using PetCafeCustomerWebApp.Models;
using PetCafeCustomerWebApp.ViewModel;

namespace PetCafeCustomerWebApp.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepository;
        private readonly IPhotoService _photoService;

        public DogController(IDogRepository dogRepository, IPhotoService photoService)
        {
            _dogRepository = dogRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateDogViewModel dogVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(dogVM.Image);
                var dog = new Dog
                {
                    DogName = dogVM.DogName,
                    Introduction = dogVM.Introduction,
                    Image = result.Url.ToString(),
                    VisitTime = new VisitTime
                    {
                        Day = dogVM.VisitTime.Day,
                        TimeFrame = dogVM.VisitTime.TimeFrame

                    }
                };
                _dogRepository.Add(dog);
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(dogVM);
        }
    }
}
