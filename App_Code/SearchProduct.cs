using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for SearchProduct
/// </summary>
public class SearchProduct
{
	public SearchProduct()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    webprojectdbEntities1 webproject = new webprojectdbEntities1();
    public Product[] showAllProduct()
    {
        Product[] p = (from Products in webproject.Products
                       select Products).ToArray();
        return p;
    }
    public Product[] showProductByName(string name)
    {
        Product[] morder = (from Product in webproject.Products
                                           orderby Product.ProductName
                            where Product.ProductName.ToLower().Contains(name.ToLower())
                            select Product).ToArray();
        return morder;
    }
    public Product[] ShowProductByPriceEqual(double price)
    {
        Product[] morder = (from Product in webproject.Products
                            orderby Product.ProductName
                            where Product.ProductPrice == price
                            select Product).ToArray();
        return morder;
    }
    public Product[] ShowProductByPriceLess(double price)
    {
        Product[] morder = (from Product in webproject.Products
                            orderby Product.ProductName
                            where Product.ProductPrice < price
                            select Product).ToArray();
        return morder;
    }
    public Product[] ShowProductByPriceMore(double price)
    {
        Product[] morder = (from Product in webproject.Products
                            orderby Product.ProductName
                            where Product.ProductPrice > price
                            select Product).ToArray();
        return morder;
    }
}