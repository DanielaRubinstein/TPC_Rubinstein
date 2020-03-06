<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoPedidos.aspx.cs" Inherits="PresentacionWeb.ListadoPedidos" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="ListadoPedidos" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        #title-row{border-bottom:solid #d4a2b7; font-weight:700;}
        #title-row p{border-right:solid #d4a2b7;}
        #product-row:nth-child(even){background:#ece6e6}
        .row{margin-bottom:0px!important;}

    </style>

  <div id="title-row" class="row">
    <div class="col s12 m2 l2"><p>ID PEDIDO</p></div>
    <div class="col s12 m2 l2"><p>SOLICITUD</p></div>
    <div class="col s12 m2 l2"><p>FECHA ENTREGA</p></div>
    <div class="col s12 m2 l2"><p>CLIENTE</p></div>
    <div class="col s12 m2 l2"><p>DIRECCION</p></div>
    <div class="col s12 m2 l2"><p>VER PEDIDO</p></div>
  </div>


    <%foreach (var item in listaPedidos){%>
    <div id="product-row" class="row">
    <div class="col s12 m2 l2"><p><%= item.IdPedido %></p></div>
    <div class="col s12 m2 l2"><p><%= (item.Fecha).ToString("MM/dd/yyyy H:mm") %></p></div>
    <div class="col s12 m2 l2"><p><%= (item.FechaEntrega).ToString("MM/dd/yyyy H:mm") %></p></div>
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
