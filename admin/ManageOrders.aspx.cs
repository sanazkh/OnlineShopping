using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ManageOrders : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    ShowOrderDetails sod = new ShowOrderDetails();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RoleID"] != null)
        {
            if (Session["RoleID"].ToString().Equals("1"))
            {
                Label2.Text = Session["Username"].ToString();
                Label4.Text = "";
            }
            else
            {
                Label2.Text = Session["Name"].ToString();
                Label4.Text = Session["LastName"].ToString();
            }
        }

        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();
        GridView2.DataSource = sod.showOrder();
        GridView2.DataBind();
        RadioButton1.Checked = true;

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
    protected void LinkButton100_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
            Response.Redirect("~/Pages/HomePage.aspx");
        else
            Response.Redirect("ChangeAdminProfile.aspx");
    }
    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
 
    protected void ButtonList_Click(object sender, EventArgs e)
    {
        if (nametextBox1.Text != "")
        {
            if (RadioButton1.Checked)
            {
                try
                {
                    System.DateTime date = Convert.ToDateTime(nametextBox1.Text);
                    if (DropDownList2.SelectedIndex == 0)
                    {
                        GridView2.DataSource = sod.showOrderByDateMore(date);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                    else if (DropDownList2.SelectedIndex == 1)
                    {
                        GridView2.DataSource = sod.showOrderByDateEqual(date);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                    else if (DropDownList2.SelectedIndex == 2)
                    {
                        GridView2.DataSource = sod.showOrderByDateLess(date);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                }
                catch
                {
                    Label5.Text = "لطفاً تاریخ را با فرمت مناسب YYYY/MM/DD وارد کنید.";
                    Label5.Visible = true;
                    GridView2.Visible = false;
                }
            }

            if (RadioButton2.Checked)
            {
                try
                {
                    double price = Convert.ToDouble(nametextBox1.Text);
                    if (DropDownList1.SelectedIndex == 0)
                    {
                        GridView2.DataSource = sod.showOrderByPriceMore(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                    else if (DropDownList1.SelectedIndex == 1)
                    {
                        GridView2.DataSource = sod.showOrderByPriceEqual(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                    else if (DropDownList1.SelectedIndex == 2)
                    {
                        GridView2.DataSource = sod.showOrderByPriceLess(price);
                        GridView2.DataBind();
                        GridView2.Visible = true;
                    }
                }
                catch
                {
                    Label5.Text = "لطفاً برای قیمت عدد وارد کنید.";
                    Label5.Visible = true;
                    GridView2.Visible = false;
                }
            }
            if (RadioButton3.Checked)
            {
                string name = nametextBox1.Text;
                GridView2.DataSource = sod.showOrderByName(name);
                GridView2.DataBind();
                Label5.Visible = false;
                GridView2.Visible = true;
            }
        }
        else
        {
            Label5.Text = "لطفاً کادر خالی را پر کنید.";
            Label5.Visible = true;
            GridView2.Visible = false;
        }
    }
}