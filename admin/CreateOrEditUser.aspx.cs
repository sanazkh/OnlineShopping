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
    webprojectdbModel.User u;
    static string firstUsername = "";
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RoleID"] != null)
        {
            if (Session["RoleID"].ToString().Equals("1"))
            {
                Label4.Text = Session["Username"].ToString();
                Label2.Text = "";
            }
            else
            {
                Label4.Text = Session["Name"].ToString();
                Label2.Text = Session["LastName"].ToString();
            }
        }
        if (Session["SelectedUser"] != null)
        {
            if (!Page.IsPostBack)
            {
                u = us.findUser(long.Parse(Session["SelectedUser"].ToString()));
                TextBox1.Text = u.FirstName;
                TextBox2.Text = u.LastName;
                TextBox3.Text = u.UserName;
                firstUsername = u.UserName;
                TextBox8.Text = u.PassWord;
                TextBox9.Text = u.PassWord;
                TextBox4.Text = u.Email;
                TextBox5.Text = u.WebSite;
                TextBox6.Text = u.Telephone;
                TextBox7.Text = u.Address;
                if (u.IsActive)
                    CheckBox1.Checked = true;
                else
                    CheckBox1.Checked = false;

                Button1.Text = "تغییر مشخصات کاربر";
                Label3.Text = "ویرایش کاربر";
            }

            RadioButton1.Visible = false;
            RadioButton2.Visible = false;

        }
        else
        {
            Button1.Text = "ایجاد کاربر";
            Label3.Text = "ایجاد کاربر";
            if (Session["RoleID"]!= null && !Session["RoleID"].ToString().Equals("1"))
            {
                RadioButton1.Visible = true;
                RadioButton2.Visible = false;
                RadioButton2.Checked = false;
            }
            else
            {
                RadioButton1.Visible = true;
                RadioButton2.Visible = true;
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
        if (Button1.Text.Equals("تغییر مشخصات کاربر"))
        {
            if (!(TextBox3.Text.Equals(firstUsername)) && us.ExistsUser(TextBox3.Text))
            {
                Label1.Text = "کاربر دیگری با این نام کاربری وجود دارد لطفاً نام کاربری دیگری انتخاب کنید.";
                Label1.Visible = true;
            }
            else
            {
                string username = TextBox3.Text;
                webprojectdbModel.User user = (from foundUser in webproject.Users
                                               where foundUser.UserName == username
                                               select foundUser).First();

                user.FirstName = TextBox1.Text;
                user.LastName = TextBox2.Text;
                user.UserName = TextBox3.Text;
                user.Email = TextBox4.Text;
                user.WebSite = TextBox5.Text;
                user.Telephone = TextBox6.Text;
                user.Address = TextBox7.Text;
                if (CheckBox1.Checked)
                    user.IsActive = true;
                else
                    user.IsActive = false;
                if (TextBox8.Text != "" || TextBox9.Text != "")
                {
                    if (!TextBox8.Text.Equals(TextBox9.Text))
                    {
                        Label1.Text = "رمز عبور های وارد شده با هم مطابقت ندارند. لطفاً دوباره سعی کنید.";
                        Label1.Visible = true;
                    }
                    else
                    {

                        user.PassWord = TextBox8.Text;
                    }
                }
                webproject.SaveChanges();
                Label1.Text = "تغییرات با موفقیت انجام شد.";
                Label1.Visible = true;

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                Session["SelectedUser"] = null;
                Button1.Visible = false;


            }
        }
        else
        {
           
            string fname = TextBox1.Text;
            string lname = TextBox2.Text;
            string username = TextBox3.Text;
            string pass = TextBox8.Text;
            string rePass = TextBox9.Text;
            string email = TextBox4.Text;
            string website = TextBox5.Text;
            string tel = TextBox6.Text;
            string address = TextBox7.Text;
            long roleID;
            bool isActive;
            if (RadioButton1.Checked)
                roleID = 3;
            else
                roleID = 2;
            if (CheckBox1.Checked)
                isActive = true;
            else
                isActive = false;


            if (fname != "" && lname != "" && username != "" && pass != "" && rePass != "" && email != "" && tel != "")
            {
                if (!pass.Equals(rePass))
                {
                    Label1.Text = "رمز عبور تکرار شده مطابقت ندارد.";
                    Label1.Visible = true;
                }
                else
                {
                    var result = from User in webproject.Users
                                 where User.UserName == username
                                 select User;

                    if (result.Any())
                    {
                        Label1.Text = "کاربری با این نام کاربری شما قبلاً ثبت نام کرده است. لطفاً  نام کاربری دیگری انتخاب کنید.";
                        Label1.Visible = true;
                        TextBox3.Text = "";
                    }
                    else
                    {
                        if (us.createUser(fname, lname, username, pass, email, website, tel, address, roleID, isActive))
                        {
                            Label1.Text = "کاربر جدید با موفقیت در سیستم ثبت شد.";
                            Label1.Visible = true;
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            TextBox3.Text = "";
                            TextBox8.Text = "";
                            TextBox9.Text = "";
                            TextBox4.Text = "";
                            TextBox5.Text = "";
                            TextBox6.Text = "";
                            TextBox7.Text = "";
                            Button1.Visible = false;


                        }
                        else
                        {
                            Label1.Text = "ایجاد کاربر با مشکل مواجه شد. لطفاً دوباره امتحان کنید.";
                            Label1.Visible = true;
                        }

                    }
                }
            }
            else
            {
                Label1.Text = "لطفاً جاهای خالی ستاره دار را پر کنید. ";
                Label1.Visible = true;
            }
        }
    }
}