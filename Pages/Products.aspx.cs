using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Products : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    NewProductsList newProductList = new NewProductsList();
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
        if (Session["CategoryID"] != null)
        {
            GridView2.DataSource = newProductList.newproductsByDate(long.Parse(Session["CategoryID"].ToString()));
            GridView2.DataBind();
        }
        Label3.Text = "لیست جدیدترین محصولات بر اساس تاریخ ثبت";
        RadioButton1.Checked = true;


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["CategoryID"] != null)
        {
            if (RadioButton1.Checked)
            {

                GridView2.DataSource = newProductList.newproductsByDate(long.Parse(Session["CategoryID"].ToString()));
                GridView2.DataBind();
                Label3.Text = "لیست جدیدترین محصولات بر اساس تاریخ ثبت";
                RadioButton1.Checked = true;


            }
            if (RadioButton2.Checked)
            {

                GridView2.DataSource = newProductList.newproductsBySelling(long.Parse(Session["CategoryID"].ToString()));
                GridView2.DataBind();
                Label3.Text = "لیست جدیدترین محصولات بر اساس بیشترین فروش";
                RadioButton2.Checked = true;

            }
            if (RadioButton3.Checked)
            {

                GridView2.DataSource = newProductList.newproductsByVisit(long.Parse(Session["CategoryID"].ToString()));
                GridView2.DataBind();
                Label3.Text = "لیست جدیدترین محصولات بر اساس بیشترین بازدید";
                RadioButton3.Checked = true;

            }
        }
        else
        {
            Label4.Text = "لطفاً از صفحۀ ممجموعه ها یک مجموعه را انتخاب کنید.";
            GridView2.Visible = false;
        }

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
                Label2.Text = "حساب شما فعال نیست.";
                Label2.Visible = true;
            }
        }
        else
        {
            Label2.Text = "اطلاعات وارد شده صحیح نمی باشد.";
            Label2.Visible = true;

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
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ProductID"] = GridView2.SelectedValue;
        long productID = long.Parse(GridView2.SelectedValue.ToString());
        webprojectdbModel.Product product = (from Product in webproject.Products
                                             where Product.ProductID == productID
                                             select Product).First();
        product.NoOfVisits = product.NoOfVisits + 1;
        webproject.SaveChanges();
        if (Session["ID"] != null)
            Response.Redirect("ProductDetailsAfterLogin.aspx");
        else
            Response.Redirect("ProductDetails.aspx");
        
    }

    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
}