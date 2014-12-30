using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ContactUs : System.Web.UI.Page
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
        
        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string nameOfUser = TextBox1.Text;
        string emailOfUser = TextBox2.Text;
        string title = TextBox3.Text;
        string message = TextArea1.Text;

        if (nameOfUser != "" && emailOfUser != "" && message != "")
        {
            if (us.sendMessage(nameOfUser, emailOfUser, title, message))
            {
                SendMail sm = new SendMail();
                sm.sendMail("erfan.soleymani@gmail.com", title, "از: " + nameOfUser + " با ایمیل : " + emailOfUser + "متن پیام: " + message);
                Label40.Text = "پیغام شما با موفقیت ارسال شد. ممنون از اینکه در بهبودی سایت مشارکت می کنید.";
                Label40.Visible = true;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            else
            {
                Label40.Text = "ارسال ایمیل با مشکل مواجه شد. لطفاً بعداً امتحان کنید.";
                Label40.Visible = true;
            }

        }
        else
        {
            Label40.Text = "لطفاً جاهای خلی ستاره دار را پر کنید.";
            Label40.Visible = true;
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
}