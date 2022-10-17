<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DodajProjekt.aspx.cs" Inherits="Aplikacija_za_administraciju.DodajProjekt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Dodavanje projekta</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbNaziv" class="col-sm-2 col-form-label font-weight-bold">Naziv:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbNaziv" AutoCompleteType="None" CssClass="form-control" runat="server" />
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="tbNaziv" Display="Dynamic" ForeColor="Red" Font-Size="Large" 
                            runat="server" CssClass="col-sm-1" Text="*"/>
                    </div>
                    <div class="form-group row my-4">
                        <label for="tbOpis" class="col-sm-2 col-form-label font-weight-bold">Opis:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="tbOpis" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="200" runat="server" />
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="tbOpis" runat="server" Display="Dynamic" ForeColor="Red" Font-Size="Large"
                            CssClass="col-sm-1" Text="*"/>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlKlijenti" class="col-sm-2 col-form-label font-weight-bold">Klijent:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList runat="server" ID="ddlKlijenti" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="ddlKlijenti" runat="server" InitialValue="-1" Display="Dynamic"
                            ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"/>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-10">
                            <asp:LinkButton ID="btnDodaj" CssClass="btn btn-primary btn-lg" OnClick="btnDodaj_Click" 
                                Text="Dodaj projekt" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
