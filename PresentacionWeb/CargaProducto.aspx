﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CargaProducto.aspx.cs" Inherits="PresentacionWeb.CargaProducto" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="CargaProducto" ContentPlaceHolderID="MainContent" runat="server">


   <div class="row">
    <form class="col s12" runat="server">
       <div class="row">
               <asp:Label ID="lblCreado" ClientIDMode="Static" runat="server" Text="Producto creado" Visible="false"></asp:Label>
        </div>
      <div class="row">
        <div class="input-field col s6">
        <asp:TextBox ID="txtDescripcion" ClientIDMode="Static" Name="txtDescripcion" CssClass="validate" type="text" runat="server" OnLoad="Page_Load" />
            <label for="txtDescripcion">Producto</label>
        </div>
       <div class="input-field col s6">
        <asp:TextBox ID="txtStockActual" ClientIDMode="Static" CssClass="validate" type="text" runat="server" OnLoad="Page_Load" />
          <label for="txtStockActual">Stock</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s4">
        <asp:TextBox ID="txtImpuesto" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtImpuesto">Impuesto</label>
        </div>
       <div class="input-field col s4">
        <asp:TextBox ID="txtCosto" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtCosto">Costo</label>
        </div>
        <div class="input-field col s4">
        <asp:TextBox ID="txtPrecio" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtPrecio">Precio</label>
        </div>
      </div>
       <div class="row">
       <div class="input-field col s12">
        <asp:TextBox ID="txtImagen" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtImagen">Imagen</label>
        </div>
      </div>
    <p>
      <label for="ckbCategoryChocolate">
          <%--<asp:CheckBox ID="CheckBox1" runat="server" />--%>
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryChocolate" runat="server"/>
        <span>Chocolate</span>
      </label>
    </p>
    <p>
        <label for="ckbCategoryCheesecake">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryCheesecake" runat="server"/>
        <span>Cheesecake</span>
        </label>
    </p>
    <p>
      <label for="ckbCategoryDulce">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryDulce" runat="server"/>
        <span>Dulce de leche</span>
      </label>
    </p>
    <p>
      <label for="ckbCategoryTematicas">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryTematicas" runat="server"/>
        <span>Tematicas</span>
      </label>
    </p>
    <p>
      <label for="ckbCategoryFrutales">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryFrutales" runat="server"/>
        <span>Frutales</span>
      </label>
    </p>
   <div style="margin-bottom:20px;" class="switch">
     <label>
      Inactivo
      <asp:CheckBox ClientIDMode="Static" ID="ckbEstado" runat="server" />
      <span class="lever"></span>
      Activo
    </label>
  </div>
   <asp:Button class="btn waves-effect waves-light btn-large" OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Aceptar" ></asp:Button>
  </form>
  </div>

</asp:Content>
