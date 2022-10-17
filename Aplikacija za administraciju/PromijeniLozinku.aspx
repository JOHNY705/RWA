<%@ Page Title="" Language="C#" MasterPageFile="~/NavigacijaMaster.Master" AutoEventWireup="true" CodeBehind="PromijeniLozinku.aspx.cs" Inherits="Aplikacija_za_administraciju.PromijeniLozinku" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/custom-profil.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Promjena lozinke</h1>
            <hr class="my-4">
            <div class="form-group row my-4">
                <label for="tbTrenutnaLozinka" class="col-sm-3 col-form-label font-weight-bold">Unesite trenutnu lozinku:</label>
                <div class="col-sm-5 d-flex align-items-center">
                    <asp:TextBox ID="tbTrenutnaLozinka" AutoCompleteType="None" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                    ControlToValidate="tbTrenutnaLozinka" Display="Dynamic" ForeColor="Red" Font-Size="Large"
                    CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvTrenutnaLozinka" ControlToValidate="tbTrenutnaLozinka" OnServerValidate="CvTrenutnaLozinka_ServerValidate"
                    runat="server" ErrorMessage="Trenutna lozinka nije važeća!"
                    ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:CustomValidator>
            </div>
            <div class="form-group row mt-4 mb-3">
                <label for="tbNovaLozinka" class="col-sm-3 col-form-label font-weight-bold">Unesite novu lozinku:</label>
                <div class="col-sm-5 d-flex align-items-center">
                    <asp:TextBox ID="tbNovaLozinka" runat="server" AutoCompleteType="None" MaxLength="30" TextMode="Password"
                        CssClass="form-control"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNovaLozinka"
                    Display="Dynamic" ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label for="tbNovaLozinkaPonovno" class="col-sm-3 col-form-label font-weight-bold">Ponovno unesite novu lozinku:</label>
                <div class="col-sm-5 d-flex align-items-center">
                    <asp:TextBox ID="tbNovaLozinkaPonovno" AutoCompleteType="None" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ControlToValidate="tbNovaLozinkaPonovno" runat="server" Display="Dynamic"
                    ForeColor="Red" Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ControlToValidate="tbNovaLozinkaPonovno" ControlToCompare="tbNovaLozinka" Type="String" Operator="Equal"
                    runat="server" ErrorMessage="Lozinke se ne poklapaju! Pokuštaje ponovno." Display="Dynamic" ForeColor="Red"
                    Font-Size="Large" CssClass="col-sm-1" Text="*"></asp:CompareValidator>
                <asp:CompareValidator ControlToValidate="tbNovaLozinka" ControlToCompare="tbTrenutnaLozinka" Type="String" Operator="NotEqual"
                    runat="server" ErrorMessage="Nova lozinka mora biti različita od trenutne lozinke!" Display="Dynamic" ForeColor="Red"
                    Font-Size="Large" CssClass="col-sm-1" Text="*">
                </asp:CompareValidator>
            </div>
            <div>
                <asp:ValidationSummary runat="server" ForeColor="Red" Font-Size="Large"></asp:ValidationSummary>
            </div>
            <div class="form-group row mt-4">
                <div class="col-sm-3">
                    <asp:LinkButton ID="btnPromijeniLozinku" runat="server" CssClass="btn btn-primary" OnClick="btnPromijeniLozinku_Click">Potvrdi promjenu</asp:LinkButton>
                </div>
                <div class="col-sm-3">
                    <asp:LinkButton ID="btnOdustani" runat="server" CssClass="btn btn-danger" OnClick="btnOdustani_Click" 
                        CausesValidation="false">Odustani</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
