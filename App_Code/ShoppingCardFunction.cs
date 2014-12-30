using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ShoppingCardFunction
/// </summary>
public class ShoppingCardFunction
{
	public ShoppingCardFunction()
	{
		
	}
    webprojectdbEntities1 webproject = new webprojectdbEntities1();
    public ShoppingBasket[] ShowShoppingCard(long id)
    {
        ShoppingBasket[] o = (from ShoppingBasket in webproject.ShoppingBaskets
                              where ShoppingBasket.UserID == id
                              select ShoppingBasket).ToArray();
        return o;
    }
    public bool DeleteAllFromShoppingCard(long id)
    {
     
        var res2 = (from res3 in webproject.OrderProducts
                       from res4 in webproject.Orders
                       where res3.OrderID == res4.OrderID
                       && res4.Confirmed == false
                       && res4.UserID == id
                       select res3);
        Order res5 = (from res4 in webproject.Orders
                      where res4.Confirmed == false
                      && res4.UserID == id
                      select res4).First();
        foreach(OrderProduct p in res2)
        {
            webproject.OrderProducts.DeleteObject(p);
        }
        webproject.SaveChanges();
        return true;
    }
    public double ShowTotalPrice(long id)
    {
        var shop = from ShoppingBasket in webproject.ShoppingBaskets
                   where ShoppingBasket.UserID == id
                   select ShoppingBasket.TotalPrice;
        if (shop.Any())
        {
            var shop1 = (from ShoppingBasket in webproject.ShoppingBaskets
                         where ShoppingBasket.UserID == id
                         select ShoppingBasket.TotalPrice).Sum();
            return (double)shop1;
        }
        else
            return 0;
        

       

    }
}