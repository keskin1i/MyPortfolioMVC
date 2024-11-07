using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class CategoryController : Controller
    {
        MyPortfolio _db = new MyPortfolio();

        public ActionResult Index()
        {
            var degerler = _db.TblCategories.ToList();
            
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CreateCategory() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TblCategories categories)
        {
            
            _db.TblCategories.Add(categories);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id) 
        {
            var deger = _db.TblCategories.Find(id);
            _db.TblCategories.Remove(deger);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            var deger = _db.TblCategories.Find(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategories model)
        {
            var deger = _db.TblCategories.Find(model.CategoryId);
            deger.Name = model.Name;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}