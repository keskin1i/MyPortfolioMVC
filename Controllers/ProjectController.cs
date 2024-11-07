using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class ProjectController : Controller
    {
       MyPortfolio _db = new MyPortfolio();
        public ActionResult Index()
        {
            var deger = _db.TblProjects.ToList();
            return View(deger);
        }



        [HttpGet]
        public ActionResult CreateProject()
        {
            categoriDroplist();

            return View();
        }


        [HttpPost]
        public ActionResult CreateProject(TblProjects tblProjects)
        {
            if (!ModelState.IsValid)
            {
                categoriDroplist();
                return View(tblProjects);
            }

            _db.TblProjects.Add(tblProjects);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void categoriDroplist()
        {
            var categoryList = _db.TblCategories.ToList();
            List<SelectListItem> categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.Categori = categories;
        }

        public ActionResult DeleteProject(int id) 
        {
            var deger = _db.TblProjects.Find(id);
            _db.TblProjects.Remove(deger);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            categoriDroplist();
            var deger = _db.TblProjects.Find(id);
            
               
                return View(deger);       

        }

        [HttpPost]
        public ActionResult UpdateProject(TblProjects tblProjects)
        {
            categoriDroplist();
            var deger = _db.TblProjects.Find(tblProjects.ProjectId);
            deger.Name = tblProjects.Name;
            deger.Description = tblProjects.Description;
            deger.ImageUrl = tblProjects.ImageUrl;
            deger.GithupUrl = tblProjects.GithupUrl;
            deger.CategoryId = tblProjects.CategoryId;
            if (!ModelState.IsValid) 
            {
               
                return View(deger);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }



   
   
}