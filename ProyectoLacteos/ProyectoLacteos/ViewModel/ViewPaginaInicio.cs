using ProyectoLacteos.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{
    public class ViewPaginaInicio
    {

        public ViewPaginaInicio()
        {
            navegarProducto = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new viewProductos());
            });
            navegarCategorias = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new viewCategorias());
            });
            navegarPedido = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new viewPedido());
            });

            navegarDirecciones = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new viewDirecciones());
            });
        }

        public Command navegarProducto { get; }
        public Command navegarCategorias { get; }
        public Command navegarPedido { get; }
        public Command navegarDirecciones { get; }
    }
}
