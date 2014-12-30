using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_CreateOrEditProduct : System.Web.UI.Page
{
    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
    webprojectdbModel.Product p;
    TopTenProductsListFunction topTenProducts = new TopTenProductsListFunction();
    NewProductsList npl = new NewProductsList();
    long productID;
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

        if (Session["SelectedProduct"] != null)
        {
            productID = long.Parse(Session["SelectedProduct"].ToString());
            p = npl.findProduct(productID);
            webprojectdbModel.Category c = npl.findCategory(p.CategoryID);
            if (!Page.IsPostBack)
            {
                p = npl.findProduct(productID);
                TextBox1.Text = p.ProductName;
                TextBox2.Text = p.ProductPrice.ToString();
                TextBox3.Text = p.RegistrationDate.ToString();
                TextBox4.Text = p.NoOfVisits.ToString();
                DropDownList1.SelectedValue = p.CategoryID.ToString();
                TextBox7.Text = p.ProductDescription;
            }


            Button1.Text = "تغییر مشخصات محصول";
            Label3.Text = "ویرایش محصول";
           
        }
        else
        {
            Button1.Text = "ایجاد محصول";
            Label3.Text = "ایجاد محصول";
            TextBox3.Visible = false;
            Label6.Visible = false;
            
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
        if (Button1.Text.Equals("تغییر مشخصات محصول"))
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox4.Text != "")
            {
                webprojectdbModel.Product product = (from foundProduct in webproject.Products
                                                     where foundProduct.ProductID == productID
                                                     select foundProduct).First();

                product.ProductName = TextBox1.Text;
                product.ProductPrice = double.Parse(TextBox2.Text);
                product.NoOfVisits = long.Parse(TextBox4.Text);
                product.ProductDescription = TextBox7.Text;
                if (!TextBox3.Text.Equals(""))
                {
                    try
                    {
                        product.RegistrationDate = System.DateTime.Parse(TextBox3.Text);
                    }
                    catch
                    {
                        Label1.Text = "تاریخ وارد شده فرمت درستی ندارد.";
                        Label1.Visible = true;

                    }
                }
                product.CategoryID = DropDownList1.SelectedIndex + 1;
                if (!FileUpload1.FileName.Equals(""))
                {
                    product.ProductImage = FileUpload1.FileName.ToString();
                }
                webproject.SaveChanges();
                Label1.Text = "اطلاعات محصول با موفقیت ویرایش شد.";
                Label1.Visible = true;
                Button1.Visible = false;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                DropDownList1.SelectedIndex = 0;
                TextBox7.Text = "";
                Session["SelectedProduct"] = null;



            }
            else
            {
                Label1.Text = "لطفاً جاهای خالی ستاره دار را پر نمایید.";
                Label1.Visible = true;
            }

        }
        else
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox4.Text != "")
            {
                
                webprojectdbModel.Product product =  new webprojectdbModel.Product 
                {
                    ProductName = TextBox1.Text,
                    ProductPrice = long.Parse(TextBox2.Text),
                    NoOfVisits = long.Parse(TextBox4.Text),
                    ProductDescription = TextBox7.Text,
                    RegistrationDate = System.DateTime.Now,
                    CategoryID = DropDownList1.SelectedIndex + 1,
                    ProductImage = FileUpload1.ToString()
                };
                webproject.AddToProducts(product);
                webproject.SaveChanges();

                Label1.Text = "ایجاد محصول با موفقیت انجام شد.";
                Label1.Visible = true;
                Button1.Visible = false;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                DropDownList1.SelectedIndex = 0;
                TextBox7.Text = "";
            }
            else
            {
                Label1.Text = "لطفاً جاهای خالی ستاره دار را پر نمایید.";
                Label1.Visible = true;
            }
        }
    }
}