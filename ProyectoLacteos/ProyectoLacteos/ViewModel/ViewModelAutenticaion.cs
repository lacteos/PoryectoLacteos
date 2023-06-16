using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ProyectoLacteos.ViewModel;
using ProyectoLacteos.Modelo;
using Xamarin.Forms;
using ProyectoLacteos.View;

namespace ProyectoLacteos.ViewModel
{
    public class ViewModelAutenticaion
    {
        public ViewModelAutenticaion()
        {

            autenticacion = new Command(async () =>
            {

                string urlNueva = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/login";

                ConsumoServicio servicio = new ConsumoServicio(urlNueva);

                LoginRequest auth = new LoginRequest()
                {
                    p_correo = Correo,    
                    p_contra = Contrasenia
                };

                Autenticacion response = await servicio.PostAsync<Autenticacion>(auth);

                if (response.respuesta == "true")
                {

                    var pagina = new PaginaInicio();
                    Application.Current.MainPage.Navigation.PushAsync(pagina);

                }
                else
                {

                    if (response.respuesta == "false")
                    {
                        ResultAuth = "Autenticacion Incorrecta";
                        Application.Current.MainPage.DisplayAlert("Error", "Contraseña o correo no validos", "OK");

                    }


                }



            });


            redirigirCrearUsuario = new Command(() => {


                var pagina = new viewRegistroUser();
                Application.Current.MainPage.Navigation.PushAsync(pagina);


            });


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

        string resultAuth;

        public string ResultAuth
        {
            get => resultAuth;
            set
            {
                resultAuth = value;
                var args = new PropertyChangedEventArgs(nameof(ResultAuth));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command autenticacion { get; }

        public Command redirigirCrearUsuario { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
