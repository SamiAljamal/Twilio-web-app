using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwilioApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TwilioApp.Controllers
{
    public class ContactController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(db.Contacts.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return Redirect("Index");
        }
        public IActionResult Edit(int id)
        {
           var  it= db.Contacts.FirstOrDefault(i => i.ContactId == id);
            return View(it);
              
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var it = db.Contacts.FirstOrDefault(i => i.ContactId == id);
            return View(it);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            db.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
