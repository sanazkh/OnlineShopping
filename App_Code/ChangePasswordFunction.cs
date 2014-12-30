using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ChangePasswordFunction
/// </summary>
public class ChangePasswordFunction
{
	public ChangePasswordFunction()
	{
	}
    public bool changePass(long id, string oldpassword, string newpassword, string reapetedPassword)
    {
        webprojectdbEntities1 webproject = new webprojectdbEntities1();


        if (newpassword.Equals(reapetedPassword))
        {
            var u = from User in webproject.Users
                    where User.UserID == id
                    && User.PassWord == oldpassword
                    select User;
            if (u.Count() > 0)
            {
                User user = (User)u.First();
                user.PassWord = newpassword;
                webproject.SaveChanges();
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}