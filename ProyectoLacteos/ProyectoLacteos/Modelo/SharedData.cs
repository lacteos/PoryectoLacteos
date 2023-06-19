using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Essentials.Permissions;

namespace ProyectoLacteos.Modelo
{
    public static class SharedData
    {
        public static string MyData { get; set; } //variable global que guarda el correo actual y puede ser leida en cualquier lado

        public static string DataId { get; set; } // variable global que guarda el id actual y puede ser leida en cualquier lado

        public static string DataName { get; set; } // variable global que guarda el nombre actual y puede ser leida en cualquier lado

    }
}
