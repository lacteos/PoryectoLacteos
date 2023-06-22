using Newtonsoft.Json;
using ProyectoLacteos.Modelo;
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
    public partial class viewPedido : ContentPage
    {
        private HttpClient httpClient;

        public viewPedido()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            LoadDireccionValues();
        }

        private string usuario = SharedData.DataId;
        private async Task LoadDireccionValues()
        {
            try
            {
                string url = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/direccion/" + usuario;
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponse>(json);

                    List<KeyValuePair<int, string>> direccionValues = new List<KeyValuePair<int, string>>();

                    foreach (var item in result.Items)
                    {
                        int id = item.Id;
                        string direccion = item.Direccion;

                        if (!string.IsNullOrEmpty(direccion)) // Verifica si la dirección no es nula o vacía
                        {
                            direccionValues.Add(new KeyValuePair<int, string>(id, direccion));
                        }
                    }

                    direccionPicker.ItemsSource = direccionValues;
                    direccionPicker.ItemDisplayBinding = new Binding("Value"); // Muestra la dirección en el picker

                    direccionPicker.SelectedIndexChanged += (sender, e) =>
                    {
                        var selectedPair = (KeyValuePair<int, string>)direccionPicker.SelectedItem;
                        int selectedId = selectedPair.Key;
                        labeldireccion.Text = selectedId.ToString();
                    };
                }
                else
                {
                    // Maneja el caso cuando la solicitud no es exitosa
                    // ...
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción
                // ...
            }
        }

        private class ApiResponse
        {
            public List<DireccionItem> Items { get; set; }
        }

        private class DireccionItem
        {
            public int Id { get; set; }
            public string Direccion { get; set; }
            public string Descripcion { get; set; }
            public int Id_Usuario { get; set; }
        }
    }
}
