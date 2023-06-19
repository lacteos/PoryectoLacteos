using ProyectoLacteos.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;


namespace ProyectoLacteos.ViewModel
{
    public class ViewModelCategoria : INotifyPropertyChanged
    {

        public ViewModelCategoria()
        {


            cargarCategorias();


        }

        public async void cargarCategorias()
        {

            ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/categorias");
            GetCategoriasResponse responseCategoria = await servicio.Get<GetCategoriasResponse>();


            foreach (ItemCategoria x in responseCategoria.items)
            {

                listaCategorias.Add(x);
              


            }

        }

        public ObservableCollection<ItemCategoria> listaCategorias { get; set; } = new ObservableCollection<ItemCategoria>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
