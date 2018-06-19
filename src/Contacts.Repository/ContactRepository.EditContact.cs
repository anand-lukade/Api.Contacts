using Contacts.Model;
using System;
using System.Linq;

namespace Contacts.Repository
{
    public partial class ContactRepository
    {       
        public Model.Contact EditContact(string emailId, Model.Contact contact)
        {
            Validate("emailId", emailId);
            Validate("emailId", contact.EmailId);            
            try
            {
                using (BlahEntities entity = new BlahEntities())
                {
                    Contact item = entity.Contacts.FirstOrDefault(x => x.EmailId.Equals(emailId, System.StringComparison.OrdinalIgnoreCase));

                    if (item != null)
                    {                        
                        item.FirstName = contact.FirstName;
                        item.LastName = contact.LastName;
                        item.PhoneNumber = contact.PhoneNumber;
                        item.Status = (bool)contact.Status;                       
                    }
                    int k=entity.SaveChanges();
                    if(k<=0)
                    {
                        throw new ApplicationException("Record Not updated");
                    }
                }
                contact.EmailId = emailId;
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
            return contact;
        }       
    }
}
