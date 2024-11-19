using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolio _db = new MyPortfolio();
        // GET: _AdminLayout
        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead() 
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner() 
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            var email = Session["email"].ToString();
               var admin = _db.TblAdmins.FirstOrDefault(x => x.Email == email);
              ViewBag.nameSurname = admin.Name+" "+admin.SurName;
                ViewBag.image = admin.ImageUrl;
               return PartialView();
            
        }

        //public PartialViewResult AdminLayoutNavbar() 
        //{
        //    var email = Session["email"].ToString();
        //    var admin = _db.TblAdmins.FirstOrDefault(x => x.Email == email);
        //    ViewBag.nameSurname = admin.Name+" "+admin.SurName;
        //    ViewBag.image = admin.ImageUrl;
        //    return PartialView();
        //}

        public PartialViewResult AdminLayoutNavbar()
        {
            
            string email = Session["email"]?.ToString();         
            if (string.IsNullOrEmpty(email))
            {
                return PartialView("Error"); //hata sayfası verip error sayfasına yönlendirme
            }          
            var admin = _db.TblAdmins.FirstOrDefault(x => x.Email == email);            
            if (admin == null)
            {
                return PartialView("Error"); 
            }         
            ViewBag.nameSurname = admin.Name + " " + admin.SurName;
            ViewBag.image = admin.ImageUrl;

            return PartialView();
        }

        public PartialViewResult AdminLayoutFooter() 
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutScripts() 
        {
            return PartialView();
        }
    }
}