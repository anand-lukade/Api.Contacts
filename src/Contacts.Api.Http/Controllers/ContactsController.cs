using Contacts.Interface;
using Contacts.Repository;
using System;
using System.Net;
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
                throw new ArgumentNullException($"{key} is required");
            }
        }
        private void ValidateEmail(string email)
        {            
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
                throw new ArgumentException("invalid email");
        }
    }
}
