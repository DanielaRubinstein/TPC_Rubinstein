using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Cliente cliente { get; set; }
        public List<DetallePedido> detallePedido { get; set; }
        public bool Estado { get; set; }

    }
}
