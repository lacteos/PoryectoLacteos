using ProyectoLacteos.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProyectoLacteos.ViewModel
{
    public class ViewModelProductoCategoria : INotifyPropertyChanged
    {

        
        
        
        
        
        
        
        
        
        int idCategoria;

        public ObservableCollection<GetProductoCategoriaImagen> listaArticulo { get; set; } = new ObservableCollection<GetProductoCategoriaImagen>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
