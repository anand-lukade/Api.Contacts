using Contacts.Interface;
using System;

namespace Contacts.Repository
{
    public partial class ContactRepository : IContactRepository
    {
        private void Validate(string key, string value)
        {
            if (string.IsNullOrEmpty(value) ||
                 string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{key} is required");
            }
        }
    }
}
