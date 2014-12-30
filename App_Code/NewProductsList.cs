using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for NewProductsList
/// </summary>
public class NewProductsList
{
	public NewProductsList()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Product[] top20newproductsByDate(long categoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = ((from Product in webproject.Products
                             where Product.CategoryID == categoryID
                            orderby Product.RegistrationDate descending
                             select Product).Take(20)).ToArray();

            return result;
    }
	
	public Product[] top20newproductsByDate()
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = ((from Product in webproject.Products
                             orderby Product.RegistrationDate descending
                             select Product).Take(20)).ToArray();

        return result;
    }

    public Product[] top20newproductsByVisit(long categoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = ((from Product in webproject.Products
                             where Product.CategoryID == categoryID
                             orderby Product.NoOfVisits descending
                             select Product).Take(20)).ToArray();

        return result;
    }

    public Product[] top20newproductsBySelling(long categoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = ((from OrderProduct in webproject.OrderProducts
                             from Product in webproject.Products
                             where Product.ProductID == OrderProduct.ProductID
                             orderby OrderProduct.Quantity descending
                             select Product).Take(20)).Distinct().ToArray();

        return result;
    }

    public Product[] newproductsBySelling(long categoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = (from OrderProduct in webproject.OrderProducts
                             from Product in webproject.Products
                             where Product.ProductID == OrderProduct.ProductID
                             && Product.CategoryID == categoryID
                             orderby OrderProduct.Quantity descending
                            select Product).Distinct().ToArray();

        return result;
    }

    public Product[] newproductsByVisit(long categoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = (from Product in webproject.Products
                             where Product.CategoryID == categoryID
                             orderby Product.NoOfVisits descending
                             select Product).ToArray();

        return result;
    }

    public Product[] newproductsByDate(long categoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = (from Product in webproject.Products
                             where Product.CategoryID == categoryID
                             orderby Product.RegistrationDate descending
                             select Product).ToArray();

        return result;
    }


    public Product findProduct(long productID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product result = (from Product in webproject.Products
                            where Product.ProductID == productID
                            select Product).First();

        return result;
    }

    public Category findCategory(long CategoryID)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Category result = (from Category in webproject.Categories
                          where Category.CategoryID == CategoryID
                          select Category).First();

        return result;
    }
}