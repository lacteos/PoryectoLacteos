using ProyectoLacteos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{
    public class ViewModelDetallePedido: INotifyPropertyChanged
    {




        public ViewModelDetallePedido()
        {


            crearDetallePedido = new Command(async () => {


                ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/detalle_pedido");

                DetallePedidoRequest datos = new DetallePedidoRequest()
                {
                    ID_PRODUCT = Id_product,
                    ID_PED = id_pedido,
                    CANT = Cantidad
                };
                DetallePedidoRespond responose = await servicio.PostAsync<DetallePedidoRespond>(datos);
                if (responose != null)
                {

                    Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");

                }


            });



        }




        int id_product;

        public int Id_product
        {
            get => id_product;
            set
            {
                id_product = value;
                var args = new PropertyChangedEventArgs(nameof(Id_product));
                PropertyChanged?.Invoke(this, args);

            }
        }


        int id_pedido;

        public int Id_pedido
        {
            get => id_pedido;
            set
            {
                id_pedido = value;
                var args = new PropertyChangedEventArgs(nameof(Id_pedido));
                PropertyChanged?.Invoke(this, args);

            }
        }


        int cantidad;

        public int Cantidad
        {
            get => cantidad;
            set
            {
                cantidad = value;
                var args = new PropertyChangedEventArgs(nameof(Cantidad));
                PropertyChanged?.Invoke(this, args);

            }
        }


        public Command crearDetallePedido { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
