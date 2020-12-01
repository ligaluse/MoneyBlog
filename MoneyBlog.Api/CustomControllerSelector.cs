using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace MoneyBlog.Api
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;

        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor
            SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var controllerName = routeData.Values["controller"].ToString();

            

            // Comment the code that gets the version number from Query String
            //var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            //if (versionQueryString["v"] != null)
            //{
            //    versionNumber = versionQueryString["v"];
            //}

            // Get the version number from Custom version header

            //string customHeader = "X-StudentService-Version";
            //if (request.Headers.Contains(customHeader))
            //{
            //    // If X-StudentService-Version:1 is specified twice in the request
            //    // then in versionNumber variable will get a value of "1,1"
            //    versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
            //    // Check if versionNumber string contains a comma, and take only
            //    // the first number from the comma separated list of version numbers
            //    if (versionNumber.Contains(","))
            //    {
            //        versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
            //    }
            //}

            // Get the version number from the Accept header

            // Users can include multiple Accept headers in the request
            // Check if any of the Accept headers has a parameter with name version
            var acceptHeader = request.Headers.Accept;

            // If there is atleast one header with a "version" parameter
            

            HttpControllerDescriptor controllerDescriptor;
            

            return null;
        }
    }
}
