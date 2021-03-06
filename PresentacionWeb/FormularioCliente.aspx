﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="PresentacionWeb.FormularioCliente" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>--%>
<asp:Content ID="FormularioCliente" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        span#lblCreado{ color: #4F8A10!important;background: #DFF2BF!important;margin:10px 22px;font-size:16px;vertical-align:middle;}
        span#lblError{color: #D8000C!important;background: #FFD2D2!important;margin:10px 22px;font-size:16px;vertical-align:middle;}
        #txtCaracteres{color: #D8000C;background-color: #FFD2D2;margin:10px 22px;font-size:14px;vertical-align:middle;}
        .waves-light input{color:#fff;}
    </style>

     <script>    
         function validarCampos() {
             var nombre = document.getElementById("txtNombre").value;
             var apellido = document.getElementById("txtApellido").value;
             var direccion = document.getElementById("txtDireccion").value;
             var localidad = document.getElementById("txtLocalidad").value;
             var telefono = document.getElementById("txtTelefono").value;
             var mail = document.getElementById("txtMail").value;
             var password = document.getElementById("txtPassword").value;
             var valido = true;

             if (nombre === "" || apellido === "" || direccion === "" || localidad === "" || telefono === "" || mail === "" || password === "") {
                 valido = false;
             }
             //else {
             //    $("#txtNombre").removeClass("is-invalid");
             //    $("#txtNombre").addClass("is-valid");
             //}
<%--             if (!valido) {
                 document.getElementById("<%=lblError.ClientID%>").style.display = 'block';
                 document.getElementById("<%=lblCreado.ClientID%>").style.display = 'none';
                 return false;
             }
             else {
                 document.getElementById("<%=lblError.ClientID%>").style.display = 'none';
                 document.getElementById("<%=lblCreado.ClientID%>").style.display = 'block';
                 return true;
             }--%>
         }
         function onlyNumber(car) {
             var key = window.Event ? car.which : car.keyCode;
             return (key >= 48 && key <= 57)
         }

         function validateMin() {
             var Min_Length = 8;
             var length = $("#txtTelefono").val().length;
             if (length < Min_Length)
             {
                 $("#txtTelefono").addClass("invalid");
                 $("#txtTelefono").after("<p id='txtCaracteres'>La cantidad de caracteres es 8 o 10, usted escribio " + length + " caracteres</p>");
                 return false;
             }
         }

         function cleanError() {
             $("#txtCaracteres").remove();
             $("#txtTelefono").addClass("valid");
         }

         function onlyLetter(e) {
             key = e.keyCode || e.which;
             tecla = String.fromCharCode(key).toLowerCase();
             letter = " áéíóúabcdefghijklmnñopqrstuvwxyz";
             special = "8-37-39-46";
             special_key = false
             for (var i in special) {
                 if (key == special[i]) {
                     special_key = true;
                     break;
                 }
             }
             if (letter.indexOf(tecla) == -1 && !special_key) {
                 return false;
             }
         }

         function validateMail() {
             obj = document.getElementById("txtMail");
             valueForm = obj.value;
             var mailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
             if (valueForm.search(mailFormat) == 0) {
                 obj.className = "valid";
             } else {
                 obj.className = "invalid";
             }
         }

         function validatePass() {
             var Min_Length = 6;
             var length = $("#txtPassword").val().length;
             if (length < Min_Length) {
                 $("#txtPassword").addClass("invalid");
                 $("#txtPassword").after("<p id='txtCaracteres'>Minimo 6 caracteres</p>");
             }
         }


    </script>

    <div class="row">
    <form class="col s12" runat="server">
      <div class="row">
        <div class="input-field col s6">
        <asp:TextBox ID="txtNombre" ClientIDMode="Static" onKeyPress="return onlyLetter(event)" Name="txtNombre" CssClass="validate" required="required" data-error="debe completar los campos" type="text" runat="server" OnLoad="Page_Load" />
            <label for="txtNombre">Nombre</label>
        </div>
       <div class="input-field col s6">
        <asp:TextBox ID="txtApellido" ClientIDMode="Static" onKeyPress="return onlyLetter(event)" CssClass="validate" required="required" type="text" runat="server" OnLoad="Page_Load" />
          <label for="txtApellido">Apellido</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s4">
        <asp:TextBox ID="txtDireccion" ClientIDMode="Static" CssClass="validate" required="required" type="text" runat="server" />
          <label for="txtDireccion">Direccion</label>
        </div>
       <div class="input-field col s4">
        <asp:TextBox ID="txtLocalidad" ClientIDMode="Static" onKeyPress="return onlyLetter(event)" CssClass="validate" required="required" type="text" runat="server" />
          <label for="txtLocalidad">Localidad</label>
        </div>
        <div class="input-field col s4">
        <asp:TextBox ID="txtTelefono" ClientIDMode="Static" onKeyPress="return onlyNumber(event)" onFocusOut="return validateMin()" onKeyUp="return cleanError()" CssClass="validate" required="required" type="text" runat="server" MaxLength="10" />
          <label for="txtTelefono">Telefono</label>
        </div>
      </div>
       <div class="row">
       <div class="input-field col s12">
        <asp:TextBox ID="txtMail" ClientIDMode="Static" onFocusOut="return validateMail()" CssClass="validate" required="required" type="email" runat="server" />
          <label for="txtMail">Mail</label>
        </div>
         <div class="input-field col s12">
        <asp:TextBox ID="txtPassword" ClientIDMode="Static" CssClass="validate" onFocusOut="return validatePass()" onKeyUp="return cleanError()" required="required" type="password" runat="server" MaxLength="15" />
          <label for="txtPassword">Password</label>
        </div>
      </div>
       <asp:Button class="btn waves-effect waves-light btn-large" OnClientClick="return validarCampos()" OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Aceptar" ></asp:Button>
       <asp:Label ID="lblCreado" ClientIDMode="Static" runat="server" Text="Usuario creado, ya puede ingresar a su cuenta" Visible="false"></asp:Label>
       <asp:Label ID="lblError" ClientIDMode="Static" runat="server" Text="Este mail ya esta en uso. Intentelo nuevamente" Visible="false"></asp:Label>
    </form>
  </div>

</asp:Content>
