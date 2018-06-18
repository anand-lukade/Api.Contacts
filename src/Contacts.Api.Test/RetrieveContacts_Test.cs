using Contacts.Api.Http;
using Contacts.Interface;
using Contacts.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Contacts.Api.Test
{
    [TestClass]
    public class RetrieveContacts_Test
    {
        [TestMethod]
        [TestCategory(TestCategory.UnitTest)]
        public void RetrieveContacts_Test_Result()
        {
            var repositoryMoq = new Moq.Mock<IContactRepository>();
            var list = new List<Model.Contact>()
            {
               new Model.Contact()
                {
                    EmailId = "anand.lukade@gmail.com",
                    FirstName = "anand",
                    LastName="lukade",
                    PhoneNumber="8007891986",
                    Status=true
                },
                new Model.Contact()
                {
                    EmailId = "prasad.khandat@gmail.com",
                    FirstName = "prasad",
                    LastName="khandat",
                    PhoneNumber="8007691986",
                    Status=true
                }
            };
            int totalRecord;
            repositoryMoq.Setup(s=>s.GetContacts(1,2, out totalRecord)).Returns(list);            
            var controller = new ContactsController(repositoryMoq.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(
                    String.Format("http://localhost/contacts?page={0}&pageSize={1}",                    
                    1,
                    10))
            };

           
            IHttpActionResult actionResult = controller.RetrieveContacts(1,2);
             var contentResult = actionResult as OkNegotiatedContentResult<ResourceCollection<Http.Contact>>;
            Assert.AreEqual(list[0].EmailId, contentResult.Content.Items[0].EmailId);            
        }
    }
}
