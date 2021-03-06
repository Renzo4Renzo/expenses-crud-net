using in_and_out.Data;
using in_and_out.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace in_and_out.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ExpenseTypeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;
            return View(objList);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if(ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj) ;
        }

        //POST Delete
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.ExpenseTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST Update
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
