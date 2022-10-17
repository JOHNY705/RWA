<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjektUC.ascx.cs" Inherits="Aplikacija_za_administraciju.UserControls.ProjektUC" %>

<div class="card bg-light mb-3">
    <div class="card-body">
        <h5 class="card-title">
            <asp:Label ID="lblProjektNaslov" Text="Naslov" runat="server" />
        </h5>
        <p class="card-text">
            <asp:Label ID="lblProjektOpis" Text="Opis" runat="server" />
        </p>
        <asp:LinkButton ID="btnDetalji" CssClass="btn btn-primary" OnClick="btnDetalji_Click" Text="Detalji projekta" runat="server" />
    </div>
</div>
