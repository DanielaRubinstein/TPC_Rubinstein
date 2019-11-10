using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class frmProveedor : Form
    {

        private Proveedor proveedor = null;
        bool modificado = false;
        public frmProveedor()
        {
            InitializeComponent();
        }

        public frmProveedor(Proveedor prov)
        {
            InitializeComponent();
            proveedor = prov;

        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();

        }

        private void frmProveedor_Load(Object sender,EventArgs e)
        {
            if (proveedor != null)
            {
                txtCUIL.Text = proveedor.CUIL;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtDireccion.Text = proveedor.Direccion;
                txtLocalidad.Text = proveedor.Localidad;
                txtContacto.Text = proveedor.Contacto;
                txtTelefono.Text = proveedor.Telefono;
                txtMail.Text = proveedor.Mail;
                modificado = true;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            try
            {
                if(txtCUIL.Text.Trim()=="" || txtRazonSocial.Text.Trim() == "" || txtDireccion.Text.Trim() == "" || txtLocalidad.Text.Trim() == "" || txtContacto.Text.Trim() == "" || txtTelefono.Text.Trim() == "" || txtMail.Text.Trim() == "")
                {
                    MessageBox.Show("Todos los datos son obligatorios");
                    return;
                }

                else
                {
                    if (proveedor == null)
                    {
                        proveedor = new Proveedor();
                        proveedor.CUIL = txtCUIL.Text;
                        proveedor.RazonSocial = txtRazonSocial.Text;
                        proveedor.Direccion = txtDireccion.Text;
                        proveedor.Localidad = txtLocalidad.Text;
                        proveedor.Contacto = txtContacto.Text;
                        proveedor.Mail = txtMail.Text;
                    }

                    if(proveedor.IdEmpresa != 0 && modificado == true)
                    {
                        proveedor.CUIL = txtCUIL.Text;
                        proveedor.RazonSocial = txtRazonSocial.Text;
                        proveedor.Direccion = txtDireccion.Text;
                        proveedor.Localidad = txtLocalidad.Text;
                        proveedor.Contacto = txtContacto.Text;
                        proveedor.Mail = txtMail.Text;
                        proveedor.Estado = true;
                        proveedorNegocio.modificarProveedor(proveedor);
                        MessageBox.Show("Modificado correctamente");

                    }
                    else
                    {
                        proveedorNegocio.AgregarProveedor(proveedor);
                        MessageBox.Show("Agregado correctamente");
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            Close();
        }
    }
}
