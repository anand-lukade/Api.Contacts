using Contacts.Api.Http;
using Contacts.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Contacts.Api.Test
{
    [TestClass]
    public class RetrieveContact_EditContact_Test
    {
        [TestMethod]
        [TestCategory(TestCategory.UnitTest)]
        public void EditContact_Success()
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
                Status = false
            };
            repositoryMoq.Setup(s=>s.EditContact("arlukade@gmail.com", contact)).Returns(contact);            
            var controller = new ContactsController(repositoryMoq.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(String.Format("http://localhost/contacts/emailId={0}/contact","arlukade@gmail.com"))
            };

            controller.Configuration = new HttpConfiguration();

            var iroute = new System.Web.Http.Routing.HttpRoute();
            var content = new System.Web.Http.Controllers.HttpRequestContext();

            content.RouteData = new System.Web.Http.Routing.HttpRouteData(iroute);

            controller.Request.SetRouteData(content.RouteData);

            controller.Configuration.Routes.MapHttpRoute(
                name: "AddContact",
                routeTemplate: "api/contacts/emailId={0}");
            var result = controller.EditContact("arlukade@gmail.com", contactRequest);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.Accepted);
        }
    }
}
