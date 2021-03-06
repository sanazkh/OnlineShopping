﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webprojectdbModel;

public partial class Homepage : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    NewProductsList npl = new NewProductsList();
    protected void Page_Load(object sender, EventArgs e)
    {
        

        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
        GridView2.DataSource = npl.top20newproductsByDate();
        GridView2.DataBind();

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
        if(Session["ID"] != null)
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

    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
}