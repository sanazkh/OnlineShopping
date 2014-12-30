using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
	public Users()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    webprojectdbModel.webprojectdbEntities1 webproject = new webprojectdbModel.webprojectdbEntities1();
    public webprojectdbModel.User[] listUsers()
    {
        
        webprojectdbModel.User[] res = (from User in webproject.Users
                                        select User).ToArray();
        return res;
    }
    public webprojectdbModel.User findUser(long ID)
    {
        webprojectdbModel.User res = (from User in webproject.Users
                                     where User.UserID == ID
                                      select User).First();
        return res;
    }

    public bool ExistsUser(string username)
    {
        bool res = false;
        var result = from User in webproject.Users
                                      where User.UserName == username
                                      select User;
        if (result.Any())
            res = true;
        return res;
    }
    public bool registerUser(string fname, string lname, string username, string pass, string email, string website, string tel, string address)
    {
        bool res = false;
        webprojectdbModel.User u = new webprojectdbModel.User
        {
            
            FirstName = fname,
            LastName = lname,
            UserName = username,
            PassWord = pass,
            Telephone = tel,
            Email = email,
            Address = address,
            RoleID = 3,
            WebSite = website,
            RegistrationDate = System.DateTime.Now,
            IsActive = true
            
        };

        webproject.AddToUsers(u);
        webproject.SaveChanges();
        res = true;
        return res;
    }

    public bool createUser(string fname, string lname, string username, string pass, string email, string website, string tel, string address, long roleID, bool isActive)
    {
        bool res = false;
        webprojectdbModel.User u = new webprojectdbModel.User
        {

            FirstName = fname,
            LastName = lname,
            UserName = username,
            PassWord = pass,
            Telephone = tel,
            Email = email,
            Address = address,
            RoleID = roleID,
            WebSite = website,
            RegistrationDate = System.DateTime.Now,
            IsActive = isActive

        };

        webproject.AddToUsers(u);
        webproject.SaveChanges();
        res = true;
        return res;
    }

    public bool sendMessage(string nameOfUser, string emailOfUser, string title, string message)
    {
        bool res = false;
        webprojectdbModel.Message m = new webprojectdbModel.Message
        {
            Name = nameOfUser,
            Email = emailOfUser,
            Title = title,
            Message1 = message,
            Date = System.DateTime.Now,
        };

        webproject.AddToMessages(m);
        webproject.SaveChanges();
        res = true;
        return res;
    }

    public bool deleteUser(long ID)
    {
        bool res = false;
        webprojectdbModel.User objUser = (from user in webproject.Users
                        where user.UserID == ID
                        select user).First();

        webproject.DeleteObject(objUser);
        webproject.SaveChanges();
        res = true;
        return res;
    }

}