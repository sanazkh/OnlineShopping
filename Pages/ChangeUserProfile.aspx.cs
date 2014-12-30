using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webprojectdbModel;

public partial class Pages_ChangeUserInfo : System.Web.UI.Page
{
    webprojectdbEntities1 webproject = new webprojectdbEntities1();
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    Users us = new Users();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null && Session["LastName"] != null)
        {
            Label2.Text = Session["Name"] + "";
            Label1.Text = Session["LastName"] + "";
        }
        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
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

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("HomePage.aspx");
        else
            Response.Redirect("ChangeUserProfile.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("HomePage.aspx");
        else
            Response.Redirect("ChangePassword.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("HomePage.aspx");
        else
            Response.Redirect("ShowOrdersOfAUser.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("HomePage.aspx");
        else
            Response.Redirect("ShoppingCart.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["Name"] = null;
        Session["LastName"] = null;
        Session["ID"] = null;
        Session["Username"] = null;
        Session["RoleID"] = null;
        Response.Redirect("Homepage.aspx");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("HomePage.aspx");
        else
            Response.Redirect("HomeAfterLogin.aspx");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)

            Response.Redirect("Categories.aspx");
        else
            Response.Redirect("CategoriesAfterLogin.aspx");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("AboutUs.aspx");
        else
            Response.Redirect("AboutUsAfterLogin.aspx");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("ContactUs.aspx");
        else
            Response.Redirect("ContactUsAfterLogin.aspx");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("RegistrationAfterLogin.aspx");
        else
            Response.Redirect("Registration.aspx");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("Forum.aspx");
        else
            Response.Redirect("HomePage.aspx");
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
                User u = (User)result.First();
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