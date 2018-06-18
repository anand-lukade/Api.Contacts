using System;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Http
{
    public partial class ContactsController
    {
        [HttpPost]
        [Route("~/contacts", Name = "AddContact")]        
        public HttpResponseMessage AddContact(Contact contact)
        {
            if(contact!=null)
            {
                Validate("emailId", contact.EmailId);
                Validate("firstName", contact.FirstName);
                Validate("lastName", contact.LastName);
                Validate("phoneNumber", contact.PhoneNumber);                
                ValidateEmail(contact.EmailId);
                var result = ContactRepositoryInstance.AddContact(
                    AutoMapper.Mapper.
                    Map<Contact, Contacts.Model.Contact>(contact)
                    );
                return this.Request.CreateResponse(System.Net.HttpStatusCode.Created, result);
            }
            else
            {
                throw new ArgumentNullException("request is empty");
            }            
        }
    }
}
