
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Entities;

namespace Phonebook.Controllers
{
    public class AddContactController : Controller
    {

        private readonly ContactContext _context;

        public AddContactController(ContactContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create()
        {
            var contact = await _context.Contacts.ToListAsync();
            ViewData["Create"] = contact;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllContacts", "MyContact");
            }
            return View(contact);           
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
