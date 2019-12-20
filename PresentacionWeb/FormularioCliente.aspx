<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="PresentacionWeb.FormularioCliente" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="FormularioCliente" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
    <form class="col s12" runat="server">
      <div class="row">
        <div class="input-field col s6">
        <asp:TextBox ID="txtNombre" ClientIDMode="Static" Name="txtNombre" CssClass="validate" type="text" runat="server" OnLoad="Page_Load" />
            <label for="txtNombre">Nombre</label>
        </div>
       <div class="input-field col s6">
        <asp:TextBox ID="txtApellido" ClientIDMode="Static" CssClass="validate" type="text" runat="server" OnLoad="Page_Load" />
          <label for="txtApellido">Apellido</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s4">
        <asp:TextBox ID="txtDireccion" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtDireccion">Direccion</label>
        </div>
       <div class="input-field col s4">
        <asp:TextBox ID="txtLocalidad" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtLocalidad">Localidad</label>
        </div>
        <div class="input-field col s4">
        <asp:TextBox ID="txtTelefono" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtTelefono">Telefono</label>
        </div>
      </div>
       <div class="row">
       <div class="input-field col s12">
        <asp:TextBox ID="txtMail" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtMail">Mail</label>
        </div>
         <div class="input-field col s12">
        <asp:TextBox ID="txtPassword" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtPassword">Password</label>
        </div>
      </div>

     <asp:Label ID="lblCreado" runat="server" Text="Usuario creado, ya puede ingresar a su cuenta" CssClass="green-text" Visible="false"></asp:Label>
     <asp:Label ID="lblError" runat="server" Text="Intentelo nuevamente" CssClass="red-text" Visible="false"></asp:Label>

       <asp:Button class="btn waves-effect waves-light btn-large" OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Aceptar" ></asp:Button>
  </form>
  </div>

</asp:Content>
