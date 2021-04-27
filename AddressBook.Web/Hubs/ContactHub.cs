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
            string message = $"The contact {contactName} successfully loaded!";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendGetListMessage(int contactCount)
        {
            string message = $"Contact list of {contactCount} items successfully loaded!";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendInsertMessage(string contactName)
        {
            string message = $"The contact {contactName} successfully inserted!";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendUpdateMessage(string contactName)
        {
            string message = $"The contact {contactName} successfully updated!";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendDeleteMessage(int contactId)
        {
            string message = $"The contact with Id={contactId} successfully deleted!";
            await this._context.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
