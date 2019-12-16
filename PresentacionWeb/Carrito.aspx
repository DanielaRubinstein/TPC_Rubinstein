<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="PresentacionWeb.Carrito" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<%--     lista de productos seleccionados 
 <asp:Label ID="cantidad" Text="text" runat="server" />--%>
  <ul class="collection">
    <%foreach (var item in listaComprada){%>
    <li class="collection-item avatar">
      <img src="<%=item.Imagen%>" alt="" width="100" height="100"/>
      <span class="title"><%= item.Descripcion %></span>
      <p><%=item.Precio %></p>
      <a href="#!" class="secondary-content"><i class="material-icons">delete_forever</i></a>
    </li>  

       <% }%>
  </ul>

 <div class="row">
    <form class="col s12">
      <div class="row">
        <div class="input-field col s6">
          <i class="material-icons prefix">attach_money</i>
          <label id="icon_prefix" type="text" class="validate">TOTAL: <%= total %> </label>      
            <%--<p id="icon_prefix" type="text" class="validate" position="relative" left="30"><%= total %></p>--%>
        </div>
      </div>
    </form>
  </div>
   

</asp:Content>

