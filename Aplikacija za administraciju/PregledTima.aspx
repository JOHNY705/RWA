<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="PregledTima.aspx.cs" Inherits="Aplikacija_za_administraciju.MojTim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Članovi tima</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-12" runat="server">
                    <asp:PlaceHolder runat="server" ID="phClanovi"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
