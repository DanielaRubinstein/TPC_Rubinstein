using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        //public Marca marca { get; set; }
        public List<Categoria> categorias { get; set; }
        public Proveedor Proveedor { get; set; }
        //public int StockMinimo { get; set; }
        public int StockActual { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }

        //public override string ToString()
        //{
        //    return IdProducto + "," + Descripcion + "," + Marca + "," + Categoria + "," + StockActual.ToString() + "," + Precio.ToString() + "," + Impuesto.ToString() + "," + Costo.ToString() + "," + Estado + "," + Imagen.ToString();
        //}

    }
}
