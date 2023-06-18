using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ProyectoLacteos.View
{	
	public partial class viewDirecciones : ContentPage
	{	
		public viewDirecciones ()
		{
			InitializeComponent ();
		}

        private void Aceptar_Clicked(object sender, EventArgs e)
        {
            string opcionSeleccionada = opcionPicker.SelectedItem.ToString();
            DisplayAlert("Opción seleccionada", opcionSeleccionada, "Aceptar");
        }
    }
}

