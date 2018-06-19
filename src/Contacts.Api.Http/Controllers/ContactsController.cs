using Contacts.Interface;
using Contacts.Repository;
using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Contacts.Api.Http
{
    [RoutePrefix("api/contact")]    
    public partial class ContactsController : ApiController
    {
        public IContactRepository ContactRepositoryInstance;

        public ContactsController()
        {
            ContactRepositoryInstance = new ContactRepository();
        }
        static ContactsController()
        {
            AutoMapper.AutoMapClasses();
        }
        public ContactsController(IContactRepository contactRepository)
        {
            ContactRepositoryInstance = contactRepository;
        }
        private void Validate(string key, string value)
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("invalid = {0}", key)),
                    ReasonPhrase = "Bad request"
                };
                throw new HttpResponseException(resp);
            }
        }
        private void ValidateEmail(string email)
        {            
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("invalid = {0}", email)),
                    ReasonPhrase = "Bad request"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
