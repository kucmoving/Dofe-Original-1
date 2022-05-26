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
        public async Task<IActionResult> Edit(int id) //to copy message as a form data
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return View("Error");
            var dogVM = new EditDogViewModel
            {
                DogName = dog.DogName,
                Introduction = dog.Introduction,
                VisitTimeId = dog.VisitTimeId,
                VisitTime = dog.VisitTime,
                URL = dog.Image,
                DogCategory = dog.DogCategory
            };
            return View(dogVM);
        }

        [HttpPost] //to update
        public async Task<IActionResult> Edit(int id, EditDogViewModel dogVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "Failed to edit club");
                return View("Edit", dogVM);
            }
                
            var customerDog = await _dogRepository.GetByIdAsyncNoTracking(id);
            if (customerDog != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(customerDog.Image);
                }
                catch (Exception)

                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(dogVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(dogVM.Image);
                var dog = new Dog
                {
                    Id = id,
                    DogName = dogVM.DogName,
                    Introduction = dogVM.Introduction,
                    Image = photoResult.Url.ToString(),
                    VisitTimeId = dogVM.VisitTimeId,
                    VisitTime = dogVM.VisitTime,
                };
             
            _dogRepository.Update(dog);

            return RedirectToAction("index");
            }
            else
            {
                return View(dogVM);
            }
        }

    }
}
