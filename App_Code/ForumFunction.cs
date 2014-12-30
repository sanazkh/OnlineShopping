using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webprojectdbModel;

/// <summary>
/// Summary description for ForumFunction
/// </summary>
public class ForumFunction
{
    public ForumFunction()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    webprojectdbEntities1 webproject = new webprojectdbEntities1();


    public ForumView[] showForum()
    {

        ForumView[] forum = (from ForumView in webproject.ForumViews
                             orderby ForumView.ForumDate descending
                             select ForumView).ToArray();
        return forum;
    }


    public void addForumToDB(string title, string text, long userID)
    {
        ForumPost f = new ForumPost
        {
            ForumTitle = title,
            UsersID = userID,
            ForumText = text,
            ForumDate = System.DateTime.Now,
            ParentID = null

        };
        webproject.AddToForumPosts(f);

        webproject.SaveChanges();
    }
}