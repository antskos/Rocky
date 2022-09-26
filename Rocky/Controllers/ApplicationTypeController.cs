using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: ApplicationTypeController
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> appTypes = _db.ApplicationType;
            return View(appTypes);
        }

      
        // GET: ApplicationTypeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType appType)
        {
            _db.ApplicationType.Add(appType);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
          
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType appType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(appType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appType);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var appType = _db.ApplicationType.Find(id);

            if (appType == null)
                return NotFound();

            _db.ApplicationType.Remove(appType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
