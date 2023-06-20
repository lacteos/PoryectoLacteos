using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoLacteos.Modelo
{
    public class ConsumoServicio
    {
        public string url { get; set; }

        public ConsumoServicio(string newUrl)
        {

            url = newUrl;


        }

        /*GET*/
        public async Task<T> Get<T>()
        {

            try
            {

                HttpClient cliente = new HttpClient();

                var response = await cliente.GetAsync(url);


                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null)
                {


                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

                }


            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");

            }

            return default(T);
        }

        /*POST*/
        public async Task<T> PostAsync<T>(Object obj)
        {



            try
            {
                HttpClient cliente = new HttpClient();

                string jsonData = JsonConvert.SerializeObject(obj);
                var formData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                var content = new FormUrlEncodedContent(formData);
                var response = await cliente.PostAsync(url, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null)
                {

                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

                }

            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");
            }


            return default(T);
        }


        /*PUT SERVICIO*/
        public async Task<T> PutAsync<T>(Object obj)
        {



            try
            {
                HttpClient cliente = new HttpClient();

                string jsonData = JsonConvert.SerializeObject(obj);
                var formData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                var content = new FormUrlEncodedContent(formData);
                var response = await cliente.PutAsync(url, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null)
                {

                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

                }

            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");
            }


            return default(T);
        }

        /*DELETE CONSUMO SERVICIO*/
        public async Task<T> Delete<T>()
        {

            try
            {

                HttpClient cliente = new HttpClient();

                var response = await cliente.DeleteAsync(url);


                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null)
                {


                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

                }


            }
            catch
            {
                Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");

            }

            return default(T);
        }

    }
}
