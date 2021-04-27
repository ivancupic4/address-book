using System;
using System.Collections.Generic;

#nullable disable

namespace AddressBook.DAL.Models
{
    public partial class Telephone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
