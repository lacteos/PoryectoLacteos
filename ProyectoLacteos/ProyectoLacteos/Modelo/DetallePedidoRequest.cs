using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    public class DetallePedidoRequest
    {

       public int ID_PRODUCT { get; set; }

      public int ID_PED { get; set; }

        public int CANT { get; set; }
    }
}
