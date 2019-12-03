<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="PresentacionWeb.Carrito" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <%-- lista de productos seleccionados --%>
<%-- <asp:Label ID="cantidad" Text="text" runat="server" />--%>
  <ul class="collection">
    <%foreach (var item in listaComprada){%>
    <li class="collection-item avatar">
      <img src="" alt="" class="circle">
      <span class="title">Title</span>
      <p>First Line <br>
         Second Line
      </p>
      <a href="#!" class="secondary-content"><i class="material-icons">grade</i></a>
    </li>
       <% }%>
  </ul>


</asp:Content>

