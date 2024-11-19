using MyPortfolioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyPortfolioMVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortfolio _db = new MyPortfolio();

       
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var deger = _db.TblBanners.Where(b=>b.IsShown==true).ToList();
            return PartialView(deger);
        }

        public PartialViewResult DefaultExpertise()
        {
            var deger = _db.TblExpertises.ToList();
            return PartialView(deger);
        }

        public PartialViewResult DefaultExperience() 
        {
            var deger = _db.TblExperiensies.ToList();
            return PartialView(deger);
        }

        public PartialViewResult DefaultEducation()
        {
            var deger = _db.TblEducation.ToList();
            return PartialView(deger);
        }

        public PartialViewResult DefaultTestimonial()
        {
            var deger = _db.TblTestimonials.ToList();
            return PartialView(deger);
        }
        public PartialViewResult DefaultContact()
        {
            var deger = _db.TblContacts.ToList();
            return PartialView(deger);
        }
        public PartialViewResult DefaultSocialMedia()
        {
            var deger = _db.TblSocialMedias.ToList();
            return PartialView(deger);
        }
        public PartialViewResult DefaultProject() 
        {
            var deger = _db.TblProjects.ToList();
            return PartialView(deger);
        }
        public PartialViewResult DefaultProjectDetail(int id)
        {

            var project = _db.TblProjects.Find(id);
            return PartialView(project);

        }

        //mesaj gönderme işlemleri yapılacak

    }
}