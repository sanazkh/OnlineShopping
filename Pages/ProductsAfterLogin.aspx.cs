using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductAfterLogin : System.Web.UI.Page
{
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
    NewProductsList newProductList = new NewProductsList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null && Session["LastName"] != null)
        {
            Label2.Text = Session["Name"] + "";
            Label3.Text = Session["LastName"] + "";
        }
        GridView1.DataSource = topTenProducts.topTenProduct();
        GridView1.DataBind();

        if (Session["CategoryID"] != null)
        {
            GridView2.DataSource = newProductList.newproductsByDate(long.Parse(Session["CategoryID"].ToString()));
            GridView2.DataBind();
        }
        Label4.Text = "لیست جدیدترین محصولات بر اساس تاریخ ثبت";
        RadioButton1.Checked = true;

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
        if (Session["CategoryID"] != null)
        {
            if (RadioButton1.Checked)
            {

                GridView2.DataSource = newProductList.newproductsByDate(long.Parse(Session["CategoryID"].ToString()));
                GridView2.DataBind();
                Label4.Text = "لیست جدیدترین محصولات بر اساس تاریخ ثبت";
                RadioButton1.Checked = true;


            }
            if (RadioButton2.Checked)
            {

                GridView2.DataSource = newProductList.newproductsBySelling(long.Parse(Session["CategoryID"].ToString()));
                GridView2.DataBind();
                Label4.Text = "لیست جدیدترین محصولات بر اساس بیشترین فروش";
                RadioButton2.Checked = true;

            }
            if (RadioButton3.Checked)
            {

                GridView2.DataSource = newProductList.newproductsByVisit(long.Parse(Session["CategoryID"].ToString()));
                GridView2.DataBind();
                Label4.Text = "لیست جدیدترین محصولات بر اساس بیشترین بازدید";
                RadioButton3.Checked = true;

            }
        }
        else
        {
            Label5.Text = "لطفاً از صفحۀ ممجموعه ها یک مجموعه را انتخاب کنید.";
            GridView2.Visible = false;
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        long orderID;
        long productID = long.Parse(GridView2.SelectedValue.ToString());
        long userID = long.Parse(Session["ID"].ToString());
        webprojectdbModel.Product product = (from Product in webproject.Products
                                             where Product.ProductID == productID
                                             select Product).First();
        product.NoOfVisits = product.NoOfVisits + 1;
        webproject.SaveChanges();

        var o = from Order in webproject.Orders
                where Order.UserID == userID
                && Order.Confirmed == false
                select Order;
        if (o.Any())
        {
            webprojectdbModel.Order order = (webprojectdbModel.Order)o.First();
            orderID = order.OrderID;

            var op = from OrderProduct in webproject.OrderProducts
                where OrderProduct.OrderID == orderID
                && OrderProduct.ProductID == productID
                select OrderProduct;
            if (op.Any())
            {
                webprojectdbModel.OrderProduct orderproduct = (webprojectdbModel.OrderProduct)op.First();
                orderproduct.Quantity++;
                webproject.SaveChanges();
            }
            else
            {
                webprojectdbModel.OrderProduct orderProduct = new webprojectdbModel.OrderProduct
                {
                    Quantity = 1,
                    OrderID = orderID,
                    ProductID = productID,

                };
                webproject.AddToOrderProducts(orderProduct);
                webproject.SaveChanges();
            }
        }
        else
        {
            webprojectdbModel.Order order = new webprojectdbModel.Order
            {
                
                UserID = userID,
                Confirmed = false,


            };
            webproject.AddToOrders(order);
            webproject.SaveChanges();

            webprojectdbModel.Order newOrder = (from Order in webproject.Orders
                     where Order.UserID == userID
                     && Order.Confirmed == false
                    select Order).First();



            webprojectdbModel.OrderProduct orderProduct = new webprojectdbModel.OrderProduct
            {

                OrderID = newOrder.OrderID,
                ProductID = productID,
                Quantity = 1
            };

            webproject.AddToOrderProducts(orderProduct);
            webproject.SaveChanges();
        }

        Label6.Text = "محصول به سبد خرید شما اضافه شد.";
        Label6.Visible = true;


    }

    protected void GridViewPageEventHandler(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
}