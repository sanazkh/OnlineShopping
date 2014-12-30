using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Registration : System.Web.UI.Page
{

    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    Users us = new Users();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null && Session["LastName"] != null)
        {
            Label2.Text = Session["Name"] + "";
            Label1.Text = Session["LastName"] + "";
        }

        if (Session["RegisterMessage"] != null)
        {
            Label16.Text = Session["RegisterMessage"] + "";
            Label16.Visible = true;
            Session["RegisterMessage"] = null;
        }

        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
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
        webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
        string fname = TextBox1.Text;
        string lname = TextBox2.Text;
        string username = TextBox3.Text;
        string pass = TextBox8.Text;
        string rePass = TextBox9.Text;
        string email = TextBox4.Text;
        string website = TextBox5.Text;
        string tel = TextBox6.Text;
        string address = TextBox7.Text;

        if (fname != "" && lname != "" && username != "" && pass != "" && rePass != "" && email != "" && tel != "")
        {
            if (!pass.Equals(rePass))
            {
                Label16.Text = "رمز عبور تکرار شده مطابقت ندارد.";
                Label16.Visible = true;
            }
            else
            {
                var result = from User in webproject.Users
                             where User.UserName == username
                             select User;

                if (result.Any())
                {
                    Label16.Text = "کاربری با این نام کاربری شما قبلاً ثبت نام کرده است. لطفاً  نام کاربری دیگری انتخاب کنید.";
                    Label16.Visible = true;
                }
                else
                {
                    if (us.registerUser(fname, lname, username, pass, email, website, tel, address))
                    {
                        Session["RegisterMessage"] = "ثبت نام با موفقیت انجام شد. اکنون می توانید با این حساب جدید وارد سایت شوید، امّا ابتدا باید از این حساب خود خارج شوید.";
                        Response.Redirect("RegistrationAfterLogin.aspx");


                    }
                    else
                    {
                        Label16.Text = "ثبت نام با مشکل مواجه شد. لطفاً دوباره امتحان کنید.";
                        Label16.Visible = true;
                    }

                }
            }
        }
        else
        {
            Label16.Text = "لطفاً جاهای خالی ستاره دار را پر کنید. ";
            Label16.Visible = true;
        }
    }
}