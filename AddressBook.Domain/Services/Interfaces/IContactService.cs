using AddressBook.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Services
{
    public interface IContactService
    {
        public ItemDTO<ContactDTO> GetContact(int contactId);
        public ItemDTO<List<ContactDTO>> GetContacts(ContactSearchDTO contactSearchDTO);
        public ItemDTO<int> InsertContact(ContactDTO contactDTO);
        public ItemDTO<int> UpdateContact(ContactDTO contactDTO);
        public ItemDTO<int> DeleteContact(int contactId);
    }
}
