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
        {
            string message = $"Loading contact {contactName}";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendGetListMessage(int contactCount)
        {
            string message = $"Loading contact list of {contactCount} items";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendInsertMessage(string contactName)
        {
            string message = $"Inserting contact {contactName}";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendUpdateMessage(string contactName)
        {
            string message = $"Updating contact {contactName}";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendDeleteMessage(int contactId)
        {
            string message = $"Deleting contact with Id={contactId}";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
