using AddressBook.Common.DTO;
using AddressBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.DAL.Repositories
{
    public interface IContactRepository
    {
        public Contact GetContact(int contactId);
        public List<Contact> GetContacts(ContactSearchDTO contactSearchDTO);
        public void InsertContact(Contact contact);
        public bool UpdateContact(Contact contact);
        public bool DeleteContact(int contactId);
    }
}
