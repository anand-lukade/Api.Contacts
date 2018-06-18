using Contacts.Model;
using System.Collections.Generic;

namespace Contacts.Interface
{
    public interface IContactRepository
    {
        List<Contact> GetContacts(int page,int size, out int total);
        Contact GetContact(string emailId);
        Contact AddContact(Contact contact);
        Contact EditContact(string emailId, Contact contact);
        void RemoveContact(string emailId);
    }
}
