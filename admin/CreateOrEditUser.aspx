<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateOrEditUser.aspx.cs" Inherits="Pages_Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fa" lang="fa" dir="rtl">
<head runat="server">
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
        .style1
        {
            width: 171px;
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
            <asp:GridView ID="GridView1" runat="server" Height="402px" 
                    AutoGenerateColumns="false" style="margin-right: 9px" Width="165px">
                    <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="لیست محصولات پرفروش"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="content">
                <br />
                <asp:Label ID="Label3" runat="server" Text="ثبت نام" style="margin-right: 10px"></asp:Label><br /><br />
                <asp:Label ID="Label41" runat="server" Text="نام : * " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="300px" 
                    style="margin-right: 96px"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="نام خانوادگی : * " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="300px" 
                    style="margin-right: 46px"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="نام کاربری : * " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" Width="300px" 
                    style="margin-right: 53px"></asp:TextBox><br />
                <asp:Label ID="Label9" runat="server" Text="رمز عبور : * " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server" TextMode="Password" 
                    style="margin-right: 58px" Width="299px"></asp:TextBox><br />
                <asp:Label ID="Label10" runat="server" Text="تکرار رمز عبور : * " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox9" runat="server" TextMode="Password" 
                    style="margin-right: 23px" Width="298px"></asp:TextBox><br />
                <asp:Label ID="Label7" runat="server" Text="آدرس ایمیل :  *" style="margin-right: 10px"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4"
                                Display="None" ErrorMessage="ایمیل را صحیح وارد نمایید" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:TextBox ID="TextBox4" runat="server" Width="300px" 
                    style="margin-right: 52px"></asp:TextBox><br />
                <asp:Label ID="Label8" runat="server" Text="آدرس وب سایت : " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" Width="300px" 
                    style="margin-right: 38px" Height="22px"></asp:TextBox><br />
                <asp:Label ID="Label11" runat="server" Text="شماره تماس : * " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" Width="300px" 
                    style="margin-right: 45px"></asp:TextBox><br />
                <asp:Label ID="Label12" runat="server" Text="آدرس محل سکونت : " style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" Height="94px" Width="301px" 
                    style="margin-right: 22px"></asp:TextBox><br /><br />
                <asp:RadioButton ID="RadioButton1" GroupName="choice" Checked="true" style="margin-right: 10px" runat="server" 
                    Text="کاربر معمولی" /><br />
                <asp:RadioButton ID="RadioButton2" GroupName="choice" style="margin-right: 10px" runat="server" 
                    Text="کاربر با مجوز ادمین" /><br /><br />
                <asp:CheckBox ID="CheckBox1" Text="فعال" Checked="true" runat="server" style="margin-right: 10px"/><br /><br />
                <asp:Button ID="Button1" runat="server" Text="ایجاد کاربر" Width="118px" 
                    style="margin-right: 10px" onclick="Button1_Click"/><br /><br />
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" style="margin-right: 10px"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />


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
