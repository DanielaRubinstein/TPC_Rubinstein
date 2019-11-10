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
    public partial class frmListaProveedor : Form
    {
        private List<Proveedor> proveedorListado;

        public frmListaProveedor()
        {
            InitializeComponent();
        }

        private void CargarGrilla()
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            try
            {
                proveedorListado = proveedorNegocio.listar();
                dgvProveedor.DataSource = proveedorListado;
                dgvProveedor.Columns["IdEmpresa"].DisplayIndex = 0;
                dgvProveedor.Columns["CUIL"].DisplayIndex = 1;
                dgvProveedor.Columns["RazonSocial"].DisplayIndex = 2;
                dgvProveedor.Columns["Direccion"].DisplayIndex = 3;
                dgvProveedor.Columns["Localidad"].DisplayIndex = 4;
                dgvProveedor.Columns["Contacto"].DisplayIndex = 5;
                dgvProveedor.Columns["Telefono"].DisplayIndex = 6;
                dgvProveedor.Columns["Mail"].DisplayIndex = 7;
                dgvProveedor.Columns["Estado"].Visible = false;

                //dgvProveedor.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmListaProveedor_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmProveedor formularioProveedor = new frmProveedor();
            formularioProveedor.ShowDialog();
            CargarGrilla();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedor proveedorModificar = new frmProveedor((Proveedor)dgvProveedor.CurrentRow.DataBoundItem);
                proveedorModificar.ShowDialog();
                CargarGrilla();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();
            try
            {
                DialogResult resultado = MessageBox.Show("Estas seguro que quieres eliminar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    proveedor = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
                    proveedor.Estado = false;
                    proveedorNegocio.modificarProveedor(proveedor);
                    CargarGrilla();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
