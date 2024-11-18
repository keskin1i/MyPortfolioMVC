using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolio _db = new MyPortfolio();

        public ActionResult Index()
        {
            var deger = _db.TblEducation.ToList();
            return View(deger);
        }

        public ActionResult DeleteEducation(int id)
        {
            var deger = _db.TblEducation.Find(id);
            _db.TblEducation.Remove(deger);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(TblEducation tblEducation)
        {
            _db.TblEducation.Add(tblEducation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var deger = _db.TblEducation.Find(id);
            return View(deger);

        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation model)
        {
            var deger = _db.TblEducation.Find(model.EducationId);
            deger.SchoolName = model.SchoolName;
            deger.Description = model.Description;
            deger.Degree = model.Degree;
            deger.Department = model.Department;
            deger.StartDate = model.StartDate;
            deger.EndDate = model.EndDate;

            _db.SaveChanges();
            return RedirectToAction("Index");
            

        }
    }
}