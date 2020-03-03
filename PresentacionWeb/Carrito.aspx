<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="PresentacionWeb.Carrito" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker();
            $('.timepicker').timepicker();
            
        });

        $(function () {
            $("#txtFecha").datepicker({
                firstDay: 0,
                minDate: new Date(),
                i18n: {
                    months: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                    monthsShort: ['Ene','Feb','Mar','Abr','May','Jun','Jul','Ago','Sep','Oct','Nov','Dic'],
                    weekdays: ['Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo'],
                    weekdaysShort: ['Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab', 'Dom'],
                    weekdaysAbbrev: ['L', 'M', 'M', 'J', 'V', 'S', 'D']
                }
            });
        });

        $(function () {
            $("#txtHora").timepicker({
                fromNow: 7200000,
                twelveHour: false
            });
        });

        function cleanErrorDate() {
            $("#txtFecha").addClass("valid");
        }

        function validateDate() {
            var date = $("#txtFecha").val();
            if (date === "") {
                $("#txtFecha").removeClass("valid");
                $("#txtFecha").addClass("invalid");  
            }
            else {
                $("#txtFecha").removeClass("invalid");
                $("#txtFecha").addClass("valid");
            }            
        }

        function cleanErrorHour() {
            $("#txtError").remove();
            $("#txtHora").addClass("valid");
        }

        function validateHour() {
            var hour = $("#txtHora").val();
            if (hour <= '07:30' || hour >= '21:30') {
                $("#txtHora").removeClass("valid");
                $("#txtHora").addClass("invalid");
                $("#txtHora").after("<p id='txtError' style='color:red'>El horario de atencion es de 08hs a 20hs</p>");
            }
            else {
                $("#txtHora").removeClass("invalid");
                $("#txtHora").addClass("valid");
            }
        }

        var camposValidos = false;

        function HabilitarBoton(){
         var botonEnviar = document.getElementById('boton');
         if (camposValidos == false) {
            botonEnviar.disabled = true;
        }
        else {
            botonEnviar.disabled = false;
            }
        }


    </script>
  <form runat="server">
<%--  <ul class="collection">
    <%foreach (var item in listaComprada){%>
    <li class="collection-item avatar">
      <img src="<%=item.Imagen%>" alt="" width="100" height="100"/>
      <span class="title"><%= item.Descripcion %></span>
      <p><%=item.Precio %></p>
        <label>Cantidad</label>
          <select class="browser-default">
                <option value="1">Option 1</option>
                <option value="2">Option 2</option>
                <option value="3">Option 3</option>
         </select>
      <asp:LinkButton runat="server" ClientIDMode="Static" data-id="<%=item.IdProducto%>" OnClick="eliminarProducto" class="secondary-content"><i class="material-icons">delete_forever</i></asp:LinkButton>
    </li>  
       <% }%>
  </ul>--%>


         

 <asp:Repeater runat="server" ID="repetidor">
       <ItemTemplate>
   <ul class="collection">
    <li class="collection-item avatar">
      <img src="<%#Eval("Imagen")%>" alt="" width="100" height="100"/>
      <span class="title"><%#Eval("Descripcion")%></span>
      <p><%#Eval("Precio")%></p>
<%--        <label>Cantidad</label>
          <select class="browser-default">
                <option value="1">Option 1</option>
                <option value="2">Option 2</option>
                <option value="3">Option 3</option>
         </select>--%>
      <asp:LinkButton runat="server" CommandArgument='<%#Eval("IdProducto")%>' OnClick="btnArgumento_Click" class="secondary-content"><i class="material-icons">delete_forever</i></asp:LinkButton>
    </li>  
  </ul>
    </ItemTemplate>
     </asp:Repeater>

 <div class="row">
    <div class="col s12">
      <div class="row">
        <div class="input-field col s6 black-text">
          <i class="material-icons prefix">attach_money</i>
          <label id="icon_prefix" type="text" class="validate">TOTAL: <%= total %> </label>      
        </div>
      </div>
        <div class="input-field col s6">
        <asp:TextBox ID="txtFecha" ClientIDMode="Static" class="datepicker" onFocusOut="return validateDate()" onFocus="return cleanErrorDate()" runat="server" required="required" />
            <label for="txtFecha">Agregar fecha entrega</label>
        </div>

      <div class="input-field col s6">
         <asp:TextBox ID="txtHora" ClientIDMode="Static"  class="timepicker" onFocusOut="return validateHour()" onFocus="return cleanErrorHour()" runat="server" required="required" />
          <label for="txtHora">Agregar hora de entrega</label>
        </div>
         <asp:Button class="btn waves-effect waves-light btn-large" OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Confirmar pedido">
                <%--<i class="material-icons right">send</i>--%>
         </asp:Button>
    </div>
  </div>
        </form>
   

</asp:Content>

