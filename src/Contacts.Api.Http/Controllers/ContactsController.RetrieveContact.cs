using System;
using System.Web.Http;

namespace Contacts.Api.Http
{
    public partial class ContactsController
    {
        [HttpGet]
        [Route("~/contacts/{emailId}/contact", Name = "RetrieveContact")]        
        public IHttpActionResult RetrieveContact(string emailId)
        {
            Validate("emailId", emailId);
            ValidateEmail(emailId);

            var contact = ContactRepositoryInstance.GetContact(emailId);
            if (contact != null)
            {
                var result = AutoMapper.Mapper.
                        Map<Contacts.Model.Contact, Contact>
                        (contact);

                return Ok(result);
            }
            else
            {
                throw new ArgumentException($"No record found for {emailId}");
            }
        }
    }
}
