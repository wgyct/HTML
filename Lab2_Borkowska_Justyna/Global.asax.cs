using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab1_Borkowska_Justyna
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["lista"] = new ArrayList();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {

            Session["uzytkownicy"] = 0;

            Session["pom_ukl"] = 0;

            Session["pom_roz"] = 0;

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}