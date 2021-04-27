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
        public async Task<ItemDTO<ContactDTO>> Get(int contactId)
        {
            var result = this._contactService.GetContact(contactId);
            await this._contactHub.SendGetMessage(result.Item.Name);

            return result;
        }

        [HttpGet]
        [Route("getList")]
        public async Task<ItemDTO<List<ContactDTO>>> Get([FromBody] ContactSearchDTO contactSearchDTO)
        {
            var result = this._contactService.GetContacts(contactSearchDTO);
            await this._contactHub.SendGetListMessage(result.Item.Count);

            return result;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ItemDTO<int>> Post([FromBody] ContactDTO contactDTO)
        {
            var result = this._contactService.InsertContact(contactDTO);
            await this._contactHub.SendInsertMessage(contactDTO.Name);

            return result;
        }

        [HttpPut]
        [Route("update")]
        public async Task<ItemDTO<int>> Put([FromBody] ContactDTO contactDTO)
        {
            var result = this._contactService.UpdateContact(contactDTO);
            await this._contactHub.SendUpdateMessage(contactDTO.Name);

            return result;
        }

        [HttpDelete]
        [Route("delete/{contactId:int}")]
        public async Task<ItemDTO<int>> Delete(int contactId)
        {
            var result = this._contactService.DeleteContact(contactId);
            await this._contactHub.SendDeleteMessage(contactId);

            return result;
        }
    }
}
