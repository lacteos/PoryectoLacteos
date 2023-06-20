using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoLacteos.Modelo
{
    public class GetProductoCategoriaImagen
    {
        public int ID_CATEGORIA { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }

        public int unidad_medida { get; set; }

        public int precio { get; set; }

        public string fotoBase64 { get; set; }
        public byte[] fotoBytes { get; set; }
        public ImageSource imagen { get; set; }

        public void convertirImagen()
        {
            if (fotoBase64 != null)
            {
                fotoBytes = Convert.FromBase64String(fotoBase64);
                imagen = ImageSource.FromStream(() => new System.IO.MemoryStream(fotoBytes));
            }
        }

    }
}
