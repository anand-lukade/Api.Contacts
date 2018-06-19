using System;
using System.Net;
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
                Validate("emailId", contact.EmailId);
                Validate("firstName", contact.FirstName);
                Validate("lastName", contact.LastName);
                Validate("phoneNumber", contact.PhoneNumber);
                ValidateEmail(contact.EmailId);
                try
                {
                    var result = ContactRepositoryInstance.EditContact(
                    emailId,
                    AutoMapper.Mapper.
                    Map<Contact, Contacts.Model.Contact>(contact)
                    );
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.Accepted, result);
                }
                catch (Exception exception)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(exception.Message),
                        ReasonPhrase = "internal error"
                    };
                    throw new HttpResponseException(resp);
                }            
            }
            else
            {
                throw new ArgumentNullException("request is empty");
            }
        }
    }
}
