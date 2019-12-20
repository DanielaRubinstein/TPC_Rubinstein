using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Empresa, IUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; }
        public bool Bloqueado { get; set; }

        //public override string ToString()
        //{
        //    //return IdEmpresa + "," + CUIL + "," + RazonSocial + "," + Direccion + "," + Localidad + "," + Contacto + "," + Telefono + "," + Mail + "," + Estado;
        //    return Pass + "," + Bloqueado.ToString();
        //}


    }
}
