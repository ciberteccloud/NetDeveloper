using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.App_Code
{
    public class BasePage : System.Web.UI.Page
    {
        protected static UnitOfWork _unit;
        public BasePage()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void IsUserInRole(string role)
        {
            if (!HttpContext.Current.User.IsInRole(role))
                RedirectToLogin();
        }

        protected void VerifyUser()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                RedirectToLogin();
        }

        private void RedirectToLogin()
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}