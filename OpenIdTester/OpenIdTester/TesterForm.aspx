<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesterForm.aspx.cs" Inherits="OpenIdTester.TesterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <asp:Button ID="btn_Login" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue" Height="53px" OnClick="btn_Login_Click" Text="Login" Width="116px" />
&nbsp;&nbsp;
        <asp:Button ID="btn_Logout" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue" Height="53px" OnClick="btn_Logout_Click" Text="Logout" Width="128px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_UserNameTitle" runat="server" Font-Size="Large" ForeColor="#990000" Text="User Name: "></asp:Label>
        <asp:Label ID="lbl_UserName" runat="server" Font-Size="Large" ForeColor="#990000" Text="---"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txt_Results" runat="server" BackColor="White" BorderStyle="Ridge" Font-Size="Medium" ForeColor="Black" Height="534px" ReadOnly="True" TextMode="MultiLine" Width="774px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
