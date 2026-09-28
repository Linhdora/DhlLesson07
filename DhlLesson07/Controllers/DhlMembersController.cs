using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DhlLesson07.Models;
namespace DhlLesson07.Controllers
{
    public class DhlMembersController : Controller
    {
        private static List<DhlMember> dhlMembers = new List<DhlMember>();
        // GET: DhlLesson07AnnotationController
        public ActionResult DhlIndex()
        {
            return View(dhlMembers);
        }

        // GET: DhlLesson07AnnotationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DhlLesson07AnnotationController/Create
        public ActionResult DhlCreate()
        {

                return View();
        }

        // POST: DhlLesson07AnnotationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DhlCreate(DhlMember dhlMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dhlMember);
                }
                dhlMembers.Add(dhlMember);
                return RedirectToAction(nameof(DhlIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: DhlLesson07AnnotationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DhlLesson07AnnotationController/Edit/5
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

        // GET: DhlLesson07AnnotationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DhlLesson07AnnotationController/Delete/5
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
