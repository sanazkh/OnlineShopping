using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ChangeAdminProfile : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
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
        if (!Page.IsPostBack)
        {
            webprojectdbModel.User user = us.findUser(long.Parse(Session["ID"].ToString()));
            TextBox1.Text = user.FirstName;
            TextBox4.Text = user.LastName;
            Label12.Text = user.UserName;
            TextBox3.Text = user.Telephone;
            TextArea1.Text = user.Address;
            TextBox5.Text = user.Email;
            TextBox6.Text = user.WebSite;
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
        string firstName = TextBox1.Text;
        string lastName = TextBox4.Text;
        string ftel = TextBox3.Text;
        string faddress = TextArea1.Text;
        string email = TextBox5.Text;
        string fwebsite = TextBox6.Text;
        string userName = Label12.Text;


        long userID = long.Parse(Session["ID"].ToString());
        if (firstName != "" && lastName != "" && ftel != "" && email != "")
        {
            var result = from User in webproject.Users
                         where User.UserID == userID
                         select User;
            if (result.Count() > 0)
            {
                webprojectdbModel.User u = (webprojectdbModel.User)result.First();
                u.FirstName = firstName;
                u.LastName = lastName;
                u.Telephone = ftel;
                u.Address = faddress;
                u.Email = email;
                u.WebSite = fwebsite;
                webproject.SaveChanges();

                Label50.Text = "تغییر مشخصات کاربری با موفقیت صورت پذیرفت.";
                Label50.Visible = true;
                TextBox1.Text = "";
                TextBox4.Text = "";
                Label12.Text = "";
                TextBox3.Text = "";
                TextArea1.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                Button1.Visible = false;

            }

            else
            {
                Label50.Text = "لطفا کادرهای خالی را پر نمایید.";
                Label50.Visible = true;
            }
        }
    }
}