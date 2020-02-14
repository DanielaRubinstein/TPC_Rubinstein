using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Dominio;
using Negocio;

namespace PresentacionWeb
{
    public partial class CargaProducto : System.Web.UI.Page
    {
        private Producto producto = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //agregarle css a los checkbox
            ckbCategoryChocolate.InputAttributes.Add("class", "filled-in");
            ckbCategoryCheesecake.InputAttributes.Add("class", "filled-in");
            ckbCategoryFrutales.InputAttributes.Add("class", "filled-in");
            ckbCategoryDulce.InputAttributes.Add("class", "filled-in");
            ckbCategoryTematicas.InputAttributes.Add("class", "filled-in");
            //asignarle valor a los checkbox
            ckbCategoryChocolate.InputAttributes.Add("data-categoryId", "1");
            ckbCategoryCheesecake.InputAttributes.Add("data-categoryId", "2");
            ckbCategoryFrutales.InputAttributes.Add("data-categoryId", "3");
            ckbCategoryDulce.InputAttributes.Add("data-categoryId", "4");
            ckbCategoryTematicas.InputAttributes.Add("data-categoryId", "5");
        }

        public void btnAceptar_Click(object sender,EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            producto = new Producto();
            producto.Descripcion = txtDescripcion.Text;
            producto.StockActual = Int32.Parse(txtStockActual.Text);
            producto.Impuesto = Int32.Parse(txtImpuesto.Text);
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Costo = decimal.Parse(txtCosto.Text);
            producto.Imagen = txtImagen.Text;
            producto.categorias = new List<Categoria>();

            if (ckbCategoryChocolate.Checked == true)
            {
                producto.categorias.Add(new Categoria() {
                    IdCategoria = Int32.Parse(ckbCategoryChocolate.InputAttributes["data-categoryId"])
                });
            }
            if (ckbCategoryCheesecake.Checked == true)
            {
                producto.categorias.Add(new Categoria()
                {
                    IdCategoria = Int32.Parse(ckbCategoryCheesecake.InputAttributes["data-categoryId"])
                });
            }
            if (ckbCategoryDulce.Checked == true)
            {
                producto.categorias.Add(new Categoria()
                {
                    IdCategoria = Int32.Parse(ckbCategoryDulce.InputAttributes["data-categoryId"])
                });
            }
            if (ckbCategoryTematicas.Checked == true)
            {
                producto.categorias.Add(new Categoria()
                {
                    IdCategoria = Int32.Parse(ckbCategoryTematicas.InputAttributes["data-categoryId"])
                });
            }
            if (ckbCategoryFrutales.Checked == true)
            {
                producto.categorias.Add(new Categoria()
                {
                    IdCategoria = Int32.Parse(ckbCategoryFrutales.InputAttributes["data-categoryId"])
                });
            }

            producto.Estado = true;

            productoNegocio.agregarProducto(producto);

            if (producto.IdProducto <= 0)
            {
                lblCreado.Visible = false;
                lblError.Visible = true;
            }
            else
            {
                lblCreado.Visible = true;
                lblError.Visible = false;
            }

        }

        protected void btnModificar_Click()
        {
        }


    }
}