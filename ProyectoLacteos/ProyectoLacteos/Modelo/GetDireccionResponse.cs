using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{

	public class ItemDireccion
	{
        public int id { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public int idUsuario { get; set; }
    }

	public class LinkDireccion
	{
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetDireccionesResponse
    {
        public List<ItemDireccion> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkDireccion> links { get; set; }
    }


}

