using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Contacts.Api.Http
{
    public class ProblemResponse : ExceptionHandler
    {
        //A basic DTO to return back to the caller with data about the error
        private class ErrorInformation
        {
            public string Message { get; set; }
            public DateTime ErrorDateTime { get; set; }
        }

        public override void Handle(ExceptionHandlerContext context)
        {           
            if (context.Exception is ArgumentNullException || context.Exception is ArgumentException)
            {
                context.Result = new ResponseMessageResult(
                    context.Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        new ErrorInformation
                        {
                            Message = context.Exception.Message,
                            ErrorDateTime = DateTime.UtcNow
                        }));
            }
            
            if (context.Exception is ApplicationException || context.Exception is Exception)
            {
                context.Result = new ResponseMessageResult(
                context.Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new ErrorInformation
                    {
                        Message = context.Exception.Message,
                        ErrorDateTime = DateTime.UtcNow
                    }));
            }            
        }
        
    }
}