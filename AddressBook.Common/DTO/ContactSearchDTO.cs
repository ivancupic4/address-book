using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Common.DTO
{
    public class ContactSearchDTO
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public PagingDTO PagingDTO { get; set; }
    }
}
