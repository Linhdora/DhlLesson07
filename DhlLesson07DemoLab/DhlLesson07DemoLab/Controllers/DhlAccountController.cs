using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DhlLesson07DemoLab.Models;
namespace DhlLesson07DemoLab.Controllers
{
    public class DhlAccountController : Controller
    {
        // GET: DhlAccountController
        public ActionResult Index()
        {
            List<DhlAccount> accounts = new List<DhlAccount>();

            return View(accounts);
        }

        // GET: DhlAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DhlAccountController/Create
        public ActionResult Create()
        {
            DhlAccount model = new DhlAccount();
            return View(model);
        }

        // POST: DhlAccountController/Create
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

        // GET: DhlAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DhlAccountController/Edit/5
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

        // GET: DhlAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DhlAccountController/Delete/5
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
