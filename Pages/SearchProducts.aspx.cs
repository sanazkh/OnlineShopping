﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SearchProducts : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    SearchProduct sp = new SearchProduct();
    protected void Page_Load(object sender, EventArgs e)
    {


        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
        GridView2.DataSource = sp.showAllProduct();
        GridView2.DataBind();
        RadioButton1.Checked = true;
        Label6.Text = "در زیر لیست کلیّۀ محصولات را می بینید.";
        Label6.Visible = true;

    }

    protected void Login_Click(object sender, EventArgs e)
    {
        string userName = UserName.Text;
        string password = Password.Text;
        webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
        var result = from User in webproject.Users
                     where User.UserName == userName
                     && User.PassWord == password
                     select User;

        if (result.Count() > 0)
        {
            webprojectdbModel.User user = (webprojectdbModel.User)result.First();

            if (user.IsActive)
            {
                Session["Username"] = user.UserName.ToString();
                Session["RoleID"] = user.RoleID.ToString();
                Session["ID"] = user.UserID.ToString();
                Session["Name"] = user.FirstName.ToString();
                Session["LastName"] = user.LastName.ToString();
                if (user.RoleID == 3)
                    Response.Redirect("HomeAfterLogin.aspx");
                else
                    Response.Redirect("~/admin/ManageUsers.aspx");
            }
            else
            {
                Label4.Text = "حساب شما فعال نیست.";
                Label4.Visible = true;
            }
        }
        else
        {
            Label4.Text = "اطلاعات وارد شده صحیح نمی باشد.";
            Label4.Visible = true;

        }

    }


    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("HomeAfterLogin.aspx");
        else
            Response.Redirect("HomePage.aspx");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("CategoriesAfterLogin.aspx");
        else
            Response.Redirect("Categories.aspx");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("AboutUsAfterLogin.aspx");
        else
            Response.Redirect("AboutUs.aspx");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("ContactUsAfterLogin.aspx");
        else
            Response.Redirect("ContactUs.aspx");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("RegistrationAfterLogin.aspx");
        else
            Response.Redirect("Registration.aspx");
    }
 
    protected void ButtonList_Click(object sender, EventArgs e)
    {
        if (!TextBox1.Text.Equals(""))
        {
            if (RadioButton1.Checked)
            {

                string name = TextBox1.Text;
                GridView2.DataSource = sp.showProductByName(name);
                GridView2.DataBind();
                GridView2.Visible = true;
                Label6.Visible = false;
                
            }
            if (RadioButton2.Checked)
            {

                try
                {

                    double price = Convert.ToDouble(TextBox1.Text);

                    if (DropDownList1.SelectedIndex == 0)
                    {
                        GridView2.DataSource = sp.ShowProductByPriceMore(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        Label6.Visible = false;
                    }
                    else if (DropDownList1.SelectedIndex == 1)
                    {
                        GridView2.DataSource = sp.ShowProductByPriceEqual(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        Label6.Visible = false;
                    }
                    else if (DropDownList1.SelectedIndex == 2)
                    {
                        GridView2.DataSource = sp.ShowProductByPriceLess(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        Label6.Visible = false;
                    }
                    
                }
                catch
                {
                    GridView2.Visible = false;
                    Label6.Text = "در کادر خالی باید عدد وارد کنید.";
                    Label6.Visible = true;
                }

            }
        }
        else
        {
            GridView2.Visible = false;
            Label6.Text = "کادر خالی پر کنید.";
            Label6.Visible = true;

        }
    }

    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
}