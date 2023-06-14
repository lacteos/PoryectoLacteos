using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    
    public class ItemProductoCategoria
    {
        public string foto { get; set; }
        public string nombre_producto { get; set; }
        public int unidad_medida { get; set; }
        public int precio { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetProductoCategoria
    {
        public List<ItemProductoCategoria> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}
