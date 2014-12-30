using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ChangeUserProfileFunction
/// </summary>
public class ChangeUserProfileFunction
{
	public ChangeUserProfileFunction()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool ChangeUserProfile(long userID, string firstName, string lastName, string tel, string address, string email, string website)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();
        var result = from User in webproject.Users
                     where User.UserID == userID
                     select User;
        if (result.Count() > 0)
        {
            User u = (User)result.First();
            u.FirstName = firstName;
            u.LastName = lastName;
            u.Telephone = tel;
            u.Address = address;
            u.Email = email;
            u.WebSite = website;
            webproject.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
        

    }
}