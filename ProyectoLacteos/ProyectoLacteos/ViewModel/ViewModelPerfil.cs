using ProyectoLacteos.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;


namespace ProyectoLacteos.ViewModel
{
    public class ViewModelPerfil : INotifyPropertyChanged
    {

        public ViewModelPerfil()
        {
            cargarPerfil(); // Llama al metodo para cargar el perfil al crear una instancia de ViewModelPerfil
        }

        public async void cargarPerfil()
        {
            string correo = SharedData.MyData; // Obtiene el correo electrónico desde SharedData.MyData
            string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/perfil/" + correo; // Construye la URL utilizando el correo electrónico
            ConsumoServicio servicio = new ConsumoServicio(url); // Crea una instancia de ConsumoServicio con la URL

            GetPerfilResponse responsePerfil = await servicio.Get<GetPerfilResponse>(); // Obtiene la respuesta de perfil utilizando el método Get

            foreach (ItemPerfil x in responsePerfil.items) // Itera a traves de los elementos de perfil obtenidos
            {
                listaperfil.Add(x); // Agrega cada elemento de perfil a la lista listaperfil
            }
        }

        public ObservableCollection<ItemPerfil> listaperfil { get; set; } = new ObservableCollection<ItemPerfil>(); // Propiedad que almacena los perfiles en una colección observable

        public event PropertyChangedEventHandler PropertyChanged; // Evento que notifica los cambios de propiedad
    }
}

