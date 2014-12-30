<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Pages_Categories" %>

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
            <asp:GridView ID="GridView1" runat="server" Height="401px" 
                    AutoGenerateColumns="false" style="margin-right: 9px" Width="165px">
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="content">
            <br />
                <asp:Label ID="Label2" runat="server" Text="لیست مجموعه های سایت" style="margin-right: 177px; font:large"></asp:Label>
            <br /><br />
                <asp:Button ID="Button1" runat="server" Text="جستجو در کلّیۀ محصولات" 
                    style="text-align:center; font:large; margin-right:170px" Width="150px" onclick="Button1_Click" />

            <asp:GridView ID="GridView2" runat="server" Height="436px" 
                    AutoGenerateColumns="False" Width="463px" AllowPaging="True" 
                    OnPageIndexChanging="GridViewPageEventHandler" 
                    DataSourceID="SqlDataSource1" 
                    style="margin-right: 8px; margin-top: 13px;" DataKeyNames="CategoryID" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="5" >
                    <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="کد مجموعه" 
                            SortExpression="CategoryID" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="CategoryName" HeaderText="نام مجموعه" 
                            SortExpression="CategoryName" />
                        <asp:BoundField DataField="CategoryDescription" HeaderText="توصیف مجموعه" 
                            SortExpression="CategoryDescription" />
                        <asp:CommandField SelectText="محصولات این مجموعه" ShowCancelButton="False" 
                            ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" 
                    SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
                
            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label10" runat="server" Text="ورود به صفحۀ کاربری"></asp:Label><br /><br />
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
                    <asp:Label ID="Label12" runat="server" Visible="false"></asp:Label>
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