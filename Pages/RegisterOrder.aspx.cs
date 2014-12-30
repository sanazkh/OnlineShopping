using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterOrder : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
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
        if (RadioButton1.Checked)
        {
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox4.ReadOnly = true;
            TextBox5.ReadOnly = true;

            webprojectdbModel.User u = us.findUser(long.Parse(Session["ID"].ToString()));
            TextBox1.Text = u.FirstName;
            TextBox2.Text = u.LastName;
            TextBox5.Text = u.Address;
            TextBox4.Text = u.Telephone;
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("ShoppingCart.aspx");
        else
            Response.Redirect("HomePage.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("HomeAfterLogin.aspx");
        else
            Response.Redirect("HomePage.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fname = TextBox1.Text;
        string lname = TextBox2.Text;
        string address = TextBox5.Text;
        string telephone = TextBox4.Text;
        string depositNo = TextBox3.Text;
        if (fname != "" && lname != "" && address != "" && telephone != "" && TextBox3.Text != "")
        {

            long userID = long.Parse(Session["ID"].ToString());
            webprojectdbModel.Order order = (from Order in webproject.Orders
                                             where Order.UserID == userID
                                             && Order.Confirmed == false
                                             select Order).First();

            order.Confirmed = true;


            order.FirstName = fname;
            order.LastName = lname;
            order.Address = address;
            order.Telephon = telephone;
            order.DepositNo = depositNo;
            order.OrderDate = System.DateTime.Now;
            webproject.SaveChanges();
            Response.Redirect("ThanksForOrder.aspx");

        }
        else
        {
            Label9.Text = "لطفاً تمام جاهای خلی را پر کنید.";
            Label9.Visible = true;
        }



    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox4.ReadOnly = true;
            TextBox5.ReadOnly = true;

            webprojectdbModel.User u = us.findUser(long.Parse(Session["ID"].ToString()));
            TextBox1.Text = u.FirstName;
            TextBox2.Text = u.LastName;
            TextBox5.Text = u.Address;
            TextBox4.Text = u.Telephone;
        }
        else if (RadioButton2.Checked)
        {
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            TextBox4.ReadOnly = false;
            TextBox5.ReadOnly = false;

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

    }
}