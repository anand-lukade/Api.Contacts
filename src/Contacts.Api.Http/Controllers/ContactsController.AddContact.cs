using System;
using System.Net;
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
                try
                {
                    var result = ContactRepositoryInstance.AddContact(
                        AutoMapper.Mapper.
                        Map<Contact, Contacts.Model.Contact>(contact)
                        );
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.Created, result);
                }
                catch(Exception exception)
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
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("request is empty")),
                    ReasonPhrase = "invalid request"
                };
                throw new HttpResponseException(resp);
            }            
        }
    }
}
