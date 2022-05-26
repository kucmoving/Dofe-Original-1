using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Interfaces;
using PetCafeCustomerWebApp.Models;
using PetCafeCustomerWebApp.ViewModel;

namespace PetCafeCustomerWebApp.Controllers
{
    public class SharingController : Controller
    {
        private readonly ISharingRepository _sharingRepository;
        private readonly IPhotoService _photoService;

        public SharingController(ISharingRepository sharingRepository, IPhotoService photoService)
        {
            _sharingRepository = sharingRepository;
            _photoService = photoService;
        }

        //will go into applicationDbContext

        public async Task<IActionResult> Index()
        {
            IEnumerable<Sharing> sharings = await _sharingRepository.GetAll();
            //Sharings the name of icollection of dog in customers
            //tolist = to make table to be a list
            return View(sharings);
        }
        public async Task<IActionResult> Detail(int id) //input id
        {
            Sharing sharing = await _sharingRepository.GetByIdAsync(id); //from table to one query
            return View(sharing);
        }
        public IActionResult Create()   //can do it as async
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateSharingViewModel sharingVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(sharingVM.Image);
                var sharing = new Sharing
                {
                    SharingName = sharingVM.SharingName,
                    Introduction = sharingVM.Introduction,
                    Image = result.Url.ToString(),
                    VisitTime = new VisitTime
                    {
                        Day = sharingVM.VisitTime.Day,
                        TimeFrame = sharingVM.VisitTime.TimeFrame

                    }
                };
                _sharingRepository.Add(sharing);
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(sharingVM);
        }

        public async Task<IActionResult> Edit(int id) //to copy message as a form data
        {
            var sharing = await _sharingRepository.GetByIdAsync(id);
            if (sharing == null) return View("Error");
            var sharingVM = new EditSharingViewModel
            {
                SharingName = sharing.SharingName,
                Introduction = sharing.Introduction,
                VisitTimeId = sharing.VisitTimeId,
                VisitTime = sharing.VisitTime,
                URL = sharing.Image,
                SharingCategory = sharing.SharingCategory
            };
            return View(sharingVM);
        }

        [HttpPost] //to update
        public async Task<IActionResult> Edit(int id, EditSharingViewModel sharingVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "Failed to edit club");
                return View("Edit", sharingVM);
            }

            var customerSharing = await _sharingRepository.GetByIdAsyncNoTracking(id);
            if (customerSharing != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(customerSharing.Image);
                }
                catch (Exception)

                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(sharingVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(sharingVM.Image);
                var sharing = new Sharing
                {
                    Id = id,
                    SharingName = sharingVM.SharingName,
                    Introduction = sharingVM.Introduction,
                    Image = photoResult.Url.ToString(),
                    VisitTimeId = sharingVM.VisitTimeId,
                    VisitTime = sharingVM.VisitTime,
                };

                _sharingRepository.Update(sharing);

                return RedirectToAction("index");
            }
            else
            {
                return View(sharingVM);
            }
        }

    }
}
