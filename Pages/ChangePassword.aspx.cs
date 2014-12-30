using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_ChangePassword : System.Web.UI.Page
{
    ChangePasswordFunction changepassFunc = new ChangePasswordFunction();
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
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