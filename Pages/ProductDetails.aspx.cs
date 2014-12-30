using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ProductDetails : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    NewProductsList npl = new NewProductsList();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();

        long productID = long.Parse(Session["ProductID"].ToString());
        webprojectdbModel.Product product = npl.findProduct(productID);

        Label4.Text = product.ProductName;
        Label6.Text = product.ProductPrice.ToString();
        Label8.Text = product.ProductDescription;
        Label13.Text = product.NoOfVisits.ToString();
        Image2.ImageUrl = product.ProductImage;

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
                Label12.Text = "حساب شما فعال نیست.";
                Label12.Visible = true;
            }
        }
        else
        {
            Label12.Text = "اطلاعات وارد شده صحیح نمی باشد.";
            Label12.Visible = true;

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
    protected void LinkButton6_Click1(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("ProductsAfterLogin.aspx");
        else
            Response.Redirect("Products.aspx");
    }
}