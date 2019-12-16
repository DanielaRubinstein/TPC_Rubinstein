using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            AccesoDatos accesoDatos = new AccesoDatos();
            Proveedor proveedor;

            try
            {
                accesoDatos.SetearConsulta("select IdProveedor,CUIL,RazonSocial,Direccion,Localidad,Contacto,Telefono,Mail from Proveedor where Estado=1");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.Id = (int)accesoDatos.Lector["IdProveedor"];
                    proveedor.CUIL = accesoDatos.Lector["CUIL"].ToString();
                    proveedor.RazonSocial = accesoDatos.Lector["RazonSocial"].ToString();
                    proveedor.Direccion = accesoDatos.Lector["Direccion"].ToString();
                    proveedor.Localidad = accesoDatos.Lector["Localidad"].ToString();
                    proveedor.Contacto = accesoDatos.Lector["Contacto"].ToString();
                    proveedor.Telefono = accesoDatos.Lector["Telefono"].ToString();
                    proveedor.Mail = accesoDatos.Lector["Mail"].ToString();

                    lista.Add(proveedor);
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void AgregarProveedor(Proveedor proveedorNuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            string consulta = "";
            try
            {
                consulta = "insert into proveedor (CUIL, RazonSocial, Direccion, Localidad, Contacto, Telefono,Mail,Estado)";
                consulta = consulta + "values('" + proveedorNuevo.CUIL + "','" + proveedorNuevo.RazonSocial + "', '" + proveedorNuevo.Direccion + "', '" + proveedorNuevo.Localidad + "', '" + proveedorNuevo.Contacto + "', '" + proveedorNuevo.Telefono + "', '" + proveedorNuevo.Mail + "', "+ 1 +" )";
                accesoDatos.SetearConsulta(consulta);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if(accesoDatos != null)
                {
                    accesoDatos.cerrarConexion();
                }
            }
        }

        public void modificarProveedor(Proveedor proveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("update Proveedor set CUIL=@CUIL, RazonSocial=@RazonSocial, Direccion=@Direccion, Localidad=@Localidad, Contacto=@Contacto, Telefono=@Telefono, Mail=@Mail, Estado=@Estado where IdProveedor=" + proveedor.Id);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@CUIL", proveedor.CUIL);
                accesoDatos.Comando.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                accesoDatos.Comando.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                accesoDatos.Comando.Parameters.AddWithValue("@Localidad", proveedor.Localidad);
                accesoDatos.Comando.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                accesoDatos.Comando.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                accesoDatos.Comando.Parameters.AddWithValue("@Mail", proveedor.Mail);
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", proveedor.Estado);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }





    
    }
}
