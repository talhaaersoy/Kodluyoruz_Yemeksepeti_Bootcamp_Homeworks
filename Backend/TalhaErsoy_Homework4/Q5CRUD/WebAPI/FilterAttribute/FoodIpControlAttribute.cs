using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace WebAPI.FilterAttribute
{
    public class FoodIpControlAttribute : ActionFilterAttribute
    {
        private IConfiguration _configuration;

        public FoodIpControlAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            IPAddress remoteIp = context.HttpContext.Connection.RemoteIpAddress;

            var ips = _configuration.GetSection("WhiteListFood").AsEnumerable()
                .Where(ip => !string.IsNullOrEmpty(ip.Value)).Select(ip => ip.Value).ToList();


            if (!ips.Where(ip => IPAddress.Parse(ip).Equals(remoteIp)).Any())
            {

                context.Result = new StatusCodeResult((int) HttpStatusCode.Forbidden);
                return;
            }

            base.OnActionExecuting(context);
        }

    }
}