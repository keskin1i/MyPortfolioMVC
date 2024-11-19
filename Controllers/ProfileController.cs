using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioMVC.Controllers
{
    public class ProfileController : Controller
    {
       MyPortfolio _db = new MyPortfolio();

       
        public ActionResult Index()
        {
            string email = Session["email"].ToString();
            var admin = _db.TblAdmins.FirstOrDefault(x=>x.Email == email);
            return View(admin);
        }

        //[HttpPost]
        //public ActionResult Index(TblAdmins tblAdmins)
        //{
        //    string email = Session["email"].ToString() ;
        //    var admin = _db.TblAdmins.FirstOrDefault(x => x.Email == email);


        //    if (admin.Password == tblAdmins.Password)
        //    {
        //        if (tblAdmins.ImageFile != null)
        //        {
        //            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //            var saveLocation = currentDirectory + "images\\";
        //            var fileName = Path.Combine(saveLocation, tblAdmins.ImageFile.FileName);
        //            tblAdmins.ImageFile.SaveAs(fileName);
        //            admin.ImageUrl = "/images/" + tblAdmins.ImageFile.FileName;
        //        }

        //        admin.Name = tblAdmins.Name;
        //        admin.SurName = tblAdmins.SurName;
        //        admin.Email = tblAdmins.Email;

        //        _db.SaveChanges();
        //        Session.Abandon();
        //        return RedirectToAction("Index", "Login");
        //    }

        //    ModelState.AddModelError("", "Girdiğiniz Şifre Yanlıştır.");
        //    return View(tblAdmins);
        //}

        [HttpPost]
        public ActionResult Index(TblAdmins tblAdmins)
        {
           
            string email = Session["email"]?.ToString();
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Oturum açılmamış.");
                return View(tblAdmins);
            }

          
            var admin = _db.TblAdmins.FirstOrDefault(x => x.Email == email);

            if (admin == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(tblAdmins);
            }

     
            if (admin.Password != tblAdmins.Password)
            {
                ModelState.AddModelError("", "Girdiğiniz şifre yanlış.");
                return View(tblAdmins);
            }

          
            if (tblAdmins.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = Path.Combine(currentDirectory, "images");

           
                var fileName = Path.Combine(saveLocation, Path.GetFileName(tblAdmins.ImageFile.FileName));
                tblAdmins.ImageFile.SaveAs(fileName);

                admin.ImageUrl = "/images/" + Path.GetFileName(tblAdmins.ImageFile.FileName);
            }

         
            admin.Name = tblAdmins.Name;
            admin.SurName = tblAdmins.SurName;
            admin.Email = tblAdmins.Email;

            _db.SaveChanges();

          
            Session.Abandon();

            
            return RedirectToAction("Index", "Login");
        }




    }
}