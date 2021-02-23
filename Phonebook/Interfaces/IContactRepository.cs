using Phonebook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Interfaces
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts { get; }
        IEnumerable<Contact> GetContactsByName(string name);

    }
}
