using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webprojectdbModel;

public partial class Pages_ShoppingCart : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    ShoppingCardFunction scf = new ShoppingCardFunction();
    webprojectdbEntities1 webproject = new webprojectdbEntities1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null && Session["LastName"] != null)
        {
            Label2.Text = Session["Name"] + "";
            Label3.Text = Session["LastName"] + "";
        }
        long id = long.Parse(Session["ID"].ToString());
        var res = from o in webproject.OrderProducts
                  from or in webproject.Orders
                  where or.OrderID == o.OrderID
                  select o;
        if (res.Count() > 0)
        {
            TextBox42.Text = scf.ShowTotalPrice(id).ToString();
            TextBox42.ReadOnly = false;
            GridView2.DataSource = scf.ShowShoppingCard(id);
            GridView2.DataBind();
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
    protected void Button44_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("RegisterOrder.aspx");
        else
            Response.Redirect("HomePage.aspx");
    }
    protected void Button45_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            Response.Redirect("CategoriesAfterLogin.aspx");
        else
            Response.Redirect("Categories.aspx");
    }

    protected void Button46_Click(object sender, EventArgs e)
    {
        long id = long.Parse(Session["ID"].ToString());
        bool res = scf.DeleteAllFromShoppingCard(id);
        if (res == true)
        {
            GridView2.DataSource = scf.ShowShoppingCard(id);
            GridView2.DataBind();
            TextBox42.Text = "";
            Label60.Text = "عملیت حذف با موفقیت صورت گرفت";
            Label60.Visible = true;
        }
        else
        {
            Label60.Text = "عملیت حذف موفقیت آمیز نبود. لطفا بعدا امتحان کنید.";
            Label60.Visible = true;
        }
    }

    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
}