using System;
using System.Net;
using System.Net.Http;
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
            try
            {
                var contact = ContactRepositoryInstance.GetContact(emailId);
                if (contact != null)
                {
                    var result = AutoMapper.Mapper.
                            Map<Model.Contact, Contact>
                            (contact);

                    return Ok(result);
                }
                else
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No record found for = {0}", emailId)),
                        ReasonPhrase = "EmailID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
            }
            catch(Exception exception)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("internal error for = {0}", emailId)),
                    ReasonPhrase = exception.Message
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
