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

    /// <summary>
    /// 
    /// </summary>
    public class ViewModelDireccion : INotifyPropertyChanged
    {
        private ObservableCollection<ItemDireccion> direcciones;
        private ItemDireccion direccionSeleccionada;

        public ObservableCollection<ItemDireccion> Direcciones
        {

              get { return direcciones; }
             set
            {
              direcciones = value;
            OnPropertyChanged();
            }

        }

         public ItemDireccion DireccionSeleccionada
         {
           get { return direccionSeleccionada; }
         set
        {
          direccionSeleccionada = value;
         OnPropertyChanged();
         }
         }


         public ViewModelDireccion()
         {
           direcciones = new ObservableCollection<ItemDireccion>();
            CargarDirecciones();
        }

        public async void CargarDirecciones()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string idUsuario = "21"; // Reemplaza esto con el ID del usuario correspondiente
                    string url = $"https://apex.oracle.com/pls/apex/lacteos/Lacteos/direccion/{idUsuario}";

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Direcciones = JsonConvert.DeserializeObject<ObservableCollection<ItemDireccion>>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al cargar las direcciones: {ex.Message}");
            }
        }

            public void AgregarDireccion(string P_direccion, string P_descripcion)
          {
            ItemDireccion nuevaDireccion = new ItemDireccion()
         {
           direccion = P_direccion,
         descripcion = P_descripcion
         };
          direcciones.Add(nuevaDireccion);
          }

           public void ActualizarDireccion(string direccion, string descripcion)
            {
            if (direccionSeleccionada != null)
            {
            direccionSeleccionada.direccion = direccion;
           direccionSeleccionada.descripcion = descripcion;
         }
           }

           public void EliminarDireccion()
         {
           if (direccionSeleccionada != null)
         {
           direcciones.Remove(direccionSeleccionada);
         direccionSeleccionada = null;
         }
           }

         #region INotifyPropertyChanged

         public event PropertyChangedEventHandler PropertyChanged;

         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
         {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

           #endregion

         public Command AgregarDireccion1 { get; set; }
          public Command ActualizarDireccion1 { get; set; }
         public Command EliminarDireccion1 { get; set; }

    }
            }

   




