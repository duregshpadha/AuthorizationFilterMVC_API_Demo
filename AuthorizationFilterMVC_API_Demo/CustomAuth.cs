using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace AuthorizationFilterMVC_API_Demo
{
    public class CustomAuth : AuthorizationFilterAttribute
    {
        private const string _authorizedToken = "AuthorizedToken";
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            string authorizedToken = string.Empty;

            try
            {
                var headerToken = filterContext.Request.Headers.SingleOrDefault(x => x.Key == _authorizedToken);
                if (headerToken.Key != null)
                {
                    authorizedToken = Convert.ToString(headerToken.Value.SingleOrDefault());
                    if (!IsAuthorize(authorizedToken))
                    {
                        filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        return;
                    }
                }
                else
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    return;
                }
            }
            catch (Exception)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }

            base.OnAuthorization(filterContext);
        }


        private bool IsAuthorize(string authorizedToken)
        {
            if (authorizedToken == "12345")
                return true;
            else
                return false;
        }
    }
}