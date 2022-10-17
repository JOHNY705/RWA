<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DetaljiProjekta.aspx.cs" Inherits="Aplikacija_za_administraciju.DetaljiProjekta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Detalji projekta</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbNaziv" class="col-sm-2 col-form-label font-weight-bold">Naziv:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbNaziv" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNaziv" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbDatum" class="col-sm-2 col-form-label font-weight-bold">Kreiran:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbDatum" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbDatum" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbVoditelj" class="col-sm-2 col-form-label font-weight-bold">Voditelj:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbVoditelj" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbVoditelj" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbKlijent" class="col-sm-2 col-form-label font-weight-bold">Klijent:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbKlijent" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbKlijent" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbOpis" class="col-sm-2 col-form-label font-weight-bold">Opis:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbOpis" runat="server" AutoCompleteType="None" CssClass="form-control" TextMode="MultiLine"
                                Enabled="false" MaxLength="200"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbOpis" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnUredi" CssClass="btn btn-primary" OnClick="btnUredi_Click" runat="server">Uredi</asp:LinkButton>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnSpremi" CssClass="btn btn-success" OnClick="btnSpremi_Click" runat="server">Spremi</asp:LinkButton>
                        </div>
                        <div class="col-sm-3">
                            <asp:LinkButton ID="btnProjekti" CssClass="btn btn-warning" OnClick="btnProjekti_Click" runat="server">Projekti</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-4">
                    <h5 class="mb-4">Djelatnici koji trenutno rade na projektu</h5>
                    <asp:PlaceHolder ID="phDjelatniciNaProjektu" runat="server" />
                </div> 
            </div>
        </div>
    </div>
</asp:Content>
