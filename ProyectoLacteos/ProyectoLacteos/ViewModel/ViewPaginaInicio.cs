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

         
            PropertyChanged += OnPropertyChanged;
        }

        public async Task cargarPerfil()
        {
            string correo = SharedData.MyData;
            string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/perfil/" + correo;
            ConsumoServicio servicio = new ConsumoServicio(url);

            GetPerfilResponse responsePerfil = await servicio.Get<GetPerfilResponse>();

            foreach (ItemPerfil x in responsePerfil.items)
            {
                SharedData.DataId = x.id; 
                SharedData.DataName = x.nombre; 

                listaperfil.Add(x);
            }
        }

        public ObservableCollection<ItemPerfil> listaperfil { get; set; } = new ObservableCollection<ItemPerfil>();

        public Command navegarProducto { get; }
        public Command navegarCategorias { get; }
        public Command navegarPedido { get; }
        public Command navegarDirecciones { get; }
        public Command navegarPerfil { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(listaperfil))
            {
                // Imprimir los valores de DataId y DataName en la consola
                Console.WriteLine("DataId: " + SharedData.DataId);
                Console.WriteLine("DataName: " + SharedData.DataName);
            }
        }
    }
}



