using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ShowCategory
/// </summary>
public class ShowCategory
{
	public ShowCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Category[] showCategory()
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        Category[] res = (from Category in webproject.Categories
                         select Category).ToArray();
        return res;
    }
}