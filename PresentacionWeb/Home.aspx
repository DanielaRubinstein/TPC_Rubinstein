<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PresentacionWeb.Home" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

<style>
.card .card-image .card-title {
    color: #fff;
    background: #facdce!important;
    position: absolute;
    bottom: 0;
    left: 0;
    max-width: 100%;
    padding: 4px!important;
}

.card .card-title {
    font-size: 20px!important;
    font-weight: 400;
}
</style>

    <form runat="server">
        <%for (int i = 0; i < listaProducto.Count; i++) 
            {
                var item = listaProducto[i];
                if (i % 3 == 0) {%>
                <div class="row">
                <%} %>
        <div class="col m4">
            <div class="card">
                <div class="card-image">
                    <img src="<%=item.Imagen%>" alt=""/>
                    <span class="card-title"><%= item.Descripcion %></span>
                </div>
                <div class="card-content">
                    <p>$ <%=item.Precio %></p>
                </div>
                 <div class="card-action">
                    <a class="waves-effect waves-light btn" href="Carrito.aspx?idProducto=<% = item.IdProducto.ToString() %>"><i class="material-icons">shopping_cart</i></a>
                </div>
            </div>
        </div>
                <% if ((i - 2) % 3 == 0 || i == listaProducto.Count-1) {%>
                </div>
               <% } %>
           <% }%>
        </form>

</asp:Content>
