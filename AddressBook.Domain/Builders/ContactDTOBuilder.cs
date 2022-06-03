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
                contactDTOList.Add(MapContactToContactDTO(contact));
            }
            return contactDTOList;
        }

        public ContactDTO MapContactToContactDTO(Contact contact)
        {
            return new ContactDTO()
            {
                Id = contact.Id,
                Name = contact.Name,
                Address = contact.Address,
                BirthDate = contact.BirthDate,
                TelephoneDTOList = MapTelephonesToTelephoneDTOList(contact.Telephones)
            };
        }

        public List<TelephoneDTO> MapTelephonesToTelephoneDTOList(ICollection<Telephone> telephones)
        {
            var telephoneDTOList = new List<TelephoneDTO>();
            foreach (var telephone in telephones)
            {
                telephoneDTOList.Add(MapTelephoneToTelephoneDTO(telephone));
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
