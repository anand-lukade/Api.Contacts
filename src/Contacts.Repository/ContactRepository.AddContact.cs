using Contacts.Model;
using System;

namespace Contacts.Repository
{
    public partial class ContactRepository
    {
        
        public Model.Contact AddContact(Model.Contact contact)
        {
            Validate("firstName", contact.FirstName);
            Validate("lastName", contact.LastName);
            Validate("phoneNumber", contact.PhoneNumber);            
            Validate("emailId", contact.EmailId);
            try
            {
                using (BlahEntities entity = new BlahEntities())
                {
                    Contact contactToAdd = new Contact()
                    {
                        EmailId = contact.EmailId,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        PhoneNumber = contact.PhoneNumber,
                        Status = (bool)contact.Status,
                    };
                    Contact result = entity.Contacts.Add(contactToAdd);
                    if (result==null)
                    {
                        throw new ApplicationException("Record Not updated");
                    }
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
            return contact;
        }       
    }
}
