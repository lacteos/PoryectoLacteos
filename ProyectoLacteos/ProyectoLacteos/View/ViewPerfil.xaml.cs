using Newtonsoft.Json;
using ProyectoLacteos.Modelo;
using ProyectoLacteos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoLacteos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPerfil : ContentPage
    {
        public ViewPerfil()
        {
            InitializeComponent();
           

        }

        private string valorId = string.Empty;
        private string valorNombre = string.Empty;
        private string valorTelefono = string.Empty;
        private string valorCorreo = string.Empty;
        private string valorContrasena = string.Empty;

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            string entryName = entry.ClassId; // Obtener el ClassId del Entry actual

            switch (entryName)
            {
                case "id":
                    valorId = entry.Text;
                    break;
                case "nombre":
                    valorNombre = entry.Text;
                    break;
                case "telefono":
                    valorTelefono = entry.Text;
                    break;
                case "correo":
                    valorCorreo = entry.Text;
                    break;
                case "contrasena":
                    valorContrasena = entry.Text;
                    break;
                default:
                    break;
            }
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            SharedData.MyData = valorCorreo;

            // Construir la URL con el ID correspondiente
            string url = $"https://apex.oracle.com/pls/apex/lacteos/Lacteos/usuario/{valorId}";

            // Crear un objeto JSON con los datos a enviar
            var json = new Dictionary<string, string>
    {
        { "NM", valorNombre },
        { "TEL", valorTelefono },
        { "EMAIL", valorCorreo },
        { "PASS", valorContrasena }
    };

            // Convertir el objeto JSON a una cadena JSON
            string jsonContent = JsonConvert.SerializeObject(json);

            // Crear el contenido de la solicitud HTTP
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Crear una instancia de HttpClient
            HttpClient client = new HttpClient();

            try
            {
                // Enviar la solicitud PUT al servidor
                HttpResponseMessage response = await client.PutAsync(url, content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // La solicitud PUT se realizó correctamente
                    await DisplayAlert("Solicitud exitosa", "La información se actualizó correctamente.", "Aceptar");
                }
                else
                {
                    // La solicitud PUT no se pudo completar
                    await DisplayAlert("Error", "No se pudo actualizar la información.", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                // Ocurrió un error durante la solicitud
                await DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "Aceptar");
            }
            finally
            {
                // Liberar los recursos de HttpClient
                client.Dispose();
            }
        }


    }
}