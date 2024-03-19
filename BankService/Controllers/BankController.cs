using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankService.Controllers
{
    public class BankController : Controller
    {
        // GET: BankController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BankController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankController/Create
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

        // GET: BankController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankController/Edit/5
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

        // GET: BankController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankController/Delete/5
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
