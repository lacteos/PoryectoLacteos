using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLacteos.Modelo
{
    public static class SharedData
    {
        public static string MyData { get; set; } //variable global que guarda el correo actual y puede ser leida en cualquier lado

        public static string DataId { get; set; }

        public static string DataName { get; set; }

    }
}
