using System;
using System.Collections.Generic;

#nullable disable

namespace AddressBook.DAL.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Telephones = new HashSet<Telephone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Telephone> Telephones { get; set; }
    }
}
