using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Common.DTO
{
    public class ItemDTO<T> where T : new()
    {
        public ItemDTO()
        {
            this.Item = new T();
            this.NotificationDTO = new NotificationDTO();
        }

        public T Item { get; set; }
        public NotificationDTO NotificationDTO { get; set; }
    }
}
