using Contacts.Model;
using System;
using System.Linq;

namespace Contacts.Repository
{
    public partial class ContactRepository
    {      
        public Model.Contact GetContact(string emailId)
        {
            Validate("emailId",emailId);
            Model.Contact contact = null;
            try
            {
                using (BlahEntities entity = new BlahEntities())
                {
                    var item = entity.Contacts.FirstOrDefault(x => x.EmailId.Equals(emailId, System.StringComparison.OrdinalIgnoreCase));

                    if (item != null)
                    {
                        contact = new Model.Contact()
                        {
                            EmailId = item.EmailId,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            Status = (bool)item.Status
                        };
                    }
                }
            }
            catch(Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
            return contact;
        }       
    }
}
