<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DodajKlijenta.aspx.cs" Inherits="Aplikacija_za_administraciju.DodajKlijenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Dodavanje klijenta</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbNaziv" class="col-sm-2 col-form-label font-weight-bold">Naziv:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbNaziv" AutoCompleteType="None" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNaziv" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbKontakt" class="col-sm-2 col-form-label font-weight-bold">Kontakt:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbKontakt" AutoCompleteType="None" TextMode="Phone" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbKontakt" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbEmail" class="col-sm-2 col-form-label font-weight-bold">Email:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbEmail" AutoCompleteType="None" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-5">
                            <asp:LinkButton ID="btnDodaj" OnClick="btnDodaj_Click" CssClass="btn btn-primary btn-lg" runat="server">Dodaj klijenta</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
