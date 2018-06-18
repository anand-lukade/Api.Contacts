using System;
using System.Net;
using System.Web.Http;

namespace Contacts.Api.Http
{
    public partial class ContactsController
    {
        [HttpDelete]
        [Route("~/contacts/{emailId}", Name = "RemoveContact")]
        
        public IHttpActionResult RemoveContact(string emailId)
        {
            Validate("emailId", emailId);
            ValidateEmail(emailId);
            ContactRepositoryInstance.RemoveContact(emailId);            
            return Ok();
        }
    }
}
