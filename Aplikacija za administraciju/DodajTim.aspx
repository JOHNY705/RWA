<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="DodajTim.aspx.cs" Inherits="Aplikacija_za_administraciju.DodajTim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Dodavanje tima</h1>
            <hr class="my-4">
            <div class="row">
                <div class="col-md-6 mt-4 mb-3">
                    <div class="form-group row my-4">
                        <label for="tbNaziv" class="col-sm-2 col-form-label font-weight-bold">Naziv:</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="tbNaziv" AutoCompleteType="None" CssClass="form-control"/>
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="tbNaziv" runat="server" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*"/>
                    </div>
                    <div class="form-group row my-4">
                        <label for="ddlVoditelj" class="col-sm-2 col-form-label font-weight-bold">Voditelj:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList runat="server" ID="ddlVoditelj" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="ddlVoditelj" runat="server" Display="Dynamic" ForeColor="Red"
                            Font-Size="Large" CssClass="col-sm-1" Text="*" InitialValue="-1"/>
                    </div>
                    <div class="form-group row my-4">
                        <div class="col-sm-9">
                            <asp:LinkButton ID="btnDodaj" CssClass="btn btn-primary btn-lg" OnClick="btnDodaj_Click" runat="server">Dodaj tim</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
