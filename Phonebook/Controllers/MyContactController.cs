using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Entities;

namespace Phonebook.Controllers
{
    public class MyContactController : Controller
    {
        private readonly ContactContext _context;

        public MyContactController(ContactContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> AllContacts()
        {
            return View(await _context.Contacts.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(SearchController.Details), nameof(SearchController).Replace(nameof(Controller), ""), new { id});
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Phone,Emails")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {              
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllContacts));
            }
            return View(contact);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllContacts));
        }

    }

}
