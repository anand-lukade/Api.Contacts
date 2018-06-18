using Contacts.Api.Http;
using Contacts.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Test
{
    [TestClass]
    public class RetrieveContact_AddContact_Test
    {
        [TestMethod]
        [TestCategory(TestCategory.UnitTest)]
        public void AddContact_Success()
        {
            var repositoryMoq = new Moq.Mock<IContactRepository>();
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            var contactRequest = new Contact()
            {
                EmailId = "anand.lukade@gmail.com",
                FirstName = "anand",
                LastName = "lukade",
                PhoneNumber = "8007891986",
                Status = true
            };
            var contact = new Model.Contact()
            {
                EmailId = "anand.lukade@gmail.com",
                FirstName = "anand",
                LastName = "lukade",
                PhoneNumber = "8007891986",
                Status = true
            };
            repositoryMoq.Setup(s=>s.AddContact(contact)).Returns(contact);            
            var controller = new ContactsController(repositoryMoq.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(String.Format("http://localhost/contacts"))
            };

            controller.Configuration = new HttpConfiguration();

            var iroute = new System.Web.Http.Routing.HttpRoute();
            var content = new System.Web.Http.Controllers.HttpRequestContext();

            content.RouteData = new System.Web.Http.Routing.HttpRouteData(iroute);

            controller.Request.SetRouteData(content.RouteData);

            controller.Configuration.Routes.MapHttpRoute(
                name: "AddContact",
                routeTemplate: "api/contacts");
            var result = controller.AddContact(contactRequest);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.Created);

        }
    }
}
