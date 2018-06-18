using Contacts.Api.Http;
using Contacts.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Contacts.Api.Test
{
    [TestClass]
    public class RetrieveContact_Test
    {
        [TestMethod]
        [TestCategory(TestCategory.UnitTest)]
        public void RetrieveContact_Test_Result()
        {
            var repositoryMoq = new Moq.Mock<IContactRepository>();
            var contact = new Model.Contact()
            {
                Email = "anand.lukade@gmail.com",
                FirstName = "anand",
                LastName = "lukade",
                PhoneNumber = "8007891986",
                Status = Model.Status.Active
            };    
            repositoryMoq.Setup(s=>s.GetContact("anand.lukade@gmail.com")).Returns(contact);            
            var controller = new ContactsController(repositoryMoq.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(
                    String.Format("http://localhost/contacts?emailId={0}/contact", 
                    "anand.lukade@gmail.com"))
            };

           
            IHttpActionResult actionResult = controller.RetrieveContact("anand.lukade@gmail.com");
             var contentResult = actionResult as OkNegotiatedContentResult<Http.Contact>;
            Assert.AreEqual(contact.Email, contentResult.Content.Email);            
        }
        [TestMethod]
        [TestCategory(TestCategory.UnitTest)]
        public void RetrieveContact_NoData_Result()
        {
            var repositoryMoq = new Moq.Mock<IContactRepository>();
            var result = new Model.Contact();
            repositoryMoq.Setup(s => s.GetContact("anand.lukade27@gmail.com"));
            var controller = new ContactsController(repositoryMoq.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(
                    String.Format("http://localhost/contacts?emailId={0}/contact",
                    "anand.lukade27@gmail.com"))
            };

            try
            {
                controller.RetrieveContact("anand.lukade27@gmail.com");                
            }
            catch(Exception exception)
            {
                Assert.IsTrue(exception is ArgumentException);                    
            }
        }
        [TestMethod]
        [TestCategory(TestCategory.UnitTest)]
        public void RetrieveContact_NoEmailProvided()
        {
            var repositoryMoq = new Moq.Mock<IContactRepository>();
            var result = new Model.Contact();
            repositoryMoq.Setup(s => s.GetContact(""));
            var controller = new ContactsController(repositoryMoq.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(
                    String.Format("http://localhost/contacts?emailId={0}/contact",
                    ""))
            };

            try
            {
                controller.RetrieveContact("");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is ArgumentException);
            }
        }
    }
}
