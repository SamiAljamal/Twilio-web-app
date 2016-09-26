using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwilioApp.Models;

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
    }
}
