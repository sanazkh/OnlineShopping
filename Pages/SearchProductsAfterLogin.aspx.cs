using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SearchProductsAfterLogin : System.Web.UI.Page
{
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    SearchProduct sp = new SearchProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null && Session["LastName"] != null)
        {
            Label2.Text = Session["Name"] + "";
            Label3.Text = Session["LastName"] + "";
        }

        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
        GridView2.DataSource = sp.showAllProduct();
        GridView2.DataBind();
        RadioButton1.Checked = true;
        Label6.Text = "در زیر لیست کلیّۀ محصولات را می بینید.";
        Label6.Visible = true;


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

    protected void ButtonList_Click(object sender, EventArgs e)
    {
        if (!TextBox1.Text.Equals(""))
        {
            if (RadioButton1.Checked)
            {

                string name = TextBox1.Text;
                GridView2.DataSource = sp.showProductByName(name);
                GridView2.DataBind();
                GridView2.Visible = true;
                Label6.Visible = false;

            }
            if (RadioButton2.Checked)
            {

                try
                {

                    double price = Convert.ToDouble(TextBox1.Text);

                    if (DropDownList1.SelectedIndex == 0)
                    {
                        GridView2.DataSource = sp.ShowProductByPriceMore(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        Label6.Visible = false;
                    }
                    else if (DropDownList1.SelectedIndex == 1)
                    {
                        GridView2.DataSource = sp.ShowProductByPriceEqual(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        Label6.Visible = false;
                    }
                    else if (DropDownList1.SelectedIndex == 2)
                    {
                        GridView2.DataSource = sp.ShowProductByPriceLess(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        Label6.Visible = false;
                    }

                }
                catch
                {
                    GridView2.Visible = false;
                    Label6.Text = "در کادر خالی باید عدد وارد کنید.";
                    Label6.Visible = true;
                }

            }
        }
        else
        {
            GridView2.Visible = false;
            Label6.Text = "کادر خالی پر کنید.";
            Label6.Visible = true;

        }
    }

    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
}