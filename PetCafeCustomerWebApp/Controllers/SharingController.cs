using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Interfaces;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Controllers
{
    public class SharingController : Controller
    {
        private readonly ISharingRepository _sharingRepository;

        public SharingController(ISharingRepository sharingRepository)
        {
            _sharingRepository = sharingRepository;
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
    }
}
