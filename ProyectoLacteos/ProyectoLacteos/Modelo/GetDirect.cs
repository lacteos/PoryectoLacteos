using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
        public class ItemDireccion
        {
        public int ID { get; set; }
        public string DIRECT { get; set; }
        public string DESCRI { get; set; }
        public int id_usuario { get; set; }
    }
        public class LinkDireccion
        {
            public string rel { get; set; }
            public string href { get; set; }
        }


        public class GetDirect
        {
            public List<ItemDireccion> items { get; set; }
            public bool hasMore { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int count { get; set; }
            public List<LinkDireccion> links { get; set; }
        }

    }

