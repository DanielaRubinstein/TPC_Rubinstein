﻿<%@ Page Title="Dulce de leche" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dulce-de-Leche.aspx.cs" Inherits="PresentacionWeb.Dulce_de_Leche" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
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
                    <a class="waves-effect waves-light btn" href="#"><i class="material-icons">shopping_cart</i></a>
                </div>
            </div>
        </div>
           <% }%>
    </div>
</asp:Content>
