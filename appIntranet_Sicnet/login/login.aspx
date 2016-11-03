<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="appIntranet_Sicnet.login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>::SICNET::</title>
    <link rel="icon" type="image/png" href="../img/logoSis.png" />
    <link href="../tools/login/style.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro' rel='stylesheet' type='text/css' />
    
    <script>

        


    </script>
    
</head>
<body>
    <form id="form1" runat="server">    

          <h4> Bienvenido </h4>

        <asp:Login runat="server" ID="login1" OnAuthenticate="login_Authenticate"> 
            <LayoutTemplate>

                

                <asp:TextBox runat="server" CssClass="name" placeHolder="Enter Username" ID="UserName"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="UserNameRequerid" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio"></asp:RequiredFieldValidator>
                 <asp:TextBox runat="server" CssClass="pw" TextMode="Password"  placeHolder="Enter Password" ID="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server"  ID="PasswordRequerid" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria"></asp:RequiredFieldValidator>

                
                <asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal>
              
                <asp:Button runat="server" ID="LoginButton" CommandName="login" Text="Log in" ValidationGroup="ctl06" />
            </LayoutTemplate>
        </asp:Login>    
     
    </form>
</body>
</html>
