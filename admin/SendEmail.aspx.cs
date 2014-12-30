using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SendEmail : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    Users us = new Users();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["RoleID"] != null)
        {
            if (Session["RoleID"].ToString().Equals("1"))
            {
                Label2.Text = Session["Username"].ToString();
                Label4.Text = "";
            }
            else
            {
                Label2.Text = Session["Name"].ToString();
                Label4.Text = Session["LastName"].ToString();
            }
        }

        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();

    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ManageUsers.aspx");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ManageCategories.aspx");

    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ManageProducts.aspx");

    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ManageOrders.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ChangeAdminPassword.aspx");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["Name"] = null;
        Session["LastName"] = null;
        Session["ID"] = null;
        Session["RoleID"] = null;
        Session["Username"] = null;
        Response.Redirect("~/Pages/HomePage.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ChangeAdminProfile.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("CreateOrEditUser.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("CreateOrEditUser.aspx");
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (Session["SendToAll"] != null)
        {
           webprojectdbModel.User[] list = us.listUsers();
           SendMail sm = new SendMail();
          
           for (int i = 0; i < list.Length; i++ )
           {
               if(list[i].Email != "")
               sm.sendMail(list[i].Email, TextBox1.Text, TextBox2.Text);
           }
           Label6.Text = "ایمیل به کاربران با موفقیت انجام شد.";
           Label6.Visible = true;
           TextBox1.Text = "";
           TextBox2.Text = "";
           Button1.Visible = false;
           Session["SendToAll"] = null;

        }
        else
        {
            Label6.Text = "ایمیل به کاربر(ان) با موفقیت انجام شد.";
            Label6.Visible = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
            Button1.Visible = false;
        }
    }
}