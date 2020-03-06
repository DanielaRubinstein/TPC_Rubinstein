<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="PresentacionWeb.Ingresar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .waves-light input { color:#fff; outline:none;}
        span#lblError{color: #D8000C!important;background-color: #FFD2D2!important;margin:10px 22px;font-size:16px;vertical-align:middle;}

    </style>
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
            <asp:Label ID="lblError" ClientIDMode="Static" runat="server" Text="Mail y/o Password incorrectos" Visible="false"></asp:Label>
        </div>
      </div>

        <div class="row">
            <asp:Button class="waves-effect waves-light btn" ClientIDMode="Static" OnClick="btnIngresar_Click" type="submit" runat="server" Text="Ingresar" CssClass="waves-effect waves-light btn"></asp:Button>
          <a class="waves-effect waves-light btn" href="FormularioCliente.aspx">Usuario Nuevo</a>
       </div>
    </form>
  </div>



</asp:Content>
