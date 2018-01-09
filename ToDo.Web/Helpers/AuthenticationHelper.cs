using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ToDo.Web.Helpers
{
    public class AuthenticationHelper
    {
       
        private readonly IAuthenticationManager _auth;

        public AuthenticationHelper(IAuthenticationManager auth)
        {
            _auth = auth;
        }
        public AuthenticationHelper()
        {
            var auth = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            _auth = auth;
        }
        
        public void Login(Guid userId,string lastName, bool rememberMe = false)
        {
           
           
            var claims = new List<Claim> {
                                        new Claim(ClaimTypes.Name,lastName),
                                        new Claim(ClaimTypes.PrimarySid,userId.ToString()),
                                    
                                         };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            this._auth.SignIn(new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.UtcNow.AddHours(1),

            }, identity);
        }

        public void Logout()
        {
            this._auth.SignOut();
        }


        public Guid GetUserId()
        {
            Guid userId=new Guid();
            var identity = _auth.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var dataClaim = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.PrimarySid);

                if (dataClaim != null)
                {
                    Guid.TryParse( dataClaim.Value, out userId);
                }
            }
            return userId;

        }
       
      
    }
}