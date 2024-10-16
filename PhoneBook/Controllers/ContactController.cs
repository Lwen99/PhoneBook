using DataAccess.Models;
using DataAccess.ORMs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace PhoneBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();
            return View(contacts);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(a => a.Id == id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpGet("Contact/Update/{Id}")]
        public IActionResult Update([FromRoute]int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(s => s.Id == id);
            if (contact != null)
            {
                return View(contact);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
