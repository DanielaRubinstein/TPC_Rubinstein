using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empresa
    {
        public int Id { get; set; }
        public string CUIL { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public bool Estado { get; set; }

        //public override string ToString()
        //{
        //    return RazonSocial;
        //}

    }
}
