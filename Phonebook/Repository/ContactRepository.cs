using Phonebook.Entities;
using Phonebook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext context;
        public ContactRepository(ContactContext context)
        {
            this.context = context;
        }
        public IEnumerable<Contact> GetAllContacts => context.Contacts.ToList();


        public IEnumerable<Contact> GetContactsByName(string name) => context.Contacts.Where(c => c.Name == name).ToList();
    }
}
