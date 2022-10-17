<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimUC.ascx.cs" Inherits="Aplikacija_za_administraciju.UserControls.TimUC" %>

<div class="card mb-3">
    <div class="card-body">
        <h5 class="card-title">
            <asp:Label ID="lblTimNaziv" Text="Naslov" runat="server" />
        </h5>
        <asp:LinkButton ID="btnDetalji" CssClass="btn btn-primary" OnClick="btnDetalji_Click" Text="Detalji tima" runat="server" />
    </div>
</div>
