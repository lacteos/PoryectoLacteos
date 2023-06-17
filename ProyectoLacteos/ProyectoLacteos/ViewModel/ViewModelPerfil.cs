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
            cargarPerfil();
        }

        public async void cargarPerfil()
        {
            string correo = SharedData.MyData;
            string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/perfil/" + correo;
            ConsumoServicio servicio = new ConsumoServicio(url);

            GetPerfilResponse responsePerfil = await servicio.Get<GetPerfilResponse>();


            foreach (ItemPerfil x in responsePerfil.items)
            {

                listaperfil.Add(x);


            }

        }

        public ObservableCollection<ItemPerfil> listaperfil { get; set; } = new ObservableCollection<ItemPerfil>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
