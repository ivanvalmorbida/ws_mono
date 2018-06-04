<%@ Page Language="C#" Inherits="ws_mono.login" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>login</title>
</head>
<body>
	<form id="form1" runat="server">
        <asp:TextBox ID="txtUsuario" runat="server" Columns="15"></asp:TextBox>
        <br>
        <asp:TextBox ID="txtSenha" runat="server" Columns="15" TextMode="Password"></asp:TextBox>
        <br>
        <asp:Button ID="btnOk" runat="server" Text="Ok" Width="100px" OnClick="btnOkClicked"/>
	</form>
</body>
</html>
