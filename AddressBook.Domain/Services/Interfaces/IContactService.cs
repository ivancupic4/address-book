using AddressBook.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Services
{
    public interface IContactService
    {
        public ContactDTO GetContact(int contactId);
        public List<ContactDTO> GetContacts(ContactSearchDTO contactSearchDTO);
        public void InsertContact(ContactDTO contactDTO);
        public void UpdateContact(ContactDTO contactDTO);
        public void DeleteContact(int contactId);
    }
}
