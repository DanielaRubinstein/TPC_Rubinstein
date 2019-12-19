<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerDetallePedido.aspx.cs" Inherits="VerDetallePedido" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="VerDetallePedido" ContentPlaceHolderID="MainContent" runat="server">

    
  <div class="row">
    <div class="col s12 m3 l3"><p>PRODUCTO</p></div>
    <div class="col s12 m3 l3"><p>CANTIDAD</p></div>
    <div class="col s12 m3 l3"><p>PRECIO</p></div>
    <%--<div class="col s12 m3 l3"><p>PRECIO</p></div>--%>
  </div>

    <%foreach (var item in detallePedido){%>
    <div class="row">
    <div class="col s12 m3 l3"><p><%= item.Producto.Descripcion %></p></div>
    <div class="col s12 m3 l3"><p><%= item.Cantidad %></p></div>
    <div class="col s12 m3 l3"><p><%= item.Precio %></p></div>
<%--    <div class="col s12 m2 l2"><p><%= item.cliente.Nombre %></p></div>--%>   
    </div>
    <% }%>



</asp:Content>
