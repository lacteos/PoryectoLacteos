using ProyectoLacteos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoLacteos.ViewModel
{
    public class ViewModelRegistroUser: INotifyPropertyChanged
    {

        public ViewModelRegistroUser()
        {


            crearUsuario = new Command(async () => {


                if (Contrasenia != ConfirmacionContrasenia)
                {

                    Application.Current.MainPage.DisplayAlert("Error", "Contraseñas no coinciden", "OK");

                }
                else
                {


                    ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/create_usuario");

                    NuevoUsuarioRequest datos = new NuevoUsuarioRequest()
                    {
                        NM = NombreUsuario,
                        TEL = Telefono,
                        EMAIL = Correo,
                        PASS = Contrasenia
                    };

                    NuevoUsuarioRespond responose = await servicio.PostAsync<NuevoUsuarioRespond>(datos);

                    if (responose != null)
                    {

                        Application.Current.MainPage.DisplayAlert("Mensaje", responose.MENSAJE, "OK");

                    }
                }
            });
        }

        string nombreUsuario;

        public string NombreUsuario
        {
            get => nombreUsuario;
            set
            {
                nombreUsuario = value;
                var args = new PropertyChangedEventArgs(nameof(NombreUsuario));
                PropertyChanged?.Invoke(this, args);

            }
        }
        string telefon;

        public string Telefono
        {
            get => telefon;
            set
            {
                telefon = value;
                var args = new PropertyChangedEventArgs(nameof(Telefono));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string correo;

        public string Correo
        {
            get => correo;
            set
            {
                correo = value;
                var args = new PropertyChangedEventArgs(nameof(Correo));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string contrasenia;

        public string Contrasenia
        {
            get => contrasenia;
            set
            {
                contrasenia = value;
                var args = new PropertyChangedEventArgs(nameof(Contrasenia));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string confirmacionContrasenia;

        public string ConfirmacionContrasenia
        {
            get => confirmacionContrasenia;
            set
            {
                confirmacionContrasenia = value;
                var args = new PropertyChangedEventArgs(nameof(ConfirmacionContrasenia));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command crearUsuario { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
