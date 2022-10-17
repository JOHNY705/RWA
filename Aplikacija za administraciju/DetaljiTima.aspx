<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DetaljiTima.aspx.cs" Inherits="Aplikacija_za_administraciju.DetaljiTima" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Detalji tima</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbNaziv" class="col-sm-2 col-form-label font-weight-bold">Naziv:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbNaziv" AutoCompleteType="None" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNaziv" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbVoditelj" class="col-sm-2 col-form-label font-weight-bold">Voditelj:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbVoditelj" AutoCompleteType="None" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbVoditelj" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnUredi" CssClass="btn btn-primary" runat="server" OnClick="btnUredi_Click">Uredi</asp:LinkButton>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnSpremi" CssClass="btn btn-success" runat="server" OnClick="btnSpremi_Click">Spremi</asp:LinkButton>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnTimovi" CssClass="btn btn-warning" runat="server" OnClick="btnTimovi_Click">Timovi</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-4">
                    <h5 class="mb-4">Članovi tima</h5>
                    <asp:PlaceHolder ID="phClanovi" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
