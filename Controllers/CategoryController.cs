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
    }
}