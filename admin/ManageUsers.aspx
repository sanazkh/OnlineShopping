<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="ManageUsers" %>

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
            <asp:GridView ID="GridView1" runat="server" Height="402px" 
                    AutoGenerateColumns="false" style="margin-right: 9px" Width="165px">
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="content">
                <br />
                <asp:Label ID="Label3" runat="server" Text="مدیریت کاربران" style="margin-right: 200px"></asp:Label><br /><br />
                <asp:Label ID="Label5" runat="server" Text="در زیر می توانید کاربرانی را که مایلید، برای فرستادن ایمیل به آنها انتخاب کنید یا با دکمۀ ارسال ایمیل به همه به کلّیّۀ آنها پیامی بفرستید : " style="margin-right: 5px"></asp:Label>
                <asp:GridView ID="GridView2" runat="server" Height="363px" Width="413px"
                    AllowPaging="True" AutoGenerateColumns="False" 
                    style="margin-left: 4px; margin-top: 13px; margin-right: 37px" 
                    DataSourceID="SqlDataSource1" DataKeyNames="UserID" OnPageIndexChanging="GridViewPageEventHandler" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="5" >
                    <Columns>
                        <asp:TemplateField HeaderText="ارسال ایمیل">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserID" HeaderText="کد کاربری" InsertVisible="False" 
                            ReadOnly="True" SortExpression="UserID" />
                        <asp:BoundField DataField="FirstName" HeaderText="نام" />
                        <asp:BoundField DataField="LastName" HeaderText="نام خانوادگی" />
                        <asp:BoundField DataField="Username" HeaderText="نام کاربری" />
                        <asp:CommandField CancelText="انصراف" DeleteText="حذف" 
                            ShowDeleteButton="True" UpdateText="بروزرسانی" SelectText="ویرایش" 
                            ShowCancelButton="False" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" 
                    SelectCommand="SELECT * FROM [Users]"
                    DeleteCommand="DELETE FROM [Users] WHERE [UserID] = @UserID">
                    <DeleteParameters>
                        <asp:Parameter Name="UserID" Type="Int64" />
                    </DeleteParameters>
                    </asp:SqlDataSource>
                    
                <br />
               <asp:Button ID="Button1" runat="server" Text="اضافه کردن کابر"
                   style="margin-right: 34px" onclick="Button1_Click" />
               <asp:Button ID="Button2" runat="server" Text="ارسال ایمیل به همه"
                   style="margin-right: 31px" onclick="Button2_Click" />
               <asp:Button ID="Button3" runat="server" Text="ارسال ایمیل به لیست انتخابی"
                   style="margin-right: 20px" onclick="Button3_Click" />

               

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

