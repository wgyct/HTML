using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.aWAT\5S\HTML\lab\lab3\Lab3_Borkowska_Justyna\App_Data\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            conn.Close();
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
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string upd = "update [Table] set [Godzina] = '0' where [Id] ='" + (int)Session["id"] + "'";
            adapter.UpdateCommand = new SqlCommand(upd, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            string upd2 = "update [Table] set [Godzina] = '0' where [Id] ='" + 4 + "'";
            adapter.UpdateCommand = new SqlCommand(upd2, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}