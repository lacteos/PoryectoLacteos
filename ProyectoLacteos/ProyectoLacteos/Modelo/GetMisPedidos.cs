using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    public class GetMisPedidos
    {
           public string id { get; set; }
           public string id_usuario { get; set; }
           public string fecha_pedido { get; set; }
           public string id_direccion { get; set; }
           public string estado { get; set; }
        }

    public class LinkMisPedidos
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetMisPedidosResponse
    {
        public List<GetMisPedidos> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkMisPedidos> links { get; set; }
    }

}
