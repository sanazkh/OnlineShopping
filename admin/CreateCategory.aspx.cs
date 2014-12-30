using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_CreateCategory : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
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
        if (TextBox1.Text != "")
        {
            webprojectdbModel.Category category = new webprojectdbModel.Category
            {
                CategoryName = TextBox1.Text,
                CategoryDescription = TextBox2.Text

            };
            webproject.AddToCategories(category);
            webproject.SaveChanges();
            Label7.Text = "مجموعه با موفقیت به سیستم اضافه شد.";
            Label7.Visible = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
            Button1.Visible = false;
        }
        else
        {
            Label7.Text = "لطفاً نام مجموعه را وارد کنید.";
            Label7.Visible = true;
        }
    }
}