using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Common.DTO
{
    public class ContactDTO
    {
        public ContactDTO()
        {
            TelephoneDTOList = new List<TelephoneDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }

        public List<TelephoneDTO> TelephoneDTOList { get; set; }
}
}
