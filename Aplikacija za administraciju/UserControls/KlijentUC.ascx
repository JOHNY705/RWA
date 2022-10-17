<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KlijentUC.ascx.cs" Inherits="Aplikacija_za_administraciju.UserControls.KlijentUC" %>
<div class="card mb-3">
    <div class="card-body">
        <h5 class="card-title">
            <asp:Label Text="Naslov" ID="lblKlijentNaziv" runat="server" />
        </h5>
        <asp:LinkButton ID="btnDetalji" CssClass="btn btn-primary" OnClick="btnDetalji_Click" Text="Detalji klijenta" runat="server" />
    </div>
</div>
