using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoLacteos.Modelo;
using ProyectoLacteos.View;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace ProyectoLacteos.ViewModel
{
    public class ViewPaginaInicio : INotifyPropertyChanged
    {

        public ViewPaginaInicio()
        {
            MisPedidos = new Command(async () =>
            {
                cargarMisPedidos();

            });

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

            navegarMisPedido = new Command(async () =>
            {
                
                await cargarPerfil();
                await Application.Current.MainPage.Navigation.PushAsync(new ViewMisPedidos());
                cargarMisPedidos();
                redirigirDetallePedido = new Command(() => {


                    var pagina = new ViewMisPedidos();
                    var viewModel = pedidoSeleccionado.id;

                    pagina.BindingContext = viewModel;
                    Application.Current.MainPage.Navigation.PushAsync(pagina);
                });
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

        public async void cargarMisPedidos()
        {
            string algo = SharedData.DataId;
            string nombre = SharedData.DataName;
            ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/get_pedido/"+algo);
            GetMisPedidosResponse responseMisPedidos = await servicio.Get<GetMisPedidosResponse>();


            foreach (GetMisPedidos x in responseMisPedidos.items)
            {

                listarMisPedidos.Add(x);

            }

        }

        GetMisPedidos pedidoSeleccionado;
        public GetMisPedidos PedidoSeleccionado
        {

            get => pedidoSeleccionado;

            set
            {
                pedidoSeleccionado = value;
                var args = new PropertyChangedEventArgs(nameof(PedidoSeleccionado));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command redirigirDetallePedido { get; set; }
        public Command navegarProducto { get; }
        public Command navegarCategorias { get; }
        public Command navegarPedido { get; }
        public Command navegarMisPedido { get; }
        public Command navegarDirecciones { get; }
        public Command navegarPerfil { get; }

        public Command MisPedidos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GetMisPedidos> listarMisPedidos { get; set; } = new ObservableCollection<GetMisPedidos>();
    }
}



