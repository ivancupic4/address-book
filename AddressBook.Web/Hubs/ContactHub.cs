using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Web.Hubs
{
    public class ContactHub : Hub
    {
        private readonly IHubContext<ContactHub> _context;

        public ContactHub(IHubContext<ContactHub> context)
        {
            this._context = context;
        }

        public async Task SendGetMessage(string contactName)
            => await this._context.Clients.All.SendAsync("ReceiveMessage", $"Loading contact {contactName}");

        public async Task SendGetListMessage(int contactCount)
            => await this._context.Clients.All.SendAsync("ReceiveMessage", $"Loading contact list of {contactCount} items");

        public async Task SendInsertMessage(string contactName)
            => await this._context.Clients.All.SendAsync("ReceiveMessage", $"Inserting contact {contactName}");

        public async Task SendUpdateMessage(string contactName)
            => await this._context.Clients.All.SendAsync("ReceiveMessage", $"Updating contact {contactName}");

        public async Task SendDeleteMessage(int contactId)
            => await this._context.Clients.All.SendAsync("ReceiveMessage", $"Deleting contact with Id={contactId}");
    }
}
