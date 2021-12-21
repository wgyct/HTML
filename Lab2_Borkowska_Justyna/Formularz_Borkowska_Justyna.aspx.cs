using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1_Borkowska_Justyna
{
    public class Jb_Uzytkownicy
    {
        public String jb_nazwa;
        static DateTime jb_data = DateTime.Now;
        public String jb_dzien = jb_data.ToString("dd-MM-yyyy");
        public String jb_teraz = jb_data.ToString("H:mm");
        public int jb_ukl = 0;
        public int jb_roz = 0;
        public Jb_Uzytkownicy(String s)
        {
            this.jb_nazwa = s;
        }
        
        public String GetNazwa()
        {
            return jb_nazwa;
        }
        public int GetUkl()
        {
            jb_ukl++;
            return jb_ukl;
        }
        public int GetRoz()
        {
            jb_roz++;
            return jb_roz;
        }
        public int GetUkl2()
        {
            return jb_ukl;
        }
        public int GetRoz2()
        {
            return jb_roz;
        }
        public String GetDzien()
        {
            return jb_dzien;
        }
        public String GetTeraz()
        {
            return jb_teraz;
        }

    }
    
    public partial class Formularz_Borkowska_Justyna : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            String jb_tekst = TextBox1.Text;
            Label4.Text = jb_tekst;
            Label4.DataBind();

            if (Session["uzytkownicy"] != null)
            {
              uzyt2.Text = Session["uzytkownicy"].ToString();
            }
            if (Session["pom_ukl"] != null)
            {
               ukl2.Text = Session["pom_ukl"].ToString();
            }

            if (Session["pom_roz"] != null)
            {
               roz2.Text = Session["pom_roz"].ToString();
            }

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            ExV2.Visible = false;
            ExV2.ValidationExpression = ExV1.ValidationExpression;

            String jb_tekst = TextBox1.Text;
            ArrayList lista2 = (ArrayList)Application["lista"];
            
            int jb_pom = 0;
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                if (jb_uzytkow.GetNazwa() == jb_tekst)
                {
                    jb_pom++;
                }
            }
            if (jb_pom == 0)
            {
                Jb_Uzytkownicy jb_uzytk = new Jb_Uzytkownicy(jb_tekst);
                lista2.Add(jb_uzytk);
                if (Session["dzien2"] != null)
                {
                    Session["dzien2"] = jb_uzytk.GetDzien();
                }
                if (Session["teraz2"] != null)
                {
                    Session["teraz2"] = jb_uzytk.GetTeraz();
                }
                Session["pom_roz"] = jb_uzytk.GetRoz2();
                roz2.Text = Session["pom_roz"].ToString();
                Session["pom_ukl"] = jb_uzytk.GetUkl2();
                ukl2.Text = Session["pom_ukl"].ToString();
                Session["dzien2"] = jb_uzytk.GetDzien();
                data2.Text = Session["dzien2"].ToString();
                Session["teraz2"] = jb_uzytk.GetTeraz();
                godzina2.Text = Session["teraz2"].ToString();

                foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
                {
                    DropDownList2.Items.Add(jb_uzytkow.jb_nazwa);
                }

                if (Session["uzytkownicy"] != null)
                {
                    Session["uzytkownicy"] = ((int)Session["uzytkownicy"]) + 1;
                }
                uzyt2.Text = Session["uzytkownicy"].ToString();

                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            else
            {
                ExV2.Visible = true;
                ExV2.ValidationExpression = "^$";
            }

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
            ArrayList lista2 = (ArrayList)Application["lista"];
            String jb_tekst = TextBox1.Text;
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                if (jb_uzytkow.GetNazwa() == jb_tekst)
                {
                    if (Session["pom_ukl"] != null)
                    {
                        Session["pom_ukl"] = jb_uzytkow.GetUkl();
                    }
                    ukl2.Text = Session["pom_ukl"].ToString();
                }
            }

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
            DropDownList2.Items.Clear();
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                DropDownList2.Items.Add(jb_uzytkow.jb_nazwa);
            }
            DropDownList2.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList lista2 = (ArrayList)Application["lista"];
            String jb_tekst = TextBox1.Text;
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                if (jb_uzytkow.GetNazwa() == jb_tekst)
                {
                    if (Session["pom_roz"] != null)
                    {
                        Session["pom_roz"] = jb_uzytkow.GetRoz();
                    }
                    roz2.Text = Session["pom_roz"].ToString();
                }
            }
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
            DropDownList2.Items.Clear();
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                DropDownList2.Items.Add(jb_uzytkow.jb_nazwa);
            }
            DropDownList2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged2(object sender, EventArgs e)
        {
            ArrayList lista2 = (ArrayList)Application["lista"];
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                if (DropDownList2.SelectedItem.Text == jb_uzytkow.GetNazwa())
                {
                    data2.Text = jb_uzytkow.GetDzien();
                    godzina2.Text = jb_uzytkow.GetTeraz();
                    ukl2.Text =  jb_uzytkow.GetUkl2().ToString();
                    roz2.Text = jb_uzytkow.GetRoz2().ToString();
                    break;
                }
                else
                {
                    data2.Text = "0";
                    godzina2.Text = "0";
                }

            }
        }


            protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ArrayList lista2 = (ArrayList)Application["lista"]; 
            DropDownList2.Items.Clear();
            foreach (Jb_Uzytkownicy jb_uzytkow in lista2)
            {
                DropDownList2.Items.Add(jb_uzytkow.jb_nazwa);
                ukl2.Text = jb_uzytkow.GetUkl2().ToString();
                roz2.Text = jb_uzytkow.GetRoz2().ToString();
            }
            uzyt2.Text = Session["uzytkownicy"].ToString();

        }
    }
}