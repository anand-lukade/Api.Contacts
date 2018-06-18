using System;
using System.Linq;

namespace Contacts.Repository
{
    public partial class ContactRepository
    {       
        public void RemoveContact(string emailId)
        {
            Validate("emailId", emailId);            
            try
            {
                using (BlahEntities entity = new BlahEntities())
                {
                    Contact item = entity.Contacts.FirstOrDefault(x => x.EmailId.Equals(emailId, System.StringComparison.OrdinalIgnoreCase));

                    if (item != null)
                    {
                        entity.Contacts.Remove(item);
                    }                    
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }            
        }
    }
}
