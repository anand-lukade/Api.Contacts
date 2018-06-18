using Contacts.Model;

namespace Contacts.Repository
{
    public partial class ContactRepository
    {      
        public Contact GetContact(string emailId)
        {
            Validate("emailId",emailId);
            return new Contact()
            {
                Email = "anand.lukade@gmail.com",
                FirstName = "anand",
                LastName="lukade",
                PhoneNumber="8007891986",
                Status=Status.Active
            };
        }       
    }
}
