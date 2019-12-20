<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoProductos.aspx.cs" Inherits="PresentacionWeb.ListadoProductos" %>
<asp:Content ID="ListadoProductos" ContentPlaceHolderID="MainContent" runat="server">


   <div class="row" >
        <%foreach (var item in listaProductos){%>
        <div class="col s10 m2">
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
                </div>
            </div>
        </div>
           <% }%>
    </div>
<%--    <form runat="server">
     <div class="row" >
         <asp:Repeater runat="server" ID="repetidor">
         <ItemTemplate>
        <div class="col s10 m2">
            <div class="card">
                <div class="card-image">
                     <img src="<%#Eval("Imagen") %>" alt=""/>
                    <span class="card-title"><%#Eval("Descripcion")%></span>
                </div>
                <div class="card-content">
                    <p><%#Eval("Precio")%></p>
                </div>
                <div class="card-action">
                   <a class="waves-effect waves-light btn" href="CargaProducto.aspx?IdProducto<%#Eval("IdProducto")%>">Modificar</a>
                    <asp:Button ID="btnArgumento" CssClass="waves-effect waves-light btn" Text="Modif" CommandArgument='<%#Eval("IdProducto")%>' CommandName="idProducto" runat="server" OnClick="btnModificar_Click" />
                </div>
            </div>
        </div>
         </ItemTemplate>
        </asp:Repeater>
    </div>
   </form>--%>


</asp:Content>

