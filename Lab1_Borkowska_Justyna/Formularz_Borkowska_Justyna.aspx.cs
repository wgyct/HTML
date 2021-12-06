using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1_Borkowska_Justyna
{
    public partial class Formularz_Borkowska_Justyna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
    }
}