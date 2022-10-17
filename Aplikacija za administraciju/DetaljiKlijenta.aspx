<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DetaljiKlijenta.aspx.cs" Inherits="Aplikacija_za_administraciju.DetaljiKlijenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Detalji klijenta</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbNaziv" class="col-sm-2 col-form-label font-weight-bold">Naziv:</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="tbNaziv" AutoCompleteType="None" CssClass="form-control" Enabled="false"/>
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="tbNaziv" runat="server" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*"/>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbKontakt" class="col-sm-2 col-form-label font-weight-bold">Kontakt:</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="tbKontakt" AutoCompleteType="None" CssClass="form-control" Enabled="false" />
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="tbKontakt" runat="server" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*" />
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbEmail" class="col-sm-2 col-form-label font-weight-bold">Email:</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="tbEmail" AutoCompleteType="None" CssClass="form-control" Enabled="false" />
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="tbEmail" runat="server" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*" />
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-3">
                            <asp:LinkButton Text="Uredi" ID="btnUredi" CssClass="btn btn-primary" runat="server" OnClick="btnUredi_Click"/>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton Text="Spremi" ID="btnSpremi" CssClass="btn btn-success" runat="server" OnClick="btnSpremi_Click" />
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton Text="Klijenti" ID="btnKlijenti" CssClass="btn btn-warning" runat="server" OnClick="btnKlijenti_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-4">
                    <h5 class="mb-4">Svi projekti klijenta</h5>
                    <asp:PlaceHolder runat="server" ID="phProjekti"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
