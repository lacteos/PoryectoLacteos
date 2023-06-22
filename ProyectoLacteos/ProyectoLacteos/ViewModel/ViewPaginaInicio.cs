using Newtonsoft.Json;
using ProyectoLacteos.Modelo;
using ProyectoLacteos.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{
    public class ViewPaginaInicio : INotifyPropertyChanged
    {
        public ViewPaginaInicio()
        {
            navegarProducto = new Command(async () =>
            {
                await cargarPerfil();
                await Application.Current.MainPage.Navigation.PushAsync(new viewProductos());
            });
            navegarCategorias = new Command(async () =>
            {
                await cargarPerfil();
                await Application.Current.MainPage.Navigation.PushAsync(new viewCategorias());
            });

            navegarPedido = new Command(async () =>
            {
                await cargarPerfil();
                await Application.Current.MainPage.Navigation.PushAsync(new viewPedido());
            });

            navegarDirecciones = new Command(async () =>
            {
                await cargarPerfil();
                await Application.Current.MainPage.Navigation.PushAsync(new viewDirecciones());
            });

            navegarPerfil = new Command(async () =>
            {
                
                await Application.Current.MainPage.Navigation.PushAsync(new ViewPerfil());
            });

        }

        public async Task cargarPerfil()
        {
            string correo = SharedData.MyData; // Obtiene el correo electrónico desde SharedData.MyData
            string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/perfil/" + correo; // Construye la URL utilizando el correo electrónico
            ConsumoServicio servicio = new ConsumoServicio(url); // Crea una instancia de ConsumoServicio con la URL

            GetPerfilResponse responsePerfil = await servicio.Get<GetPerfilResponse>(); // Obtiene la respuesta de perfil utilizando el método Get

            foreach (ItemPerfil x in responsePerfil.items) // Itera a través de los elementos de perfil obtenidos
            {
                SharedData.DataId = x.id; // Asigna el valor de x.id a SharedData.DataId
                SharedData.DataName = x.nombre; // Asigna el valor de x.nombre a SharedData.DataName

               
            }
        }


        public Command navegarProducto { get; }
        public Command navegarCategorias { get; }
        public Command navegarPedido { get; }
        public Command navegarDirecciones { get; }
        public Command navegarPerfil { get; }

        public event PropertyChangedEventHandler PropertyChanged;

       
    }
}



