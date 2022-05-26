using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetCafeCustomerWebApp.Controllers
{
    public class GithubTestController : Controller
    {
        // GET: GithubTestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GithubTestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GithubTestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GithubTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GithubTestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GithubTestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GithubTestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GithubTestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
