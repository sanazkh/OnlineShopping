<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Pages_AboutUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fa" lang="fa" dir="rtl">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="banner">
            <asp:Image ID="Image1" runat="server" Height="150px" Width="900px" 
                ImageUrl="~/images/OnlineShoppingBanner.png" />
        </div>
        <div id="links">
            <ul>
                <li><asp:LinkButton ID="LinkButton6" runat="server" onclick="LinkButton6_Click">صفحۀ اصلی</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton7_Click">محصولات</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton10_Click">ثبت نام در سایت</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click">دربارۀ ما</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton9_Click">تماس با ما</asp:LinkButton></li>
            </ul>
        </div>
        <div id="main">
            <div id="top10">
            <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="false"
                    >
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="content">
              <asp:TextBox ID="TextBoxAbout" Font-Size="Large" runat="server" ReadOnly="true" 
                    TextMode="MultiLine" Height="384px" Width="449px" style="margin-right: 11px; margin-top: 20px; margin-bottom: 109px; margin-left:11px; text-align:justify"
                    
                    >ما طراحان سایت پیش رو (آرش لایقی, ساناز خسروی و فرحناز فلفلی) بر آنیم که جدیدترین سرویس ها و محصولات را به مشتریان خود ارائه دهیم تا رضایت آن ها را به دست آوریم. 
                    با استفاده از جدیدترین تکنولوژی های روز سعی کرده سایت و در حقیقت فروشگاه آن لاین خود را به روز نگه داشته و کاربران ما بتوانند در بهترین حالت ممکن و به صورت سریع سفارشات را انجام داده و بتوانند به صورت آن لاین خرید نمایند. 
                    برای بهبود وضعیت فروشگاه آن لاین می توانید هر گونه نظرات و انتقادات و پیشنهادات خود را در قسمت ارتباط با ما, برای ما ارسال نمایید تا بتوانیم در اسرع وقت فعالیت های مربوطه را مجری داریم.</asp:TextBox>
            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label1" runat="server" Text="ورود به صفحۀ کاربری"></asp:Label><br /><br />
                <asp:Label ID="Label2" runat="server" Text="نام کاربری  : "></asp:Label>
                <asp:TextBox ID="UserName" runat="server" Width="100px" 
                    ></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="رمز عبور     : " ></asp:Label>
                <asp:TextBox ID="Password" runat="server" Width="100px" 
                    style="margin-right: 4px" TextMode="password"></asp:TextBox><br /><br />
                <asp:Button ID="Login" runat="server" Text="ورود" Width="95px" 
                    style="margin-right: 15px; margin-top: 0px;" onclick="Login_Click" 
                    Height="28px" /><br />
                    <asp:Label ID="Label4" runat="server" Visible="false" style="margin-right: 4px"></asp:Label>
                <br />
            </div>
        </div>
        <div id="footer">
            <asp:Label ID="Label11" runat="server" Text="ایجاد شده توسط ساناز خسروی و آرش لایقی و فرحناز فلفلی" style="margin-right: 300px"></asp:Label>
        </div>

        <div style="clear:both;"></div>
    </div>
    </form>
</body>
</html>
