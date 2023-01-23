using frontend_com_aspnet_mvc.Context;
using frontend_com_aspnet_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace frontend_com_aspnet_mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactsContext _context;

        public ContactController(ContactsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var contactDB = _context.Contacts.Find(contact.Id);

            if (contactDB == null)
            {
                return RedirectToAction(nameof(Index));
            }

            contactDB.Name = contact.Name;
            contactDB.PhoneNumber = contact.PhoneNumber;
            contactDB.Active = contact.Active;

            _context.Contacts.Update(contactDB);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var contactDB = _context.Contacts.Find(contact.Id);

            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Contacts.Remove(contactDB);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}