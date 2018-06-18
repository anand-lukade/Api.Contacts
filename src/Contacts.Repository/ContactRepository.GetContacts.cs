using Contacts.Model;
using System.Collections.Generic;

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

            total = 2;


            return new List<Model.Contact>()
            {
                new Model.Contact()
                {
                    EmailId = "anand.lukade@gmail.com",
                    FirstName = "anand",
                    LastName="lukade",
                    PhoneNumber="8007891986",
                    Status=true
                },
                new Model.Contact()
                {
                    EmailId = "prasad.khandat@gmail.com",
                    FirstName = "prasad",
                    LastName="khandat",
                    PhoneNumber="8007691986",
                    Status=false
                }
            };
        }
    }
}
