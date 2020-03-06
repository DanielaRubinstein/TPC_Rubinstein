<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="PresentacionWeb.EditarProducto" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="EditarProducto" ContentPlaceHolderID="MainContent" runat="server">


    <script>

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

        function onlyNumber(car) {
            var key = window.Event ? car.which : car.keyCode;
            return (key >= 48 && key <= 57)
        }

    </script>

   <div class="row">
    <form class="col s12" runat="server">
        <div class="row">
               <asp:Label ID="lblCreado" ClientIDMode="Static" runat="server" Text="Producto editado" Visible="false"></asp:Label>
        </div>
      <div class="row">
        <div class="input-field col s6">
        <asp:TextBox ID="txtDescripcion" ClientIDMode="Static" Name="txtDescripcion" onKeyPress="return onlyLetter(event)" CssClass="validate" required="required" type="text" runat="server" OnLoad="Page_Load"></asp:TextBox>
            <label for="txtDescripcion">Descripcion</label>
        </div>
       <div class="input-field col s6">
        <asp:TextBox ID="txtStockActual" ClientIDMode="Static" onKeyPress="return onlyNumber(event)" CssClass="validate" required="required" type="text" runat="server" OnLoad="Page_Load" />
          <label for="txtStockActual">Stock</label>
        </div>
      </div>
      <div class="row">
        <div class="input-field col s4">
        <asp:TextBox ID="txtImpuesto" ClientIDMode="Static" onKeyPress="return onlyNumber(event)" CssClass="validate" type="text" required="required" runat="server" />
          <label for="txtImpuesto">Impuesto</label>
        </div>
       <div class="input-field col s4">
        <asp:TextBox ID="txtCosto" ClientIDMode="Static" onKeyPress="return onlyNumber(event)" CssClass="validate" required="required" type="text" runat="server" />
          <label for="txtCosto">Costo</label>
        </div>
        <div class="input-field col s4">
        <asp:TextBox ID="txtPrecio" ClientIDMode="Static" onKeyPress="return onlyNumber(event)" CssClass="validate" required="required" type="text" runat="server" />
          <label for="txtPrecio">Precio</label>
        </div>
      </div>
       <div class="row">
       <div class="input-field col s12">
        <asp:TextBox ID="txtImagen" ClientIDMode="Static" CssClass="validate" type="text" runat="server" />
          <label for="txtImagen">Imagen</label>
        </div>
      </div>
    <p>
      <label for="ckbCategoryChocolate">
          <%--<asp:CheckBox ID="CheckBox1" runat="server" />--%>
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryChocolate" runat="server" OnLoad="Page_Load"/>
        <span>Chocolate</span>
      </label>
    </p>
    <p>
        <label for="ckbCategoryCheesecake">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryCheesecake" runat="server" OnLoad="Page_Load"/>
        <span>Cheesecake</span>
        </label>
    </p>
    <p>
      <label for="ckbCategoryDulce">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryDulce" runat="server" OnLoad="Page_Load"/>
        <span>Dulce de leche</span>
      </label>
    </p>
    <p>
      <label for="ckbCategoryTematicas">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryTematicas" runat="server" OnLoad="Page_Load"/>
        <span>Tematicas</span>
      </label>
    </p>
    <p>
      <label for="ckbCategoryFrutales">
        <asp:CheckBox ClientIDMode="Static" ID="ckbCategoryFrutales" runat="server" OnLoad="Page_Load"/>
        <span>Frutales</span>
      </label>
    </p>  

<%--       <label for="ckbEstado">
        <asp:CheckBox ClientIDMode="Static" ID="ckbEstado" runat="server" />
         <span>Activo</span>
      </label>--%>
   <div style="margin-bottom:20px;" class="switch">
     <label>
      Inactivo
      <asp:CheckBox ClientIDMode="Static" ID="ckbEstado" runat="server" />
      <span class="lever"></span>
      Activo
    </label>
  </div>

   <asp:Button class="btn waves-effect waves-light btn-large"  OnClick="btnAceptar_Click" type="submit" name="action" runat="server" Text="Aceptar" ></asp:Button>
  </form>
  </div>

</asp:Content>
