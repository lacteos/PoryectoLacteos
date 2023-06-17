using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProyectoLacteos.Modelo;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{
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

