<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DodajDjelatnika.aspx.cs" Inherits="Aplikacija_za_administraciju.DodajDjelatnika" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Dodavanje djelatnika</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbIme" class="col-sm-2 col-form-label font-weight-bold">Ime:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbIme" AutoCompleteType="None" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbIme" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbPrezime" class="col-sm-2 col-form-label font-weight-bold">Prezime:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbPrezime" AutoCompleteType="None" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPrezime" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlTip" class="col-sm-2 col-form-label font-weight-bold">Tip:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="ddlTip" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTip" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbEmail" class="col-sm-2 col-form-label font-weight-bold">Email:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbEmail" AutoCompleteType="None" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbLozinka" class="col-sm-2 col-form-label font-weight-bold">Lozinka:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbLozinka" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbLozinka" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlTimovi" class="col-sm-2 col-form-label font-weight-bold">Tim:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="ddlTimovi" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-6">
                            <asp:LinkButton ID="btnDodaj" CssClass="btn btn-primary btn-lg" OnClick="btnDodaj_Click" runat="server">Dodaj djelatnika</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
