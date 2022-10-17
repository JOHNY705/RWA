<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aplikacija_za_administraciju.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/custom_login.css" rel="stylesheet" />
</head>
<body>
    <form id="loginForm" class="w-100 h-100 d-flex justify-content-center align-items-center" runat="server">
        <div class="container w-50 h-auto dropShadow">
            <div class="row">
                <div class="col d-flex flex-column align-items-center">
                    <div>
                        <h1 class="mt-4 mb-2 display-6" id="welcome-tekst">Dobrodošli!</h1>
                    </div>
                    <div>
                        <h5 class="mt-1 mb-2 display-6 text-black">Aplikacija za administraciju i izvještavanje</h5>
                    </div>
                    <div>
                        <asp:Label Text="" ID="errorMessage" CssClass="text-danger" runat="server" Visible="false"/>
                    </div>
                    <div class="form-group w-50 mt-2 mb-3 d-flex flex-row">
                        <asp:TextBox runat="server" ID="tbUsername" CssClass="inputField span6" Placeholder="Email" Autofocus="true"/>
                        <asp:RequiredFieldValidator ControlToValidate="tbUsername" runat="server" Display="Dynamic" ForeColor="Red" 
                            Font-Size="Large" Text="*"/>
                    </div>
                    <div class="form-group w-50 mt-3 mb-4 d-flex flex-row">
                        <asp:TextBox runat="server" ID="tbPassword" CssClass="inputField span6" Placeholder="Lozinka" TextMode="Password"/>
                        <asp:RequiredFieldValidator ControlToValidate="tbPassword" runat="server" Display="Dynamic" ForeColor="Red" 
                            Font-Size="Large" Text="*"/>
                    </div>
                    <div class="form-check w-50 mb-5">
                        <asp:CheckBox Text="Zapamti me" runat="server" ID="cbRememberMe" CssClass="form-check-input cbZapamtiMe"/>
                    </div>
                    <div class="form-group w-50 mb-3">
                        <asp:Button Text="Prijava" runat="server" ID="btnPrijava" CssClass="btn-block gumbPrijava" OnClick="btnPrijava_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
