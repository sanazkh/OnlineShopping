<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="admin_ManageProducts" %>

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
                <asp:Label ID="Label3" runat="server" Text="مدیریت محصولات" 
                    style="margin-right: 200px"></asp:Label>
                <asp:GridView ID="GridView2" runat="server" Height="435px" Width="455px" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    style="margin-left: 4px; margin-top: 13px; margin-right: 12px;" DataKeyNames="ProductID" 
                    DataSourceID="SqlDataSource1" OnPageIndexChanging="GridViewPageEventHandler" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="5">
                    <Columns>
                        <asp:BoundField HeaderText="کد محصول" DataField="ProductID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                        <asp:BoundField HeaderText="نام محصول" DataField="ProductName" 
                            SortExpression="ProductName" />
                        <asp:BoundField HeaderText="کد مجوعه" DataField="CategoryID" 
                            SortExpression="CategoryID" />
                        <asp:CommandField CancelText="" DeleteText="حذف" SelectText="ویرایش" 
                            ShowCancelButton="False" ShowDeleteButton="True" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" 
                    SelectCommand="SELECT [ProductID], [ProductName], [CategoryID] FROM [Products]" DeleteCommand="DELETE FROM [OrderProduct] WHERE ProductID = @ProductID;DELETE FROM [Products] WHERE [ProductID] = @ProductID">
                    <DeleteParameters>
                         <asp:Parameter Name="ProductID" Type="Int64" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                <br />
                <asp:Button ID="Button1" runat="server" Text="اضافه کردن محصول" 
                    style="margin-right: 177px" onclick="Button1_Click" />

            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label1" runat="server" Text="کاربر:" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label" style="margin-right: 10px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" style="margin-right: 5px"></asp:Label><br />
                <asp:LinkButton ID="LinkButton1" runat="server" style="margin-right: 10px" 
                    onclick="LinkButton1_Click">تغییر مشخصات کاربری</asp:LinkButton><br />
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
