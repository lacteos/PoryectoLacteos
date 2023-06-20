using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    
    public class ItemProductoCategoria
    {
        public int ID_CATEGORIA { get; set; }
        public string FOTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public int UNIDAD_MEDIDA { get; set; }
        public int PRECIO { get; set; }
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
