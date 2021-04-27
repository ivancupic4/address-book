using AddressBook.Common.DTO;
using AddressBook.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookContext _addressBookContext;

        public ContactRepository(AddressBookContext addressBookContext)
        {
            this._addressBookContext = addressBookContext;
        }

        public Contact GetContact(int contactId)
        {
            var contact = this._addressBookContext.Contacts
                .Include(x => x.Telephones)
                .Where(x => x.Id == contactId)
                .Single();

            return contact;
        }

        public List<Contact> GetContacts(ContactSearchDTO contactSearchDTO)
        {
            var query = this._addressBookContext.Contacts
                .Include(x => x.Telephones)
                .Where(x => contactSearchDTO.Name == null || x.Name == contactSearchDTO.Name)
                .Where(x => contactSearchDTO.Address == null || x.Address == contactSearchDTO.Address)
                .Where(x => contactSearchDTO.BirthDate == null || x.BirthDate == contactSearchDTO.BirthDate)
                .Where(x => contactSearchDTO.Telephone == null ||
                            x.Telephones.Any(y => y.Number == contactSearchDTO.Telephone));

            if (contactSearchDTO.PagingDTO != null)
            {
                query = query.Skip((contactSearchDTO.PagingDTO.PageNumber - 1) * contactSearchDTO.PagingDTO.PageSize);
                query = query.Take(contactSearchDTO.PagingDTO.PageSize);
            }

            return query.ToList();
        }

        public void InsertContact(Contact contact)
        {
            this._addressBookContext.Contacts.Add(contact);
            this._addressBookContext.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            var dbContact = this._addressBookContext.Contacts.Find(contact.Id);
            dbContact.Name = contact.Name;
            dbContact.Address = contact.Address;
            dbContact.BirthDate = contact.BirthDate;

            var dbTelephones = this._addressBookContext.Telephones.Where(x => x.ContactId == contact.Id);
            var newTelephones = contact.Telephones;

            // delete telephones that are only in the database, and not in received object
            var newTelephoneNumbers = newTelephones.Select(y => y.Number);
            var telephonesForDelete = dbTelephones.Where(x => !newTelephoneNumbers.Contains(x.Number));
            this._addressBookContext.Telephones.RemoveRange(telephonesForDelete);

            // add all received telephones that do not exist in the database
            var dbTelephoneNumbers = dbTelephones.Select(y => y.Number);
            var telephonesForInsert = newTelephones.Where(x => !dbTelephoneNumbers.Contains(x.Number));
            this._addressBookContext.Telephones.AddRange(telephonesForInsert);

            this._addressBookContext.SaveChanges();
        }

        public void DeleteContact(int contactId)
        {
            var dbTelephones = this._addressBookContext.Telephones.Where(x => x.ContactId == contactId);
            this._addressBookContext.Telephones.RemoveRange(dbTelephones);

            var dbContact = this._addressBookContext.Contacts.Find(contactId);
            this._addressBookContext.Contacts.Remove(dbContact);

            this._addressBookContext.SaveChanges();
        }
    }
}
