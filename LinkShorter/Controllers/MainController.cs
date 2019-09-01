using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkShorter.Models;
using LinkShorter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkShorter.Controllers
{
    
    public class MainController : Controller
    {
        private readonly DataContext db = new DataContext();
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Links = db.Links.ToList(); 
            return View();
        }
        [Route("{url?}")]
        public IActionResult To(string url) {
            IQueryable<ShortLink> targetLinks = db.Links.Where((link) => link.ShortUrl.Equals(url));
            if (targetLinks.Count()==0) {
                return View("Error"); 
            } else {
                ShortLink targetLink = targetLinks.First();
                targetLink.Counter++;
                db.Update(targetLink);
                db.SaveChanges();
                return Redirect(targetLink.Url);
            }
        }
        [Route("add")]
        public IActionResult AddLink(string url) {
            return View();
        }

        [Route("addlink")]
        public ViewResult GetShortLink(string url) {
            var link = new ShortLink();
            ICodeGenrator codeGenerator = new CodeGenerator(db.Links.ToList());
            link.Url = url;
            link.ShortUrl = codeGenerator.GetUniqueRandomCode();
            link.Date = DateTime.Now;
            link.Counter = 0;
            db.Add(link);
            db.SaveChanges();
            ViewBag.ShortLink ="/" + link.ShortUrl;
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id) {
            return View(db.Links.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(ShortLink link) {
            db.Entry(link).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) {
            db.Remove(db.Links.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}