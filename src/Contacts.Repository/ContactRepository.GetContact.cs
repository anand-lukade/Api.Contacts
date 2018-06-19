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
           
                using (BlahEntities entity = new BlahEntities())
                {
                Contact item = null;
                try
                {
                    item = entity.Contacts.FirstOrDefault(x => x.EmailId.ToLower()==emailId);
                }
                catch (Exception exception)
                {
                    throw new ApplicationException(exception.Message);
                }
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
                    else
                    {
                        throw new ArgumentException("no data found for" + emailId);
                    }
                }
            
            return contact;
        }       
    }
}
