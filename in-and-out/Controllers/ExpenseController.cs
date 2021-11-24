using in_and_out.Data;
using in_and_out.Models;
using in_and_out.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace in_and_out.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ExpenseController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;

            foreach(var obj in objList)
            {
                obj.ExpenseType =  _db.ExpenseTypes.FirstOrDefault(et => et.Id == obj.ExpenseTypeId);
            }
            return View(objList);
        }

        //GET Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> expenseTypesDropdown = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString(),
            //});
            //ViewBag.ExpenseTypesDropdown = expenseTypesDropdown;

            ExpenseVM expenseVM = new ExpenseVM(){
                Expense = new Expense(),
                ExpenseTypesDropdown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };

            return View(expenseVM);
        }

        //POST Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            if(ModelState.IsValid)
            {
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Delete
        public IActionResult Delete(int? expenseId)
        {
            if (expenseId == null || expenseId == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(expenseId);
            obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(et => et.Id == obj.ExpenseTypeId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj) ;
        }

        //POST Delete
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? ExpenseId)
        {
            //System.Diagnostics.Debug.WriteLine("Hi from DELETE POST!");
            var obj = _db.Expenses.Find(ExpenseId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Update
        public IActionResult Update(int? expenseId)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                ExpenseTypesDropdown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };

            if (expenseId == null || expenseId == 0)
            {
                return NotFound();
            }
            expenseVM.Expense = _db.Expenses.Find(expenseId);
            if (expenseVM.Expense == null)
            {
                return NotFound();
            }
            return View(expenseVM);
        }

        //POST Update
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
