<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="PresentacionWeb.Ingresar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
    <form class="col s12" runat="server">
       <div class="row">
        <div class="input-field col s12">
           <asp:TextBox ID="txtMail" ClientIDMode="Static" TextMode="Email" class="validate" runat="server"></asp:TextBox>
          <label for="txtMail">Email</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12">
           <asp:TextBox ID="txtPass" ClientIDMode="Static" TextMode="Password" class="validate" runat="server"></asp:TextBox>
          <label for="txtPass">Password</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s12">
            <asp:Label ID="lblError" runat="server" Text="Mail y/o Password incorrectos" CssClass="red-text" Visible="false"></asp:Label>
        </div>
      </div>
     <asp:Button class="btn waves-effect waves-light btn-large"  OnClick="btnIngresar_Click" type="submit" name="action" runat="server" Text="Ingresar" >
     </asp:Button>
            <div class="card-action">
                    <a class="waves-effect waves-light btn" href="FormularioCliente.aspx">Usuario Nuevo</a>
            </div>
    </form>
  </div>



</asp:Content>
