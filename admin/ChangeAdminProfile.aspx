﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeAdminProfile.aspx.cs" Inherits="admin_ChangeAdminProfile" %>

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
            <asp:GridView ID="GridView1" runat="server" Height="420px" 
                    AutoGenerateColumns="false" style="margin-right: 9px" Width="165px">
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="content">
                 <br />
                <asp:Label ID="Label3" runat="server" Text="مشخصات کاربری : " style="margin-right: 10px"></asp:Label>
                <br /><br />
                <asp:Label ID="Label5" runat="server" Text="نام : * " style="margin-right: 10px"></asp:Label><br />
                <asp:TextBox ID="TextBox1" runat="server" Width="300px" style="margin-right: 10px"></asp:TextBox><br />
                <asp:Label ID="Label10" runat="server" Text="نام خانوادگی : * " style="margin-right: 10px"></asp:Label><br />
                <asp:TextBox ID="TextBox4" runat="server" Width="300px" style="margin-right: 10px"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="نام کاربری : " 
                    style="margin-right: 10px"></asp:Label><br />
                <asp:Label ID="Label12" runat="server" Text="Label" style="margin-right: 10px"></asp:Label><br />
                <asp:Label ID="Label7" runat="server" Text="شماره تماس : * " style="margin-right: 10px"></asp:Label><br />
                <asp:TextBox ID="TextBox3" runat="server" Width="300px" style="margin-right: 10px"></asp:TextBox><br />
                <asp:Label ID="Label8" runat="server" Text="آدرس محل سکونت : " style="margin-right: 10px"></asp:Label><br />
                <asp:textbox id="TextArea1" runat="server" style="margin-right: 10px" 
                    Height="67px" Width="447px" ></asp:textbox><br /><br />
                <asp:Label ID="Label13" runat="server" Text="آدرس ایمیل : * " style="margin-right: 10px"></asp:Label><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                                Display="None" ErrorMessage="ایمیل را صحیح وارد نمایید" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:TextBox ID="TextBox5" runat="server" Width="300px" style="margin-right: 10px"></asp:TextBox><br />
                <asp:Label ID="Label9" runat="server" Text="وب سایت : " style="margin-right: 10px"></asp:Label><br />
                <asp:TextBox ID="TextBox6" runat="server" Width="300px" style="margin-right: 10px"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="تغییر مشخصات کاربری"  
                    style="margin-right: 10px" onclick="Button1_Click"/><br /> <br />
                    <asp:Label ID="Label50" runat="server" Visible="false" style="margin-right: 10px"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
                    <br />
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
