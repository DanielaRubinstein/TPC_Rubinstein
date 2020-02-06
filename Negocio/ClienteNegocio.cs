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

        public IUser validarUsuario(IUser usuario)
        {
            AccesoDatos conexion;
            try
            {
                conexion = new AccesoDatos();
                conexion.SetearConsulta(@"select 0 as IsAdmin, IdCliente as Id, Nombre, Apellido,Direccion,Localidad,Telefono,Mail,Pass,Estado,Bloqueado
                                         from CLIENTE where Mail=@Mail and Pass=@Pass
                                        UNION 
                                        select 1 as IsAdmin, IdAdmin as Id,Nombre,'' as Apellido,'' as Direccion,'' as Localidad,'' as Telefono , Mail, Pass, 1 as Estado, 0 as Bloqueado from ADMINISTRADOR where Mail=@Mail and Pass=@Pass");
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@Mail", usuario.Mail);
                conexion.Comando.Parameters.AddWithValue("@Pass", usuario.Pass);
                conexion.AbrirConexion();
                conexion.ejecutarConsulta();

                if (conexion.Lector.Read())
                {
                    if ((int)conexion.Lector["IsAdmin"] == 0)
                    {
                        Cliente cliente = new Cliente();

                        cliente.Id = (int)conexion.Lector["Id"];
                        cliente.Nombre = (string)conexion.Lector["Nombre"];
                        cliente.Apellido = (string)conexion.Lector["Apellido"];
                        cliente.Direccion = (string)conexion.Lector["Direccion"];
                        cliente.Localidad = (string)conexion.Lector["Localidad"];
                        cliente.Telefono = (string)conexion.Lector["Telefono"];
                        cliente.Mail = (string)conexion.Lector["Mail"];
                        cliente.Pass = (string)conexion.Lector["Pass"];
                        cliente.Estado = (int)conexion.Lector["Estado"] == 1;
                        cliente.Bloqueado = (int)conexion.Lector["Bloqueado"] == 1;
                        return cliente;
                    }
                    else
                    {
                        Administrador administrador = new Administrador();
                        administrador.IdAdmin = (int)conexion.Lector["Id"];
                        administrador.Nombre = (string)conexion.Lector["Nombre"];
                        administrador.Mail = (string)conexion.Lector["Mail"];
                        administrador.Pass = (string)conexion.Lector["Pass"];
                        return administrador;
                    }
                    
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
            //string consulta = "";
            try
            {

                //consulta = "insert into Cliente (Nombre,Apellido,Direccion,Localidad,Telefono,Mail,Pass,Estado,Bloqueado)";
                //consulta = consulta + "values('" + clienteNuevo.Nombre + "','" + clienteNuevo.Apellido + "', '" + clienteNuevo.Direccion + "', '" + clienteNuevo.Localidad + "', '" + clienteNuevo.Telefono + "', '" + clienteNuevo.Mail + "', '" + clienteNuevo.Pass + "', '" + 1 + "', " + 0 + ")";
                accesoDatos.SetearConsulta(@"exec SP_crearCliente 
                                           @Nombre,
                                           @Apellido,
                                           @Direccion,
                                           @Localidad,
                                           @Telefono,
                                           @Mail,
                                           @Pass,
                                           @Estado,
                                           @Bloqueado");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", clienteNuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", clienteNuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Direccion", clienteNuevo.Direccion);
                accesoDatos.Comando.Parameters.AddWithValue("@Localidad", clienteNuevo.Localidad);
                accesoDatos.Comando.Parameters.AddWithValue("@Telefono", clienteNuevo.Telefono);
                accesoDatos.Comando.Parameters.AddWithValue("@Mail", clienteNuevo.Mail);
                accesoDatos.Comando.Parameters.AddWithValue("@Pass", clienteNuevo.Pass);
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", clienteNuevo.Estado);
                accesoDatos.Comando.Parameters.AddWithValue("@Bloqueado", clienteNuevo.Bloqueado);
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
