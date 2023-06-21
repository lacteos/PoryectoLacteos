using ProyectoLacteos.Modelo;
using ProyectoLacteos.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{
    public class ViewModelPedido : INotifyPropertyChanged
    {



        public ViewModelPedido()
        {


            crearPedido = new Command(async () => {


                    ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/pedido");

                PedidoResquest datos = new PedidoResquest()
                {
                    ID_USER = int.Parse(Id_Usuario),
                   /* FECHA = Fecha_p.ToString("MM-dd-yyyy"),*/
                    ID_DIREC = Id_Direccion,
                    ESTADO = 1
                    };
                    PedidoResponse responose = await servicio.PostAsync<PedidoResponse>(datos);
                    if (responose != null)
                    {

                        Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new ViewDetallePedido());
                   
                }

               
            });



        }




       

        public string Id_Usuario
        {
            get => SharedData.DataId;
        }

        public string Nombre_Usuario
        {
            get => SharedData.DataName;
        }

        int id_direccion;

        public int Id_Direccion
        {
            get => id_direccion;
            set
            {
                id_direccion = value;
                var args = new PropertyChangedEventArgs(nameof(Id_Direccion));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int estado;

        public int Estado
        {
            get => estado;
            set
            {
                estado = value;
                var args = new PropertyChangedEventArgs(nameof(Estado));
                PropertyChanged?.Invoke(this, args);

            }
        }

        DateTime fecha_p;

        public DateTime Fecha_p
        {
            get => fecha_p;
            set
            {
                fecha_p = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha_p));
                PropertyChanged?.Invoke(this, args);

            }
        }
        

        public Command crearPedido { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
