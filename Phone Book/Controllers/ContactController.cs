using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phone_Book.DAL;
using Phone_Book.Models;

namespace Phone_Book.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactsDBContext _db;
        public ContactController(ContactsDBContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Contacts.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _db.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        private void LoadContacts()
        {
            ViewData["Contacts"] = _db.Contacts.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            //var contacts = _db.Contacts.ToList();
            //ViewBag.contacts = new SelectList(contacts, "Id", "Name", "lastName", "PhoneNumber");

        }
        [HttpPost]
        public IActionResult Create(Contact Model)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(Model);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                NotFound();
            }

            LoadContacts();

            var Contact = _db.Contacts.Find(id);
            return View(Contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact Model)
        {
            ModelState.Remove("Contacts");
            if (ModelState.IsValid)
            {
                _db.Contacts.Update(Model);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
            LoadContacts();
            var Categories = _db.Contacts.Find(id);
            return View(Categories);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult SubmitDelete(Contact model)
        {
            _db.Contacts.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
