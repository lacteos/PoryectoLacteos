using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoLacteos.Modelo;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{

    
    public class ViewModelDireccion : INotifyPropertyChanged
    {



        public ViewModelDireccion()
        {

            GetDirecciones = new Command(async () =>
            {
                getDirecciones();
            });


                AgregarDireccion = new Command(async () =>
            {

                string algo = SharedData.DataId;
                ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/direccion/" + algo);

                ItemDireccion datos = new ItemDireccion()
                {
                    direccion = Direccion,
                    descripcion = Descripcion,
                    
                };

                GetDireccionesRespond responose = await servicio.PostAsync<GetDireccionesRespond>(datos);

                if (responose != null)
                {

                    Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
            }
            );

            ActualizarDireccion = new Command(async () =>
            {
                ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/update_direccion/" + id);

                ItemDireccion datos = new ItemDireccion()
                {
                    direccion = Direccion,
                    descripcion = Descripcion
                    
                    
                };

                GetDireccionesRespond responose = await servicio.PutAsync<GetDireccionesRespond>(datos);

                if (responose != null)
                {

                    Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
            }
            );





        }


       



        public async void getDirecciones()
        {
            string algo = SharedData.DataId;
            string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/direccion/" + algo;
            ConsumoServicio servicio = new ConsumoServicio(url);
            GetDireccionesRequest response= await servicio.Get<GetDireccionesRequest>();

            foreach (ItemDireccion x in response.items)
            {

                listarDireccines.Add(x);

            }

        }




        string direccion;

        public string Direccion
        {
            get => direccion;
            set
            {
                direccion = value;
                var args = new PropertyChangedEventArgs(nameof(Direccion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string descripcion;

        public string Descripcion
        {
            get => descripcion;
            set
            {
                descripcion = value;
                var args = new PropertyChangedEventArgs(nameof(Descripcion));
                PropertyChanged?.Invoke(this, args);
            }
         }

        int id_usuario;

        public int Id_usuario
        {
            get => Id_usuario;
            set
            {
                Id_usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Id_usuario));
                PropertyChanged?.Invoke(this, args);
            }
        }

        ItemDireccion direccionSeleccionada = new ItemDireccion();

        public ItemDireccion DireccionSeleccionada
        {

            get => direccionSeleccionada;
            set
            {

                direccionSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(DireccionSeleccionada));
                PropertyChanged?.Invoke(this, args);

            }

        }


        int id_usuar;
        int id;

        public Command GetDirecciones { get; set; }
        public Command AgregarDireccion { get; set; }
          public Command ActualizarDireccion { get; set; }
         
        public Command EliminarDireccion { get; set; }

        public ObservableCollection<ItemDireccion> listarDireccines { get; set; } = new ObservableCollection<ItemDireccion>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}


   




