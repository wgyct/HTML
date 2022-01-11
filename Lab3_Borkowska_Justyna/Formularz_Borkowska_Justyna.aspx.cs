using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab1_Borkowska_Justyna
{
    public partial class Formularz_Borkowska_Justyna : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            String jb_tekst = TextBox1.Text;
            Label4.Text = jb_tekst;
            Label4.DataBind();

        }

        public void wyswietl ()
        {

            SqlConnection conn;
            string connetionString;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlCommand comand;
            SqlDataReader read;
            string czytaj = "select [Rozmiar] from [Table] where [Id] ='" + (int)Session["id"] + "'";
            comand = new SqlCommand(czytaj, conn);
            read = comand.ExecuteReader();
            read.Read();
            int wynik = (int)read.GetValue(0);
            read.Close();
            roz2.Text = wynik.ToString();

            string czytaj2 = "select [Polozenie] from [Table] where [Id] ='" + (int)Session["id"] + "'";
            comand = new SqlCommand(czytaj2, conn);
            read = comand.ExecuteReader();
            read.Read();
            int wynik2 = (int)read.GetValue(0);
            read.Close();
            ukl2.Text = wynik2.ToString();

            string czytaj3 = "select [Data] from [Table] where [Id] ='" + (int)Session["id"] + "'";
            comand = new SqlCommand(czytaj3, conn);
            read = comand.ExecuteReader();
            read.Read();
            string wynik3 = (string)read.GetValue(0);
            read.Close();
            data2.Text = wynik3;

            string czytaj4 = "select [Godzina] from [Table] where [Id] ='" + (int)Session["id"] + "'";
            comand = new SqlCommand(czytaj4, conn);
            read = comand.ExecuteReader();
            read.Read();
            string wynik4 = (string)read.GetValue(0);
            read.Close();
            godzina2.Text = wynik4;

            string czytaj6 = "select count (*) from [Table]";
            comand = new SqlCommand(czytaj6, conn);
            read = comand.ExecuteReader();
            read.Read();
            int wynik6 = (int)read.GetValue(0);
            read.Close();
            uzyt4.Text = wynik6.ToString();


            string czytaj5 = "select count (*) from [Table] where [Godzina] = '" + "0" + "'";
            comand = new SqlCommand(czytaj5, conn);
            read = comand.ExecuteReader();
            read.Read();
            int wynik5 = (int)read.GetValue(0);
            read.Close();
            int wynik7 = wynik6 - wynik5;
            uzyt2.Text = wynik7.ToString();

            if (wynik6 > 0)
            {
                for (int i = 1; i <= wynik6; i++)
                {
                    string czytaj7 = "select [User] from [Table] where [Id] ='" + i + "' and not [Godzina] = '" + "0" + "'";
                    comand = new SqlCommand(czytaj7, conn);
                    read = comand.ExecuteReader();
                    read.Read();
                    try
                    {
                        string wynik8 = (string)read.GetValue(0);
                        read.Close();
                        DropDownList2.Items.Add(wynik8);
                    }
                    catch (System.InvalidOperationException)
                    {
                        read.Close();
                    }
                }
            }

            conn.Close();
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            ExV2.Visible = false;
            ExV2.ValidationExpression = ExV1.ValidationExpression;

            String jb_tekst = TextBox1.Text;
            ArrayList lista2 = (ArrayList)Application["lista"];
            int jb_jest = -1;
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string jb_baza = "select [Id] from [Table] where [User] ='" + jb_tekst + "'";
            SqlCommand comand2;
            SqlDataReader read2;
            comand2 = new SqlCommand(jb_baza, conn);
            read2 = comand2.ExecuteReader();
            read2.Read();
            try 
            { 
                jb_jest = (int)read2.GetValue(0);
                read2.Close();
            }
            catch (System.InvalidOperationException)
            {
                read2.Close();
                jb_jest = -1;
            }

            if (jb_jest == -1)
            {
                string sql = "select count (*) from [Table]";
                SqlCommand comand;
                SqlDataReader read;
                comand = new SqlCommand(sql, conn);
                read = comand.ExecuteReader();
                read.Read();
                int id = (int)read.GetValue(0);
                read.Close();
                id++;
                string ins = "insert into [Table] ([Id], [User], [Rozmiar], [Polozenie], [Godzina], [Data]) values ('" + id + "','" + jb_tekst + "','" + 0 + "','" + 0 + "','" + DateTime.Now.ToString("H:mm")+ "','" + DateTime.Now.ToString("dd-MM-yyyy")  +"')";
                adapter.InsertCommand = new SqlCommand(ins, conn);
                adapter.InsertCommand.ExecuteNonQuery();

                Session["id"] = id;

                wyswietl();
                

                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            else
            {
                Session["id"] = jb_jest;
                string jb_baza2 = "select [Godzina] from [Table] where [Id] ='" + (int)Session["id"] + "'";
                SqlCommand comand3;
                SqlDataReader read3;
                comand3 = new SqlCommand(jb_baza2, conn);
                read3 = comand3.ExecuteReader();
                read3.Read();
                String log = (string)read3.GetValue(0);
                read3.Close();
                if (log == "0")
                { 
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    string godz = DateTime.Now.ToString("H:mm");
                    string upd = "update [Table] set [Godzina] ='" + godz + "' where [Id] ='" + (int)Session["id"] + "'";
                    adapter.UpdateCommand = new SqlCommand(upd, conn);
                    adapter.UpdateCommand.ExecuteNonQuery();

                    string data = DateTime.Now.ToString("dd-MM-yyyy");
                    string upd2 = "update [Table] set [Data] ='" + data + "' where [Id] ='" + (int)Session["id"] + "'";
                    adapter.UpdateCommand = new SqlCommand(upd2, conn);
                    adapter.UpdateCommand.ExecuteNonQuery();


                    wyswietl();
                }
                else
                {
                    ExV2.Visible = true;
                    ExV2.ValidationExpression = "^$";
                }
            }

            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string jb_baza = "select [User] from [Table] where [Id] ='" + (int)Session["id"] + "'";
            SqlCommand comand2;
            SqlDataReader read2;
            comand2 = new SqlCommand(jb_baza, conn);
            read2 = comand2.ExecuteReader();
            read2.Read();
            string jb_user = (string)read2.GetValue(0);
            read2.Close();
            string sql = "select [Polozenie] from [Table] where [User] ='" + jb_user +"'";
            SqlCommand comand;
            SqlDataReader read;
            comand = new SqlCommand(sql, conn);
            read = comand.ExecuteReader();
            read.Read();
            int jb_nukl = (int)read.GetValue(0);
            read.Close();
            jb_nukl++;
            string upd = "update [Table] set [Polozenie] = " + jb_nukl + "where [Id] ='" + (int)Session["id"] + "'";
            adapter.UpdateCommand = new SqlCommand(upd, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
            ukl2.Text = jb_nukl.ToString();

            if (((DropDownList)sender).SelectedValue == "1")
            {
                Image1.Style.Add("transform", "translate(0%,0%)");
                Image2.Style.Add("transform", "translate(600%,0%)");
                Image3.Style.Add("transform", "translate(500%,600%)");
                Image4.Style.Add("transform", "translate(-320%,600%)");
                Image5.Style.Add("transform", "translate(-85%,300%)");

            }
            if (((DropDownList)sender).SelectedValue == "2")
            {
                Image1.Style.Add("transform", "translate(0%,0%)");
                Image2.Style.Add("transform", "translate(100%,100%)");
                Image3.Style.Add("transform", "translate(200%,200%)");
                Image4.Style.Add("transform", "translate(300%,300%)");
                Image5.Style.Add("transform", "translate(400%,400%)");
            }
            if (((DropDownList)sender).SelectedValue == "3")
            {
                Image1.Style.Add("transform", "translate(800%,0%)");
                Image2.Style.Add("transform", "translate(500%,100%)");
                Image3.Style.Add("transform", "translate(200%,200%)");
                Image4.Style.Add("transform", "translate(-100%,300%)");
                Image5.Style.Add("transform", "translate(-400%,400%)");
            }
            if (((DropDownList)sender).SelectedValue == "4")
            {
                Image1.Style.Add("transform", "translate(0%,300%)");
                Image2.Style.Add("transform", "translate(200%,300%)");
                Image3.Style.Add("transform", "translate(400%,300%)");
                Image4.Style.Add("transform", "translate(600%,300%)");
                Image5.Style.Add("transform", "translate(800%,300%)");
            }
            if (((DropDownList)sender).SelectedValue == "5")
            {
                
                Image1.Style.Add("transform", "translate(200%,0%)");
                Image2.Style.Add("transform", "translate(95%,200%)");
                Image3.Style.Add("transform", "translate(-10%,400%)");
                Image4.Style.Add("transform", "translate(-115%,600%)");
                Image5.Style.Add("transform", "translate(-220%,800%)");
            }
            DropDownList2.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string jb_baza = "select [User] from [Table] where [Id] ='" + (int)Session["id"] + "'";
            SqlCommand comand2;
            SqlDataReader read2;
            comand2 = new SqlCommand(jb_baza, conn);
            read2 = comand2.ExecuteReader();
            read2.Read();
            string jb_user = (string)read2.GetValue(0);
            read2.Close();
            string sql = "select [Rozmiar] from [Table] where [User] ='" + jb_user + "'";
            SqlCommand comand;
            SqlDataReader read;
            comand = new SqlCommand(sql, conn);
            read = comand.ExecuteReader();
            read.Read();
            int jb_nroz = (int)read.GetValue(0);
            read.Close();
            jb_nroz++;
            string upd = "update [Table] set [Rozmiar] = " + jb_nroz + "where [Id] ='" + (int)Session["id"] + "'";
            adapter.UpdateCommand = new SqlCommand(upd, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
            roz2.Text = jb_nroz.ToString();

            if (((RadioButtonList)sender).SelectedValue == "1") {
                Image1.Height = 30; Image1.Width = 30;
                Image2.Height = 30; Image2.Width = 30;
                Image3.Height = 30; Image3.Width = 30;
                Image4.Height = 30; Image4.Width = 30;
                Image5.Height = 30; Image5.Width = 30;

            }
            if (((RadioButtonList)sender).SelectedValue == "2")
            {
                Image1.Height = 45; Image1.Width = 45;
                Image2.Height = 45; Image2.Width = 45;
                Image3.Height = 45; Image3.Width = 45;
                Image4.Height = 45; Image4.Width = 45;
                Image5.Height = 45; Image5.Width = 45;

            }
            if (((RadioButtonList)sender).SelectedValue == "3")
            {
                Image1.Height = 60; Image1.Width = 60;
                Image2.Height = 60; Image2.Width = 60;
                Image3.Height = 60; Image3.Width = 60;
                Image4.Height = 60; Image4.Width = 60;
                Image5.Height = 60; Image5.Width = 60;

            }
            DropDownList2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string lista = DropDownList2.SelectedItem.Text;

            SqlConnection conn;
            string connetionString;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlCommand comand;
            SqlDataReader read;

            int jb_jest = 0;
            string jb_baza = "select [Id] from [Table] where [User] ='" + lista + "'";
            SqlCommand comand2;
            SqlDataReader read2;
            comand2 = new SqlCommand(jb_baza, conn);
            read2 = comand2.ExecuteReader();
            read2.Read();
            try
            {
                jb_jest = (int)read2.GetValue(0);
                read2.Close();
            }
            catch (System.InvalidOperationException)
            {
                read2.Close();
                jb_jest = -1;
            }

            if (jb_jest != -1)
            {
                string czytaj = "select [Rozmiar] from [Table] where [Id] ='" + jb_jest + "'";
                comand = new SqlCommand(czytaj, conn);
                read = comand.ExecuteReader();
                read.Read();
                int wynik = (int)read.GetValue(0);
                read.Close();
                roz2.Text = wynik.ToString();

                string czytaj2 = "select [Polozenie] from [Table] where [Id] ='" + jb_jest + "'";
                comand = new SqlCommand(czytaj2, conn);
                read = comand.ExecuteReader();
                read.Read();
                int wynik2 = (int)read.GetValue(0);
                read.Close();
                ukl2.Text = wynik2.ToString();

                string czytaj3 = "select [Data] from [Table] where [Id] ='" + jb_jest + "'";
                comand = new SqlCommand(czytaj3, conn);
                read = comand.ExecuteReader();
                read.Read();
                string wynik3 = (string)read.GetValue(0);
                read.Close();
                data2.Text = wynik3;

                string czytaj4 = "select [Godzina] from [Table] where [Id] ='" + jb_jest + "'";
                comand = new SqlCommand(czytaj4, conn);
                read = comand.ExecuteReader();
                read.Read();
                string wynik4 = (string)read.GetValue(0);
                read.Close();
                godzina2.Text = wynik4;

                string czytaj6 = "select count (*) from [Table]";
                comand = new SqlCommand(czytaj6, conn);
                read = comand.ExecuteReader();
                read.Read();
                int wynik6 = (int)read.GetValue(0);
                read.Close();
                uzyt4.Text = wynik6.ToString();


                string czytaj5 = "select count (*) from [Table] where [Godzina] = '" + "0" + "'";
                comand = new SqlCommand(czytaj5, conn);
                read = comand.ExecuteReader();
                read.Read();
                int wynik5 = (int)read.GetValue(0);
                read.Close();
                int wynik7 = wynik6 - wynik5;
                uzyt2.Text = wynik7.ToString();

            }
            

            conn.Close();

        }


        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();

            SqlConnection conn;
            string connetionString;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();
            SqlCommand comand;
            SqlDataReader read;

            string czytaj6 = "select count (*) from [Table]";
            comand = new SqlCommand(czytaj6, conn);
            read = comand.ExecuteReader();
            read.Read();
            int wynik6 = (int)read.GetValue(0);
            read.Close();
            uzyt4.Text = wynik6.ToString();


            string czytaj5 = "select count (*) from [Table] where [Godzina] = '" + "0" + "'";
            comand = new SqlCommand(czytaj5, conn);
            read = comand.ExecuteReader();
            read.Read();
            int wynik5 = (int)read.GetValue(0);
            read.Close();
            int wynik7 = wynik6 - wynik5;
            uzyt2.Text = wynik7.ToString();

            for (int i=1; i<=wynik6; i++)
            {
                string czyt = "select [User] from [Table] where [Id] ='" + i + "' and not [Godzina] = '" + "0" + "'";
                comand = new SqlCommand(czyt, conn);
                read = comand.ExecuteReader();
                read.Read();
                try
                {
                    string wynik8 = (string)read.GetValue(0);
                    read.Close();
                    DropDownList2.Items.Add(wynik8);
                }
                catch (System.InvalidOperationException)
                {
                    read.Close();
                }

                string czytaj = "select [Rozmiar] from [Table] where [Id] ='" + i + "'";
                comand = new SqlCommand(czytaj, conn);
                read = comand.ExecuteReader();
                read.Read();
                int wynik = (int)read.GetValue(0);
                read.Close();
                roz2.Text = wynik.ToString();

                string czytaj2 = "select [Polozenie] from [Table] where [Id] ='" + i + "'";
                comand = new SqlCommand(czytaj2, conn);
                read = comand.ExecuteReader();
                read.Read();
                int wynik2 = (int)read.GetValue(0);
                read.Close();
                ukl2.Text = wynik2.ToString();

                string czytaj3 = "select [Data] from [Table] where [Id] ='" + i + "'";
                comand = new SqlCommand(czytaj3, conn);
                read = comand.ExecuteReader();
                read.Read();
                string wynik3 = (string)read.GetValue(0);
                read.Close();
                data2.Text = wynik3;

                string czytaj4 = "select [Godzina] from [Table] where [Id] ='" + i + "'";
                comand = new SqlCommand(czytaj4, conn);
                read = comand.ExecuteReader();
                read.Read();
                string wynik4 = (string)read.GetValue(0);
                read.Close();
                godzina2.Text = wynik4;
             }


            conn.Close();

        }
    }
}