using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        public static string cadenaConexion = "initial catalog=DB_TPC_Rubinstein_prueba;data source=DESKTOP-3LK2VR8\\SQLEXPRESS;integrated security=sspi";

        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public SqlCommand Comando
        {
            get { return comando; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void SetearConsulta(string consulta)
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void InitComando()
        {
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
        }
        public void ComandoQuery(string consulta)
        {
            comando.CommandText = consulta;
        }

        public void AbrirConexion()
        {
            try
            {
                conexion.Open();
                //lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ejecutarAccion()
        {
            try
            {
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarAccionReturn()
        {
            try
            {
                comando.Connection = conexion;
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarConsulta()
        {
            try
            {
                comando.Connection = conexion;
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
