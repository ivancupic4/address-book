using AddressBook.Common.DTO;
using AddressBook.DAL.Repositories;
using AddressBook.Domain.Builders;
using AddressBook.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactDTOBuilder _contactDTOBuilder;
        private readonly ContactDbMapper _contactDbMapper;

        public ContactService(IContactRepository contactRepository,
            ContactDTOBuilder contactDTOBuilder,
            ContactDbMapper contactDbMapper)
        {
            this._contactRepository = contactRepository;
            this._contactDTOBuilder = contactDTOBuilder;
            this._contactDbMapper = contactDbMapper;
        }

        public ContactDTO GetContact(int contactId)
        {
            var contact = this._contactRepository.GetContact(contactId);
            var contactDTO = this._contactDTOBuilder.MapContactToContactDTO(contact);

            return contactDTO;
        }

        public List<ContactDTO> GetContacts(ContactSearchDTO contactSearchDTO)
        {
            var contacts = this._contactRepository.GetContacts(contactSearchDTO);
            var contactDTOList = this._contactDTOBuilder.MapContactsToContactDTOList(contacts);

            return contactDTOList;
        }

        public void InsertContact(ContactDTO contactDTO)
        {
            var contact = this._contactDbMapper.MapContactDTOToContact(contactDTO);
            this._contactRepository.InsertContact(contact);
        }

        public void UpdateContact(ContactDTO contactDTO)
        {
            var contact = this._contactDbMapper.MapContactDTOToContact(contactDTO);
            this._contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(int contactId)
        {
            this._contactRepository.DeleteContact(contactId);
        }
    }
}
