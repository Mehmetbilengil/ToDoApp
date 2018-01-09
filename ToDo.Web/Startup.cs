using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(ToDo.Web.Startup))]
namespace ToDo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieSecure = CookieSecureOption.SameAsRequest,//TODO: this can be change to CookieSecureOption.Always on production
                CookieName = "ToDoApp_",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieHttpOnly = true,
                SlidingExpiration = true,
                //  CookieDomain="todoApp.com",
                ExpireTimeSpan = TimeSpan.FromHours(1)
            });

        }
    }
}