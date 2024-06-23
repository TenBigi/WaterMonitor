﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WaterMonitor.Data;
using WaterMonitor.Data.Model;

namespace WaterMonitor.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TokenAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            var recievedToken = context.HttpContext.Request.Headers["Security-Token"].FirstOrDefault();

            if (!dbContext.Configuration.Any(x => x.Value == recievedToken) || string.IsNullOrEmpty(recievedToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
