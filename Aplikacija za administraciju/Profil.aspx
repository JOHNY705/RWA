<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="Aplikacija_za_administraciju.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron" style="padding-top:30px; padding-bottom:30px;">
            <h1 class="display-4">Profil</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-8 mt-4 mb-4">
                    <div class="form-group row my-4">
                        <label class="col-sm-4 col-form-label text-black font-weight-bold">Ime</label>
                        <div class="col-sm-9 d-flex align-items-center">
                            <asp:Label ID="lblIme" runat="server" CssClass="col-form-label text-black"/>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <label class="col-sm-4 col-form-label text-black font-weight-bold">Prezime</label>
                        <div class="col-sm-9 d-flex align-items-center">
                            <asp:Label ID="lblPrezime" runat="server" CssClass="col-form-label text-black"/>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlTip" class="col-sm-4 col-form-label text-black font-weight-bold">Tip</label>
                        <div class="col-sm-9 d-flex align-items-center">
                            <asp:Label Text="Tip djelatnika" runat="server" ID="lblTipDjelatnika" CssClass="col-form-label"/>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbEmail" class="col-sm-4 col-form-label font-weight-bold">Email</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="tbEmail" AutoCompleteType="None" CssClass="form-control" Enabled="false"/>
                        </div>
                        <asp:RequiredFieldValidator ID="emailValidator" ControlToValidate="tbEmail" runat="server" 
                            Display="Dynamic" ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"/>
                    </div>
                    <div class="form-group row my-4">
                        <label class="col-sm-4 col-form-label font-weight-bold">Datum zaposlenja</label>
                        <div class="col-sm-9 d-flex align-items-center">
                            <asp:Label ID="lblDatumZaposlenja" runat="server" CssClass="col-form-label"/>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <label class="col-sm-4 col-form-label font-weight-bold">Tim</label>
                        <div class="col-sm-9 d-flex align-items-center">
                            <asp:Label ID="lblTim" runat="server" CssClass="col-form-label"/>
                        </div>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-4">
                            <asp:LinkButton ID="btnUredi" Text="Uredi" CssClass="btn btn-primary" OnClick="btnUredi_Click" runat="server" />
                        </div>
                        <div class="col-sm-4">
                            <asp:LinkButton ID="btnSpremi" Text="Spremi" CssClass="btn btn-warning" OnClick="btnSpremi_Click" runat="server" />
                        </div>
                        <div class="col-sm-4">
                            <asp:LinkButton ID="btnPromijeniLozinku" Text="Promijeni lozinku" CssClass="btn btn-danger" runat="server" OnClick="btnPromijeniLozinku_Click"/>
                        </div>
                    </div>
                </div>
                <div class="col-md-6" runat="server" visible="false" id="promjenaLozinkeContainer"></div>
            </div>
        </div>
    </div>   
</asp:Content>
