<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="appIntranet_Sicnet.login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>::SICNET::</title>
    <link rel="icon" type="image/png" href="../img/logoSis.png" />
    
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,300italic,400italic,500,700' rel='stylesheet' type='text/css'/>
    
    <link href="sources/log/style.css" rel="stylesheet" />
  
     
    
</head>
<body>
    <form id="form1" runat="server">    
        
          <div class="overlay"></div>
  <div class="modal position">
    <img src="sources/2.png" class="logo"/>
    <div class="brand login-text">
      Ingresa utilizando el usuario y contraseña que te fue asignado.<br><br>
      &nbsp;
      &nbsp;
      &nbsp;
        &nbsp;
        &nbsp;
        &nbsp;
        &nbsp;
        &nbsp;
        &nbsp;
        &nbsp;
        &nbsp;
        <center>
      © Derechos Reservados <%= DateTime.Now.Year.ToString() %>- ALO CHELITA S.A.C - SICNET 3.16.6
        </center>

    </div>
 
    <div class="form position">
    
      <div class="form-inner">
        <!-- Tabs-->
        <div class="tabs">
          <ul class="tabs">
           
            <li class="current" style="margin-left:100px" data-tab="member">
              <a href="#member">Acceso general</a>
            </li>
                      
          </ul>
          <!--Login Form -->
          <div  id="member">
            
                <asp:Login runat="server" ID="login1" OnAuthenticate="login_Authenticate"> 
                    <LayoutTemplate>

                       <asp:TextBox runat="server" CssClass="field" placeHolder="Enter Username" ID="UserName" ></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" ID="UserNameRequerid" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" CssClass="field" TextMode="Password"  placeHolder="Enter Password" ID="Password" ></asp:TextBox>    
                            <asp:RequiredFieldValidator runat="server"  ID="PasswordRequerid" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria"></asp:RequiredFieldValidator>         
                      <div class="clear"></div>
                      <input type="checkbox" name="rmbrme" id="custom-check" class="check"/><label for="custom-check" class="check-label secondary-text">Remember me</label><a href=""><span class="forgot secondary-text">Forgot password?</span></a>
                             <asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal>
                      <asp:Button runat="server" CssClass="flat-button signin" ID="LoginButton" CommandName="login"  Text="Log in" ValidationGroup="ctl06" />
                          
                    </LayoutTemplate>
                </asp:Login>    
     
           
          </div>
          
        </div>
      </div>
    </div>
  </div>
         <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="sources/log/index.js"></script>
     </form>
</body>
</html>
