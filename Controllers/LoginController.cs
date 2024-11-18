using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolioMVC.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolio _db = new MyPortfolio();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(TblAdmins model)
        //{
        //    var value = _db.TblAdmins.FirstOrDefault(x=>x.Email.Equals(model.Email) && x.Password.Equals(model.Password));

        //    if (value == null) 
        //    {
        //        ModelState.AddModelError("","Email veya Şifre Hatalı.");
        //        return View(model);
        //    }

        //    //çerezlerde değerlerini tutuyoruz
        //    FormsAuthentication.SetAuthCookie(value.Email,false);

        //    //oturum süresi boyunca isim soyisimi alıyoruz.
        //    Session["nameSurname"].Equals(value.Name+" "+value.SurName);

        //    return RedirectToAction("Index","Category");           
        //}

        [HttpPost]
        public ActionResult Index(TblAdmins model)
        {
            var value = _db.TblAdmins.FirstOrDefault(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));

            if (value == null)
            {
                ModelState.AddModelError("", "Email veya Şifre Hatalı.");
                return View(model);
            }

            // Çerezlerde değerlerini tutuyoruz
            FormsAuthentication.SetAuthCookie(value.Email, false);

            // Oturum süresi boyunca isim soyisimi alıyoruz
            Session["nameSurname"] = value.Name + " " + value.SurName;

            return RedirectToAction("Index", "Category");
        }

    }
}