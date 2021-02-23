using System;
using System.Collections.Generic;
using System.Linq;
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
        //GET: Add Contact
        public async Task<IActionResult> Create()
        {
            var contact = await _context.Emails.ToListAsync();
            ViewData["Create"] = contact;
            return View();
        }

        //POST: Add Contact

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,Emails")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));

            }
            return View(contact);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
