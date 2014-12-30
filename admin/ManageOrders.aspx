<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageOrders.aspx.cs" Inherits="admin_ManageOrders" %>

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
                <asp:Label ID="Label3" runat="server" Text="مدیریت درخواست ها" style="margin-right: 200px"></asp:Label><br />
                <asp:Label ID="Label7" runat="server" Text="لیست بر اساس : " style="margin-right: 10px"></asp:Label>
                <asp:RadioButton ID="RadioButton1" Text="تاریخ سفارش" GroupName="choice" 
                    runat="server" style="margin-right: 10px" 
                  />
                <asp:RadioButton ID="RadioButton2" Text="قیمت" GroupName="choice" 
                    runat="server"  style="margin-right: 10px"/>
                <asp:RadioButton ID="RadioButton3" Text="نام" GroupName="choice" runat="server" 
                     style="margin-right: 10px"/>
                    <asp:Button ID="ButtonList" Text="لیست کردن" runat="server" 
                    onclick="ButtonList_Click" style="margin-right: 52px"/>
                <br /><br />
                    
                      <asp:DropDownList ID="DropDownList1" runat="server" 
                    style="margin-right: 10px" Width="185px">
                    <asp:ListItem>سفارشات با قیمت بیشتر از مقدار پایین</asp:ListItem>
                    <asp:ListItem>سفارشات با قیمت مساوی با مقدار پایین</asp:ListItem>
                    <asp:ListItem>سفارشات با قیمت کمتر از مقدار پایین</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="false" style="margin-right: 10px"></asp:Label><br />
                <asp:DropDownList ID="DropDownList2" runat="server" style="margin-right: 10px" 
                    Height="20px" Width="185px">
                    <asp:ListItem>سفارشات با تاریخ بیشتر از مقدار پایین</asp:ListItem>
                    <asp:ListItem>سفارشات با تاریخ مساوی با مقدار پایین</asp:ListItem>
                    <asp:ListItem>سفارشات با تاریخ کمتر از مقدار پایین</asp:ListItem>
                </asp:DropDownList><br /><br />
                    <asp:TextBox ID="nametextBox1" runat="server" Width="248px" 
                    style="margin-right: 10px"></asp:TextBox><br />

                       <asp:GridView ID="GridView2" runat="server" Height="343px" 
                    AutoGenerateColumns="False" Width="446px" AllowPaging="True" 
                    OnPageIndexChanging="GridViewPageEventHandler" 
                    style="margin-right: 23px; margin-top: 14px; margin-bottom: 7px;" 
                    PageSize="5" >
                     <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText=" شناسه درخواست"/>
                    </Columns>
                    <Columns>
                    <asp:BoundField DataField="OrderDate" HeaderText="تاریخ"/>
                    </Columns>
                    <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="شفارش دهنده"/>
                    </Columns>
                    <Columns>
                    <asp:BoundField DataField="Expr1" HeaderText="قیمت"/>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="showOrder" TypeName="ShowOrderDetails"></asp:ObjectDataSource>
                
                <br /><br />
               

            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label1" runat="server" Text="کاربر:" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" style="margin-right: 5px"></asp:Label><br />
                <asp:LinkButton ID="LinkButton100" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton100_Click">تغییر مشخصات کاربری</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton2" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton2_Click">تغییر رمز ورود</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton5" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton5_Click">خروج از بخش مدیریت</asp:LinkButton><br />
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
