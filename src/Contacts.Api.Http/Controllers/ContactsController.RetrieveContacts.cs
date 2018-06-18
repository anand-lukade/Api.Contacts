using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Contacts.Api.Http
{
    public partial class ContactsController
    {
        [HttpGet]
        
        [Route("~/contacts", Name = "RetrieveContacts")]
        public IHttpActionResult RetrieveContacts(int page=1, int pageSize=10)
        {
            int totalRecords;
            var contacts = AutoMapper.Mapper.
                    Map<List<Contacts.Model.Contact>, List<Contact>>
                    (ContactRepositoryInstance.GetContacts(page, pageSize, out totalRecords));

            var result = new ResourceCollection<Contact>()
            {
                Items= contacts,
                Page=page,
                PageSize=pageSize,
                TotalItems=totalRecords,
                TotalPages= Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalRecords) / pageSize))                
            };                       
            return Ok(result);
        }
    }
}
