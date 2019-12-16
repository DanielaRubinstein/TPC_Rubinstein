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
                    cliente.CUIL = (string)conexion.Lector["CUIL"];
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

    }
}
