using AddressBook.Common.DTO;
using AddressBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Mappers
{
    public class ContactDbMapper
    {
        public Contact MapContactDTOToContact(ContactDTO contactDTO)
        {
            return new Contact()
            {
                Id = contactDTO.Id,
                Name = contactDTO.Name,
                Address = contactDTO.Address,
                BirthDate = contactDTO.BirthDate,
                Telephones = MapTelephoneDTOListToTelephoneList(contactDTO.TelephoneDTOList, contactDTO.Id)
            };
        }

        public List<Telephone> MapTelephoneDTOListToTelephoneList(List<TelephoneDTO> telephoneDTOList, int contactId)
        {
            var telephones = new List<Telephone>();
            foreach (var telephoneDTO in telephoneDTOList)
            {
                var telephone = MapTelephoneDTOToTelephone(telephoneDTO, contactId);
                telephones.Add(telephone);
            }
            return telephones;
        }

        public Telephone MapTelephoneDTOToTelephone(TelephoneDTO telephoneDTO, int contactId)
        {
            return new Telephone()
            {
                Number = telephoneDTO.Number,
                ContactId = contactId
            };
        }
    }
}
