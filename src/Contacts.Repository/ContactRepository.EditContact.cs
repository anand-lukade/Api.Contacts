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
                        item.EmailId = item.EmailId;
                        item.FirstName = item.FirstName;
                        item.LastName = item.LastName;
                        item.PhoneNumber = item.PhoneNumber;
                        item.Status = (bool)item.Status;                       
                    }
                    int k=entity.SaveChanges();
                    if(k<=0)
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
