<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="Projekti.aspx.cs" Inherits="Aplikacija_za_administraciju.Projekti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Projekti</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-8" runat="server">
                    <asp:PlaceHolder ID="phProjects" runat="server" />
                </div>
                <div class="col-md-4">
                    <asp:LinkButton ID="btnDodaj" CssClass="btn btn-success btn-lg" OnClick="btnDodaj_Click" Text="Dodaj projekt" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
