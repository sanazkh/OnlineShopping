﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateOrEditProduct.aspx.cs" Inherits="admin_CreateOrEditProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fa" lang="fa" dir="rtl">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/StyleSheet.css" />
    <style type="text/css">
        #Password1
        {
            width: 300px;
        }
        #Password2
        {
            width: 300px;
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
                <li><asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton7_Click">مدیریت کاربران</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton10_Click">مدیریت مجموعه ها</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click">مدیریت محصولات</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton9_Click">مدیریت سفارشات</asp:LinkButton></li>
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
                <br />
                <asp:Label ID="Label3" runat="server" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Label ID="Label41" runat="server" Text="نام محصول : *" 
                    style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="300px" 
                    style="margin-right: 57px"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="قیمت محصول : *" 
                    style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="300px" 
                    style="margin-right: 46px"></asp:TextBox><br />
                <asp:Label ID="Label7" runat="server" Text="تعداد بازدیدها:*" 
                    style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" Width="300px" 
                    style="margin-right: 57px"></asp:TextBox><br />
                <asp:Label ID="Label9" runat="server" Text="از مجموعۀ : " style="margin-right: 10px"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right: 74px" 
                    DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="CategoryID" Width="306px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" 
                    SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label12" runat="server" Text="توصیف محصول : " 
                    style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" Height="94px" Width="301px" 
                    style="margin-right: 39px"></asp:TextBox><br />
                <asp:Label ID="Label8" runat="server" Text="آپلود عکس محصول : "></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" style="margin-right: 34px" />
                <br />
                <asp:Label ID="Label6" runat="server" Text="تاریخ ثبت در سایت : " 
                    style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Width="300px" 
                    style="margin-right: 26px"></asp:TextBox><br />
                <br /><br />
                <br /><br />
                <asp:Button ID="Button1" runat="server" Text="ایجاد محصول" Width="118px" 
                    style="margin-right: 10px" onclick="Button1_Click"/><br /><br />
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" style="margin-right: 10px"></asp:Label>


            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label16" runat="server" Text="کاربر:" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label" style="margin-right: 5px"></asp:Label><br />
                <asp:LinkButton ID="LinkButton1" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton1_Click">تغییر مشخصات کاربری</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton2" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton2_Click">تغییر رمز ورود</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton5" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton5_Click">خروج از بخش مدیریت</asp:LinkButton><br />
            </div>
        </div>
        <div id="footer">
            <asp:Label ID="Label13" runat="server" Text="ایجاد شده توسط ساناز خسروی و آرش لایقی و فرحناز فلفلی" style="margin-right: 300px"></asp:Label>
        </div>

        <div style="clear:both;"></div>
    </div>
    </form>
</body>
</html>
