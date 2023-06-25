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

    
    public class ViewModelDireccion : INotifyPropertyChanged
    {



        public ViewModelDireccion()
        {

            GetDirecciones = new Command(async () =>
            {
                getDirecciones();

            });

            ActualizarDireccion = new Command(async () =>
            {
                
                string algo = SharedData.DataId;
                var url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/update_direccion/" + DireccionSeleccionada.id;
                ConsumoServicio servicio = new ConsumoServicio(url);


                Id = DireccionSeleccionada.id;
                Id_usuario = algo;
                ItemDireccion datos = new ItemDireccion()
                {
                    id = Id,
                    direccion = Direccion,
                    descripcion = Descripcion,
                    id_usuario = Id_usuario
                };

                GetDireccionesRespond responose = await servicio.PutAsync<GetDireccionesRespond>(datos);

                if (responose != null)
                {

                    Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");

                    
                    //await Application.Current.MainPage.Navigation.PopAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new viewDirecciones());
                    getDirecciones();
                }
                Direccion = " ";
                Descripcion = " ";
            }
            
            );

            AgregarDireccion = new Command(async () =>
            {

                string algo = SharedData.DataId;
                ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/direccion/" +algo);

                ItemDireccion datos = new ItemDireccion()
                {
                    
                    direccion = Direccion,
                    descripcion = Descripcion,
                    id_usuario = algo
                    
                };

                GetDireccionesRespond responose = await servicio.PostAsync<GetDireccionesRespond>(datos);

                if (responose != null)
                {

                    Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new viewDirecciones());
                    getDirecciones();
                }
                Direccion = " ";
                Descripcion = " ";
            }
            );



        }


       



        public async void getDirecciones()
        {
            string algo = SharedData.DataId;
            string nombre = SharedData.DataName;
            string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/direccion/" + algo;
            ConsumoServicio servicio = new ConsumoServicio(url);
            GetDireccionesRequest response= await servicio.Get<GetDireccionesRequest>();

            foreach (ItemDireccion x in response.items)
            {

                listarDireccines.Add(x);

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

        string id_usuario;

        public string Id_usuario
        {
            get => id_usuario;
            set
            {
                id_usuario = value;
                var args = new PropertyChangedEventArgs(nameof(Id_usuario));
                PropertyChanged?.Invoke(this, args);
            }
        }

        

        string id;
        public string Id
        {
            get => id;
            set
            {
                id = value;
                var args = new PropertyChangedEventArgs(nameof(Id));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command GetDirecciones { get; set; }
        public Command AgregarDireccion { get; set; }
        public Command ActualizarDireccion { get; set; }
         
        public Command EliminarDireccion { get; set; }

        public ObservableCollection<ItemDireccion> listarDireccines { get; set; } = new ObservableCollection<ItemDireccion>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}


   




