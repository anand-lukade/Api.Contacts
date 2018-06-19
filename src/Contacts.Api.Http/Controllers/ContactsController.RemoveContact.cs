using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Http
{
    public partial class ContactsController
    {
        [HttpDelete]
        [Route("~/contacts/{emailId}", Name = "RemoveContact")]
        
        public void RemoveContact(string emailId)
        {
            Validate("emailId", emailId);
            ValidateEmail(emailId);
            try
            {
                ContactRepositoryInstance.RemoveContact(emailId);
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
    }
}
