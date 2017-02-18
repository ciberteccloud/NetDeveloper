using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebForms
{
    public class Global : HttpApplication
    {
        private ILog _logger;
        public Global()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(typeof(Global));
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);            
            _logger.Debug("Logging is enabled");
            Application["Users"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["Users"] = (int)Application["Users"] + 1;
            NumberOfUsers();
        }

        protected void Session_End(object sender, EventArgs e)
        {            
            Application["Users"] = Convert.ToInt32(Application["Users"])-1;
            NumberOfUsers();
        }
        
        protected void Application_Error(Object sender, EventArgs e)
        {   
            Exception ex = Server.GetLastError();
            if (ex is ThreadAbortException)
                return;            
            _logger.Error(ex);
            Response.Redirect("http://localhost/WebForms/Error.aspx");
        }

        private void NumberOfUsers()
        {
            _logger.Info($"Number of users connected {Application["Users"]}");
        }
    }

}