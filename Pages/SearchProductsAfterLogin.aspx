﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchProductsAfterLogin.aspx.cs" Inherits="Pages_SearchProductsAfterLogin" %>

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
                <li><asp:LinkButton ID="LinkButton6" runat="server" onclick="LinkButton10_Click">ثبت نام در سایت</asp:LinkButton> | &nbsp;</li>
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
                <br /><br />
            <asp:Label ID="Label5" runat="server" Text="جستجو بر اساس : " style="margin-right: 10px"></asp:Label><br />
                <asp:RadioButton ID="RadioButton1" GroupName="base" Text="نام محصول" 
                    runat="server" style="margin-right: 10px"/><br />
                <asp:RadioButton ID="RadioButton2" GroupName="base" Text="قیمت محصول" 
                    runat="server" style="margin-right: 10px" />
                    <asp:Button Id="ButtonList" runat="server" Text="جستجو" 
                    onclick="ButtonList_Click" style="margin-right: 80px"/>
                <asp:Label ID="Label6" runat="server" Text="Label" Visible="false" style="margin-right: 10px"></asp:Label>
                    <br />
                <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right: 10px">
                    <asp:ListItem>محصولات با قیمت بیشتر از مقدار پایین</asp:ListItem>
                    <asp:ListItem>محصولات با قیمت مساوی با مقدار پایین</asp:ListItem>
                    <asp:ListItem>محصولات با قیمت کمتر از مقدار پایین</asp:ListItem>
                </asp:DropDownList><br />
                <asp:TextBox ID="TextBox1" runat="server" style="margin-right: 10px" 
                    Width="242px"></asp:TextBox><br /><br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GridViewPageEventHandler"
                    AllowPaging="True" Height="356px" PageSize="5" style="margin-right: 10px" 
                    Width="458px">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="نام محصول"/>
                    </Columns>
                    <Columns>
                    <asp:BoundField DataField="ProductPrice" HeaderText="قیمت محصول"/>
                    </Columns>
                    <Columns>
                    <asp:BoundField DataField="ProductDescription" HeaderText="توصیف محصول"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="right-side">
                 <br />
                <asp:Label ID="Label1" runat="server" Text="کاربر:" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label2" runat="server" style="margin-right: 10px"></asp:Label>
                 <asp:Label ID="Label3" runat="server" style="margin-right: 15px"></asp:Label><br />
                <asp:LinkButton ID="LinkButton1" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton1_Click">تغییر مشخصات کاربری</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton2" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton2_Click">تغییر رمز ورود</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton3" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton3_Click">مشاهده درخواست ها</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton4" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton4_Click">سبد خرید</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton11" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton11_Click">شرکت در گفتگو</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton5" runat="server" style="margin-right: 10px" OnClick="LinkButton5_Click">خروج</asp:LinkButton><br />
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

