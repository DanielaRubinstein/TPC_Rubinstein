using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {

        public Cliente validarUsuario(Cliente cliente)
        {
            AccesoDatos conexion;
            try
            {
                conexion = new AccesoDatos();
                conexion.SetearConsulta("select * from CLIENTE where Mail=@Mail and Pass=@Pass");
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@Mail", cliente.Mail);
                conexion.Comando.Parameters.AddWithValue("@Pass", cliente.Pass);
                conexion.AbrirConexion();
                conexion.ejecutarConsulta();
                if (conexion.Lector.Read())
                {
                    cliente.Id = (int)conexion.Lector["IdCliente"];
                    cliente.Nombre = (string)conexion.Lector["Nombre"];
                    cliente.Apellido = (string)conexion.Lector["Apellido"];
                    cliente.Direccion = (string)conexion.Lector["Direccion"];
                    cliente.Localidad = (string)conexion.Lector["Localidad"];
                    cliente.Telefono = (string)conexion.Lector["Telefono"];
                    cliente.Mail = (string)conexion.Lector["Mail"];
                    cliente.Pass = (string)conexion.Lector["Pass"];
                    cliente.Estado = (bool)conexion.Lector["Estado"];
                    cliente.Bloqueado = (bool)conexion.Lector["Bloqueado"];

                    return cliente;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void agregarCliente(Cliente clienteNuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            string consulta = "";
            try
            {
                consulta = "insert into Cliente (Nombre,Apellido,Direccion,Localidad,Telefono,Mail,Pass,Estado,Bloqueado)";
                consulta = consulta + "values('" + clienteNuevo.Nombre + "','" + clienteNuevo.Apellido + "', '" + clienteNuevo.Direccion + "', '" + clienteNuevo.Localidad + "', '" + clienteNuevo.Telefono + "', '" + clienteNuevo.Mail + "', '" + clienteNuevo.Pass + "', '" + 1 + "', " + 0 + ")";
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
                if (accesoDatos != null)
                {
                    accesoDatos.cerrarConexion();
                }
            }
        }
    }
}
