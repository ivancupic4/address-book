using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Common.DTO
{
    public class TelephoneDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ContactId { get; set; }
    }
}
