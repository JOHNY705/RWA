<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DetaljiDjelatnika.aspx.cs" Inherits="Aplikacija_za_administraciju.DetaljiDjelatnika" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Detalji djelatnika</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbIme" class="col-sm-2 col-form-label font-weight-bold">Ime:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbIme" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbIme" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbPrezime" class="col-sm-2 col-form-label font-weight-bold">Prezime:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbPrezime" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPrezime" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlTip" class="col-sm-2 col-form-label font-weight-bold">Tip:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="ddlTip" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbEmail" class="col-sm-2 col-form-label font-weight-bold">Email:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbEmail" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbDatumZaposlenja" class="col-sm-2 col-form-label font-weight-bold">Zaposlen:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbDatumZaposlenja" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlTim" class="col-sm-2 col-form-label font-weight-bold">Tim:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="ddlTim" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnUredi" CssClass="btn btn-primary" runat="server" OnClick="btnUredi_Click">Uredi</asp:LinkButton>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnSpremi" CssClass="btn btn-success" runat="server" OnClick="btnSpremi_Click">Spremi</asp:LinkButton>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnDjelatnici" CssClass="btn btn-warning" runat="server" OnClick="btnDjelatnici_Click">Djelatnici</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-4">
                    <h5 class="mb-4">Projekti na kojima djelatnik trenutno radi</h5>
                    <asp:PlaceHolder ID="phProjektiDjelatnika" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
