using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi_Microservices_Docker
{
    public class CustomAuthorize:ActionFilterAttribute
    {
        public CustomAuthorize():base()
        {

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            bool isAuthorized = false;

            if (headers.Keys.Contains("auth_key"))
            {
                var header = headers.FirstOrDefault(x => x.Key == "auth_key").Value.FirstOrDefault();
                if(header!=null)
                {
                    isAuthorized = string.Equals(header,"core");
                }
            }
            if (!isAuthorized)
            {
                context.Result = new ContentResult() {
                    Content="Authorization has been denied !!",
                    ContentType = "text/plain",
                    StatusCode=401
                };

            }
        }
    }
}
