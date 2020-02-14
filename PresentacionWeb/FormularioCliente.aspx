<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="PresentacionWeb.FormularioCliente" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>--%>
<asp:Content ID="FormularioCliente" ContentPlaceHolderID="MainContent" runat="server">
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
         function soloNumeros(car) {
             var key = window.Event ? car.which : car.keyCode;
             //var Min_Length = 8;
             //var length = $("#txtTelefono").val().length;
             //if (length < Min_Length)
             //{
             //    $("#txtTelefono").after("<p style='color:red'>La cantidad de caracteres es 8 o 10, usted escribio " + length + " caracteres</p>");
             //}
             return (key >= 48 && key <= 57)
         }
    </script>

    <div class="row">
    <form class="col s12" runat="server">
      <div class="row">
        <div class="input-field col s6">
        <asp:TextBox ID="txtNombre" ClientIDMode="Static" Name="txtNombre" CssClass="validate" required="required" data-error="debe completar los campos" type="text" runat="server" OnLoad="Page_Load" />
            <label for="txtNombre">Nombre</label>
        </div>
       <div class="input-field col s6">
        <asp:TextBox ID="txtApellido" ClientIDMode="Static" CssClass="validate" required="required" type="text" runat="server" OnLoad="Page_Load" />
          <label for="txtApellido">Apellido</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s4">
        <asp:TextBox ID="txtDireccion" ClientIDMode="Static" CssClass="validate" required="required" type="text" runat="server" />
          <label for="txtDireccion">Direccion</label>
        </div>
       <div class="input-field col s4">
        <asp:TextBox ID="txtLocalidad" ClientIDMode="Static" CssClass="validate" required="required" type="text" runat="server" />
          <label for="txtLocalidad">Localidad</label>
        </div>
        <div class="input-field col s4">
        <asp:TextBox ID="txtTelefono" ClientIDMode="Static" CssClass="validate" required="required" type="text" onkey="return soloNumeros(event)" runat="server" MaxLength="10" />
          <label for="txtTelefono">Telefono</label>
        </div>
      </div>
       <div class="row">
       <div class="input-field col s12">
        <asp:TextBox ID="txtMail" ClientIDMode="Static" CssClass="validate" required="required" type="email" runat="server" />
          <label for="txtMail">Mail</label>
        </div>
         <div class="input-field col s12">
        <asp:TextBox ID="txtPassword" ClientIDMode="Static" CssClass="validate" required="required" type="password" runat="server" />
          <label for="txtPassword">Password</label>
        </div>
      </div>
       <asp:Button class="btn waves-effect waves-light btn-large" OnClientClick="return validarCampos()" OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Aceptar" ></asp:Button>
       <asp:Label ID="lblCreado" ClientIDMode="Static" runat="server" Text="Usuario creado, ya puede ingresar a su cuenta" Visible="false"></asp:Label>
       <asp:Label ID="lblError" ClientIDMode="Static" runat="server" Text="Este mail ya esta en uso. Intentelo nuevamente" Visible="false"></asp:Label>
    </form>
  </div>

</asp:Content>
