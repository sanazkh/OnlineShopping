using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ChangeAdminPassword : System.Web.UI.Page
{
    ChangePasswordFunction changepassFunc = new ChangePasswordFunction();
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
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
        long userID = long.Parse(Session["ID"].ToString());
        if (TextBox3.Text != "" && TextBox1.Text != "" && TextBox2.Text != "")
        {
            bool res = changepassFunc.changePass(userID, TextBox1.Text, TextBox2.Text, TextBox3.Text);
            if (res == true)
            {
                Label90.Text = "رمز عبور شما با موفقیت تغییر یافت!";
                Label90.Visible = true;
                Button1.Visible = false;
            }
            else
            {
                Label90.Text = "لطفا در ورود اطلاعات دقت کنید!";
                Label90.Visible = true;
            }
        }
        else
        {
            Label90.Text = "لطفا کادرهای خالی را تکمیل نمایید.";
            Label90.Visible = true;
        }
    }
}