<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DjelatnikUC.ascx.cs" Inherits="Aplikacija_za_administraciju.UserControls.DjelatnikUC" %>

<div class="card mb-3">
    <div class="card-body">
        <h5 class="card-title">
            <asp:Label ID="lblDjelatnikNaziv" runat="server" Text="Naziv"></asp:Label>
        </h5>
        <p class="card-text">
            <asp:Label ID="lblDjelatnikProjekti" runat="server" Text="Opis"></asp:Label>
        </p>
        <asp:LinkButton ID="btnDetalji" CssClass="btn btn-primary" OnClick="btnDetalji_Click" runat="server">Detalji djelatnika</asp:LinkButton>
    </div>
</div>
