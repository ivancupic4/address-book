using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Common.DTO
{
    public class NotificationDTO
    {
        public ICollection<String> Errors { get; set; }
        public ICollection<String> Success { get; set; }
        public ICollection<String> Warnings { get; set; }
        public ICollection<String> Infos { get; set; }

        public NotificationDTO()
        {
            this.Errors = Enumerable.Empty<String>().ToList();
            this.Success = Enumerable.Empty<String>().ToList();
            this.Warnings = Enumerable.Empty<String>().ToList();
            this.Infos = Enumerable.Empty<String>().ToList();
        }

        public void AddErrorMessage(string message)
            => Errors.Add(message);
        
        public void AddSuccessMessage(string message)
            => Success.Add(message);

        public void AddWarningMessage(string message)
            => Warnings.Add(message);

        public void AddInfoMessage(string message)
            => Infos.Add(message);

        public bool HasErrors
        {
            get => Errors.Any();
        }
    }
}
