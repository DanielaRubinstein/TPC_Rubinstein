using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IUser
    {
         string Pass { get; set; }
         string Mail { get; set; }
    }
}
