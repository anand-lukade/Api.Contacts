using System;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Http
{
    public partial class ContactsController
    {
        [HttpPut]
        [Route("~/contacts/{emailId}/contact", Name = "EditContact")]
        
        public HttpResponseMessage EditContact(string emailId, Contact contact)
        {
            if (contact != null)
            {
                Validate("emailId", emailId);
                ValidateEmail(emailId);
                Validate("emailId", contact.Email);
                Validate("firstName", contact.FirstName);
                Validate("lastName", contact.LastName);
                Validate("phoneNumber", contact.PhoneNumber);
                ValidateEmail(contact.Email);
                var result = ContactRepositoryInstance.EditContact(
                    emailId,
                    AutoMapper.Mapper.
                    Map<Contact, Contacts.Model.Contact>(contact)
                    );
                return this.Request.CreateResponse(System.Net.HttpStatusCode.Accepted, result);
            }
            else
            {
                throw new ArgumentNullException("request is empty");
            }
        }
    }
}
