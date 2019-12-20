<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoPedidos.aspx.cs" Inherits="PresentacionWeb.ListadoPedidos" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="ListadoPedidos" ContentPlaceHolderID="MainContent" runat="server">

  <div class="row">
    <div class="col s12 m2 l2"><p>ID PEDIDO</p></div>
    <div class="col s12 m2 l2"><p>SOLICITUD</p></div>
    <div class="col s12 m2 l2"><p>FECHA ENTREGA</p></div>
    <div class="col s12 m2 l2"><p>CLIENTE</p></div>
    <div class="col s12 m2 l2"><p>DIRECCION</p></div>
    <div class="col s12 m2 l2"><p>VER PEDIDO</p></div>
  </div>


    <%foreach (var item in listaPedidos){%>
    <div class="row">
    <div class="col s12 m2 l2"><p><%= item.IdPedido %></p></div>
    <div class="col s12 m2 l2"><p><%= item.Fecha %></p></div>
    <div class="col s12 m2 l2"><p><%= item.FechaEntrega %></p></div>
    <div class="col s12 m2 l2"><p><%= item.cliente.Nombre %></p></div>
    <div class="col s12 m2 l2"><p><%= item.cliente.Direccion %></p></div>
    <div class="col s12 m2 l2">
        <p>
            <div class="card-action">
                    <a class="waves-effect waves-light btn" href="ListadoDetallePedido.aspx?idPedido=<% = item.IdPedido.ToString() %>">VER</a>
            </div>
        </p>
    </div>
               
         </div>
    <% }%>


</asp:Content>
