using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    public class ItemPerfil
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int id_rol { get; set; }
    }

    public class LinkPerfil
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetPerfilResponse
    {
        public List<ItemPerfil> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}

