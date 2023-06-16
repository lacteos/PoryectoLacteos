using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    public class PedidoResquest
    {

        public int ID_USER { get; set; }

        public string FECHA { get; set; }

        public int ID_DIREC { get; set; }

        public int ESTADO { get; set; }
    }
}
