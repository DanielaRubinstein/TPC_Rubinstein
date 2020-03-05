<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoProductos.aspx.cs" Inherits="PresentacionWeb.ListadoProductos" %>
<asp:Content ID="ListadoProductos" ContentPlaceHolderID="MainContent" runat="server">
    <style>

        .card .card-image .card-title {
            color: #fff;
            background: #facdce;
            position: absolute;
            bottom: 0;
            left: 0;
            max-width: 100%;
            padding: 4px!important;
            }
        .card .card-title {
            font-size: 20px;
            font-weight: 400;
            }

    </style>


    <form runat="server">
        <%for (int i = 0; i < listaProductos.Count; i++) 
            {
                var item = listaProductos[i];
                if (i % 4 == 0) {%>
                <div class="row">
                <%} %>
        <div class="col m3">
            <div class="card">
                <div class="card-image">
                    <img src="<%=item.Imagen%>" alt=""/>
                    <span class="card-title"><%= item.Descripcion %></span>
                </div>
                <div class="card-content">
                    <p><%=item.Precio %></p>
                </div>
                <div class="card-action">
                    <a class="waves-effect waves-light btn" href="EditarProducto.aspx?idProducto=<% = item.IdProducto.ToString() %>">Editar</a> 
                    <label for="ckbPublicado">
                             <span ><%=item.Estado ? "Publicado" : "Despublicado" %></span>
                     </label>
                </div>
            </div>
        </div>
                <% if ((i - 3) % 4 == 0 || i == listaProductos.Count-1) {%>
                </div>
               <% } %>
           <% }%>
        </form>
</asp:Content>

