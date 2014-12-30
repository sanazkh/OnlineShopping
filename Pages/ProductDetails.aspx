<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Pages_ProductDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fa" lang="fa" dir="rtl">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <style type="text/css">
        .style1
        {
            width: 168px;
        }
    </style>
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
                <li><asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton6_Click">صفحۀ اصلی</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton7_Click">محصولات</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton10_Click">ثبت نام در سایت</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton8_Click">دربارۀ ما</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton9_Click">تماس با ما</asp:LinkButton></li>
            </ul>
        </div>
        <div id="main">
            <div id="top10">
           <asp:GridView ID="GridView1" runat="server" Height="403px" 
                    AutoGenerateColumns="false" style="margin-right: 9px" Width="165px">
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            
            <div id="content">
            <br /><br /><br />
                <asp:Label ID="Label3" runat="server" Text="نام محصول  :  " style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Label ID="Label5" runat="server" Text="قیمت محصول  :  " style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Label" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Label ID="Label7" runat="server" Text="توصیف محصول  :  " style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label8" runat="server" Text="Label" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Label ID="Label9" runat="server" Text="تاریخ ثبت محصول در سایت  :  " style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label10" runat="server" Text="Label" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Label ID="Label12" runat="server" Text="تعداد بازدیدها از این محصول  :  " style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="Label" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Image ID="Image2" runat="server" style="margin-right: 10px" Height="175px" 
                    Width="238px"/><br /><br />
                <asp:LinkButton ID="LinkButton6" CommandName="Select" runat="server" 
                    style="margin-right: 10px" onclick="LinkButton6_Click1">بازگشت به لیست محصولات همین مجموعه</asp:LinkButton>
            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label20" runat="server" Text="ورود به صفحۀ کاربری"></asp:Label><br /><br />
                <asp:Label ID="Label21" runat="server" Text="نام کاربری  : "></asp:Label>
                <asp:TextBox ID="UserName" runat="server" Width="100px" 
                    ></asp:TextBox>
                <br />
                <asp:Label ID="Label1" runat="server" Text="رمز عبور     : " ></asp:Label>
                <asp:TextBox ID="Password" runat="server" Width="100px" 
                    style="margin-right: 4px" TextMode="password"></asp:TextBox><br /><br />
                <asp:Button ID="Login" runat="server" Text="ورود" Width="95px" 
                    style="margin-right: 15px; margin-top: 0px;" onclick="Login_Click" 
                    Height="28px" /><br />
                    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
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
