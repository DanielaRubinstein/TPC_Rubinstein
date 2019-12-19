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
    <form class="col s12" runat="server">
      <div class="row">
        <div class="input-field col s6">
          <i class="material-icons prefix">attach_money</i>
          <label id="icon_prefix" type="text" class="validate">TOTAL: <%= total %> </label>      
        </div>
      </div>
         <asp:Button class="btn waves-effect waves-light btn-large" OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Confirmar pedido" >
                <%--<i class="material-icons right">send</i>--%>
         </asp:Button>
    </form>
  </div>
   

</asp:Content>

