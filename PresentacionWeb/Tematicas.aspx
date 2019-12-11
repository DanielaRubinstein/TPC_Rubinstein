<%@ Page Title="Tematicas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tematicas.aspx.cs" Inherits="PresentacionWeb.Tematicas" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row" >
        <%foreach (var item in listaProducto){%>
        <div class="col s10 m4">
            <div class="card">
                <div class="card-image">
                    <img src="<%=item.Imagen%>" alt=""/>
                    <span class="card-title"><%= item.Descripcion %></span>
                </div>
                <div class="card-content">
                    <p><%=item.Precio %></p>
                </div>
                <div class="card-action">
                   <a class="waves-effect waves-light btn" href="Carrito.aspx?idProducto=<% = item.IdProducto.ToString() %>"><i class="material-icons">shopping_cart</i></a>
                </div>
            </div>
        </div>
           <% }%>
    </div>
</asp:Content>
