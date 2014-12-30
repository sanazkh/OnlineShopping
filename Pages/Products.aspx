<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Pages_Products" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fa" lang="fa" dir="rtl">
<head runat="server">
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
                <li><asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton6_Click">صفحۀ اصلی</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton7_Click">محصولات</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton10_Click">ثبت نام در سایت</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton8_Click">دربارۀ ما</asp:LinkButton> | &nbsp;</li>
                <li><asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton9_Click">تماس با ما</asp:LinkButton></li>
            </ul>
        </div>
        <div id="main">
            <div id="top10">
            <asp:GridView ID="GridView1" runat="server" Height="405px" 
                    AutoGenerateColumns="false" style="margin-right: 9px" Width="165px">
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="content">
                <br />
                <asp:Label ID="Label3" runat="server" style="margin-right: 120px"></asp:Label><br /><br />
                <asp:Label ID="Label7" runat="server" Text="لیست بر اساس : " style="margin-right: 10px"></asp:Label><br />
                <asp:RadioButton ID="RadioButton1" Text="تاریخ و زمان ثبت" GroupName="choice" runat="server" style="margin-right: 10px"/>
                <asp:RadioButton ID="RadioButton2" Text="پرفروش ترین ها" GroupName="choice" runat="server"/>
                <asp:RadioButton ID="RadioButton3" Text="بیشترین بازدید" GroupName="choice" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="دوباره لیست کردن" 
                    style="margin-right: 30px" onclick="Button1_Click" /><br /><br />
                <asp:Label ID="Label4" runat="server" Text="با کلیلک بر روی نام محصول می توانید جزئیات آن را ببینید" style="margin-right: 10px"></asp:Label>
                <br /><br />
                <asp:GridView ID="GridView2" style="margin-right: 12px" runat="server" AutoGenerateColumns="False" 
                     AllowPaging="True" Height="364px" 
                    Width="456px" DataKeyNames="ProductID" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" OnPageIndexChanging="GridViewPageEventHandler" PageSize="5" >
                    <Columns>
                        
                        <asp:BoundField DataField="ProductID" HeaderText="کد محصول" 
                            InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                        <asp:BoundField DataField="ProductName" HeaderText="نام محصول" 
                            SortExpression="ProductName" />
                        <asp:CommandField SelectText="دیدن جزئیات محصول" ShowCancelButton="False" 
                            ShowSelectButton="True" />    
                    </Columns>
                </asp:GridView>

            </div>
            <div id="right-side">
                <br />
                <asp:Label ID="Label5" runat="server" Text="ورود به صفحۀ کاربری"></asp:Label><br /><br />
                <asp:Label ID="Label6" runat="server" Text="نام کاربری  : "></asp:Label>
                <asp:TextBox ID="UserName" runat="server" Width="100px" 
                    ></asp:TextBox>
                <br />
                <asp:Label ID="Label1" runat="server" Text="رمز عبور     : " ></asp:Label>
                <asp:TextBox ID="Password" runat="server" Width="100px" 
                    style="margin-right: 4px" TextMode="password"></asp:TextBox><br /><br />
                <asp:Button ID="Login" runat="server" Text="ورود" Width="95px" 
                    style="margin-right: 15px; margin-top: 0px;" onclick="Login_Click" 
                    Height="28px" /><br />
                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
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
