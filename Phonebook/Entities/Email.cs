using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Entities
{
    public class Email
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Mail { get; set; }
        public Contact Contact { get; set; }

        public override string ToString()
        {
            return this.Mail;
        }

    }
}
