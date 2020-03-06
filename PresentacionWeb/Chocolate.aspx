<%@ Page Title="Chocolate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chocolate.aspx.cs" Inherits="PresentacionWeb.Chocolate" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
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
   
<%--<asp:ListBox runat="server" AutoPostBack="true" Id="catProducto" OnLoad="Page_Load"/>--%>
    <div class="row" >
        <%foreach (var item in listaProducto){%>
        <div class="col s10 m4">
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
           <% }%>
    </div>

</asp:Content>
