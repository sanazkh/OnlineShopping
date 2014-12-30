using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for TopTenProductsListFunction
/// </summary>
public class TopTenProductsListFunction
{
	public TopTenProductsListFunction()
	{
	}

    public Product[] topTenProduct()
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Product[] result = ((from Order in webproject.Orders
                             from OrderProduct in webproject.OrderProducts
                             from Product in webproject.Products
                             where Product.ProductID == OrderProduct.ProductID
                             && Order.OrderID == OrderProduct.OrderID
                             && Order.Confirmed == true
                             orderby OrderProduct.Quantity descending
                             select Product).Take(10)).Distinct().ToArray();
        return result;

    }

}