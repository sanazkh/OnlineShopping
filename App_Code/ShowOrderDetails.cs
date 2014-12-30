using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ShowOrderDetails
/// </summary>
public class ShowOrderDetails
{
    webprojectdbEntities1 webproject = new webprojectdbEntities1();
	public ShowOrderDetails()
	{
	}

    public ManageOrderByAdminView[] showOrder()
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    //
    public ManageOrderByAdminView[] showOrderByPriceEqual(double price)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           where ManageOrderByAdminView.Expr2 == price 
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    public ManageOrderByAdminView[] showOrderByPriceLess(double price)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           where ManageOrderByAdminView.Expr2 < price 
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    public ManageOrderByAdminView[] showOrderByPriceMore(double price)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           where ManageOrderByAdminView.Expr2 > price 
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    //
    public ManageOrderByAdminView[] showOrderByName(string name)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           orderby ManageOrderByAdminView.UserName
                                           where ManageOrderByAdminView.UserName.ToLower().Contains(name.ToLower())
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    //
    public ManageOrderByAdminView[] showOrderByDateEqual(System.DateTime date)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           where ManageOrderByAdminView.OrderDate == date
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    public ManageOrderByAdminView[] showOrderByDateLess(System.DateTime date)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           where ManageOrderByAdminView.OrderDate < date
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    public ManageOrderByAdminView[] showOrderByDateMore(System.DateTime date)
    {
        ManageOrderByAdminView[] morder = (from ManageOrderByAdminView in webproject.ManageOrderByAdminViews
                                           where ManageOrderByAdminView.OrderDate > date
                                           select ManageOrderByAdminView).ToArray();
        return morder;
    }
    //
}