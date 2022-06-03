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

        public ItemDTO<ContactDTO> GetContact(int contactId)
        {
            var result = new ItemDTO<ContactDTO>();

            try
            {
                var contact = this._contactRepository.GetContact(contactId);
                if (contact == null)
                {
                    result.NotificationDTO.AddErrorMessage($"The contact with Id={contactId} does not exist");
                    return result;
                }
                result.Item = this._contactDTOBuilder.MapContactToContactDTO(contact);
            }
            catch (Exception ex)
            {
                result.NotificationDTO.AddErrorMessage($"Error {ex.Message}");
            }

            return result;
        }

        public ItemDTO<List<ContactDTO>> GetContacts(ContactSearchDTO contactSearchDTO)
        {
            var result = new ItemDTO<List<ContactDTO>>();

            try
            {
                var contacts = this._contactRepository.GetContacts(contactSearchDTO);
                result.Item = this._contactDTOBuilder.MapContactsToContactDTOList(contacts);
            }
            catch (Exception ex)
            {
                result.NotificationDTO.AddErrorMessage($"Error {ex.Message}");
            }

            return result;
        }

        public ItemDTO<int> InsertContact(ContactDTO contactDTO)
        {
            var result = new ItemDTO<int>();

            try
            {
                var contact = this._contactDbMapper.MapContactDTOToContact(contactDTO);
                this._contactRepository.InsertContact(contact);

                result.Item = 1;
                result.NotificationDTO.AddSuccessMessage("Contact saved successfully");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("no_duplicate_contact"))
                {
                    result.NotificationDTO.AddErrorMessage("Contact must have unique name and address properties");
                }
                else
                {
                    result.NotificationDTO.AddErrorMessage($"Error {ex.Message}");
                }
            }

            return result;
        }

        public ItemDTO<int> UpdateContact(ContactDTO contactDTO)
        {
            var result = new ItemDTO<int>();

            try
            {
                var contact = this._contactDbMapper.MapContactDTOToContact(contactDTO);
                bool success = this._contactRepository.UpdateContact(contact);
                if (!success)
                {
                    result.NotificationDTO.AddErrorMessage($"The contact with Id={contactDTO.Id} does not exist");
                    return result;
                }

                result.Item = 1;
                result.NotificationDTO.AddSuccessMessage($"Contact {contactDTO.Name} updated successfully");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("no_duplicate_contact"))
                    result.NotificationDTO.AddErrorMessage("Contact must have unique name and address properties");
                else
                    result.NotificationDTO.AddErrorMessage($"Error {ex.Message}");
            }

            return result;
        }

        public ItemDTO<int> DeleteContact(int contactId)
        {
            var result = new ItemDTO<int>();

            try
            {
                bool success = this._contactRepository.DeleteContact(contactId);
                if (!success)
                {
                    result.NotificationDTO.AddErrorMessage($"The contact with Id={contactId} does not exist");
                    return result;
                }

                result.Item = 1;
                result.NotificationDTO.AddSuccessMessage($"Contact deleted successfully");
            }
            catch (Exception ex)
            {
                result.NotificationDTO.AddErrorMessage($"Error {ex.Message}");
            }

            return result;
        }
    }
}
