using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Repository
{
    public partial class ContactRepository
    {
        public List<Model.Contact> GetContacts(int page,int pageSize, out int total)
        {
            if (page < 0)
            {
                page = 1;
            }

            if (pageSize < 0 || pageSize > 10)
            {
                pageSize = 10;
            }
            List<Model.Contact> contacts = new List<Model.Contact>();
            try
            {
                using (BlahEntities entity = new BlahEntities())
                {
                    total = entity.Contacts.Count();
                    var items = entity.Contacts.OrderBy(x=>x.EmailId).Skip((page - 1) * pageSize).Take(pageSize);
                    
                    foreach (var item in items)
                    {
                        contacts.Add(new Model.Contact()
                        {
                            EmailId = item.EmailId,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            Status = (bool)item.Status
                        });                        
                    }                    
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }            
            return contacts;
        }
    }
}
