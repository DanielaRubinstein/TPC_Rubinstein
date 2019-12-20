<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoDetallePedido.aspx.cs" Inherits="PresentacionWeb.ListadoDetallePedido" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="ListadoDetallepedido" ContentPlaceHolderID="MainContent" runat="server">
        
  <div class="row">
    <div class="col s12 m3 l3"><p>PRODUCTO</p></div>
    <div class="col s12 m3 l3"><p>CANTIDAD</p></div>
    <div class="col s12 m3 l3"><p>PRECIO</p></div>
  </div>

    <%foreach (var item in listaDetallePedido){%>
    <div class="row">
    <div class="col s12 m3 l3"><p><%= item.producto.Descripcion %></p></div>
    <div class="col s12 m3 l3"><p><%= item.Cantidad %></p></div>
    <div class="col s12 m3 l3"><p><%= item.producto.Precio %></p></div>
    </div>
    <% }%>
            <div class="card-action">
                    <a class="waves-effect waves-light btn" href="ListadoPedidos.aspx">VOLVER</a>
            </div>

</asp:Content>
