<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="Djelatnici.aspx.cs" Inherits="Aplikacija_za_administraciju.Djelatnici" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Djelatnici</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-8" runat="server">
                    <asp:PlaceHolder ID="phDjelatnici" runat="server" />
                </div>
                <div class="col-md-4">
                    <asp:LinkButton ID="btnDodaj" CssClass="btn btn-success btn-lg" OnClick="btnDodaj_Click" Text="Dodaj djelatnika" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
