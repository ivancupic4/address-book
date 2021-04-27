using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Common.DTO;
using AddressBook.Domain.Services;
using AddressBook.Web.Hubs;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ContactHub _contactHub;

        public ContactController(IContactService contactService, ContactHub contactHub)
        {
            this._contactService = contactService;
            this._contactHub = contactHub;
        }

        [HttpGet]
        [Route("get/{contactId:int}")]
        public async Task<ContactDTO> Get(int contactId)
        {
            var contactDTO = this._contactService.GetContact(contactId);
            await this._contactHub.SendGetMessage(contactDTO.Name);

            return contactDTO;
        }

        [HttpGet]
        [Route("getList")]
        public async Task<List<ContactDTO>> Get([FromBody] ContactSearchDTO contactSearchDTO)
        {
            var contactDTOList = this._contactService.GetContacts(contactSearchDTO);
            await this._contactHub.SendGetListMessage(contactDTOList.Count);

            return contactDTOList;
        }

        [HttpPost]
        [Route("insert")]
        public async void Post([FromBody] ContactDTO contactDTO)
        {
            this._contactService.InsertContact(contactDTO);
            await this._contactHub.SendInsertMessage(contactDTO.Name);
        }

        [HttpPut]
        [Route("update")]
        public async void Put([FromBody] ContactDTO contactDTO)
        {
            this._contactService.UpdateContact(contactDTO);
            await this._contactHub.SendUpdateMessage(contactDTO.Name);
        }

        [HttpDelete]
        [Route("delete/{contactId:int}")]
        public async void Delete(int contactId)
        {
            this._contactService.DeleteContact(contactId);
            await this._contactHub.SendDeleteMessage(contactId);
        }
    }
}
