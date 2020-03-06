<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoDetallePedido.aspx.cs" Inherits="PresentacionWeb.ListadoDetallePedido" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="ListadoDetallepedido" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #title-row{border-bottom:solid #d4a2b7; font-weight:700;}
        #title-row p{border-right:solid #d4a2b7;}
        #product-row:nth-child(even){background:#ece6e6}
        .row{margin-bottom:0px!important;}
        #btn-volver{margin-top:20px;}

    </style>
        
  <div id="title-row" class="row">
    <div class="col m4"><p>PRODUCTO</p></div>
    <div class="col m4"><p>CANTIDAD</p></div>
    <div class="col m4"><p>PRECIO</p></div>
  </div>

    <%foreach (var item in listaDetallePedido){%>
    <div id="product-row" class="row">
    <div class="col m4"><p><%= item.producto.Descripcion %></p></div>
    <div class="col m4"><p><%= item.Cantidad %></p></div>
    <div class="col m4"><p>$ <%= item.producto.Precio %></p></div>
    </div>
    <% }%>
            <div id="btn-volver" class="card-action">
                    <a class="waves-effect waves-light btn" href="ListadoPedidos.aspx">VOLVER</a>
            </div>

</asp:Content>
