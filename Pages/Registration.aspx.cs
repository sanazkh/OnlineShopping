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
        if (Session["RegisterMessage"] != null)
        {
            Label16.Text = Session["RegisterMessage"] + "";
            Label16.Visible = true;
            Session["RegisterMessage"] = null;
        }
        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
        
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
                Label15.Text = "حساب شما فعال نیست.";
                Label15.Visible = true;
            }
        }
        else
        {
            Label15.Text = "اطلاعات وارد شده صحیح نمی باشد.";
            Label15.Visible = true;

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
                        Session["RegisterMessage"] = "ثبت نام با موفقیت انجام شد. اکنون می توانید با این حساب جدید وارد سایت شوید";
                        Response.Redirect("Registration.aspx");
                        
                        
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