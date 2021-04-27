using AddressBook.Common.DTO;
using AddressBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Builders
{
    public class ContactDTOBuilder
    {
        public List<ContactDTO> MapContactsToContactDTOList(List<Contact> contacts)
        {
            var contactDTOList = new List<ContactDTO>();

            foreach (var contact in contacts)
            {
                var contactDTO = MapContactToContactDTO(contact);
                contactDTOList.Add(contactDTO);
            }

            return contactDTOList;
        }

        public ContactDTO MapContactToContactDTO(Contact contact)
        {
            var contactDTO = new ContactDTO()
            {
                Id = contact.Id,
                Name = contact.Name,
                Address = contact.Address,
                BirthDate = contact.BirthDate
            };

            contactDTO.TelephoneDTOList = MapTelephonesToTelephoneDTOList(contact.Telephones);

            return contactDTO;
        }

        public List<TelephoneDTO> MapTelephonesToTelephoneDTOList(ICollection<Telephone> telephones)
        {
            var telephoneDTOList = new List<TelephoneDTO>();

            foreach (var telephone in telephones)
            {
                var telephoneDTO = MapTelephoneToTelephoneDTO(telephone);
                telephoneDTOList.Add(telephoneDTO);
            }

            return telephoneDTOList;
        }

        public TelephoneDTO MapTelephoneToTelephoneDTO(Telephone telephone)
        {
            return new TelephoneDTO()
            {
                Id = telephone.Id,
                Number = telephone.Number,
                ContactId = telephone.ContactId.Value
            };
        }
    }
}
