using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ShowOrdersOfaUserFunction
/// </summary>
public class ShowOrdersOfaUserFunction
{
	public ShowOrdersOfaUserFunction()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    webprojectdbEntities1 webproject = new webprojectdbEntities1();
    public OrderDetailOfaUser[] ShowOrdersOfaUser(long id)
    {
        OrderDetailOfaUser[] o = (from OrderDetailOfaUser in webproject.OrderDetailOfaUsers
                                  where OrderDetailOfaUser.UserID == id
                                  orderby OrderDetailOfaUser.OrderID ascending
                                  select OrderDetailOfaUser).ToArray();
        return o;
    }
}