﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ProyectoLacteos.View.ViewDetallePedido;

namespace ProyectoLacteos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDetallePedido : ContentPage
    {
        private HttpClient httpClient;
        private List<string> categorias;
        private string categProducto;


        public ViewDetallePedido()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            categorias = new List<string>();

            CargarCategorias();
            
        }
        private async void CategoriaEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ejecutar CargarProductos()
           
            await CargarProductos();

        }


        private async void CargarCategorias()
        {
            try
            {
                string categoriasUrl = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/categorias";
                HttpResponseMessage categoriasResponse = await httpClient.GetAsync(categoriasUrl);

                if (categoriasResponse.IsSuccessStatusCode)
                {
                    string categoriasJson = await categoriasResponse.Content.ReadAsStringAsync();
                    var categoriasData = JsonConvert.DeserializeObject<RootObject>(categoriasJson);

                    foreach (var item in categoriasData.items)
                    {
                        categorias.Add(item.categoria);
                        

                    }

                    CategoriaPicker.ItemsSource = categorias;
                    CategoriaPicker.SelectedIndexChanged += (sender, e) =>
                    {
                        var selectedCategoria = CategoriaPicker.SelectedItem?.ToString();
                        var selectedItem = categoriasData.items.Find(x => x.categoria == selectedCategoria);
                        CategoriaEntry.Text = selectedItem?.id.ToString();
                       


                    };

                   
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar las categorías.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error al cargar las categorías.", "OK");
            }
        }

        
        
        private async Task CargarProductos()
        {
            try
            {
                categProducto = CategoriaEntry.Text;
                string productosUrl = "https://apex.oracle.com/pls/apex/lacteos/Lacteos/producto/" + categProducto;
                HttpResponseMessage productosResponse = await httpClient.GetAsync(productosUrl);

                if (productosResponse.IsSuccessStatusCode)
                {
                    string productosJson = await productosResponse.Content.ReadAsStringAsync();
                    var productosData = JsonConvert.DeserializeObject<ProductosRootObject>(productosJson);

                    List<string> productos = new List<string>();
                    foreach (var item in productosData.items)
                    {
                        productos.Add(item.nombre_producto);
                    }

                    ProductoPicker.ItemsSource = productos;
                    ProductoPicker.SelectedIndexChanged += (sender, e) =>
                    {
                        var selectedProducto = ProductoPicker.SelectedItem?.ToString();
                        var selectedItem = productosData.items.Find(x => x.nombre_producto == selectedProducto);
                        ProductoEntry.Text = selectedItem?.id.ToString();
                        LabelPrecio.Text = selectedItem?.precio.ToString();
                    };
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar los productos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error al cargar los productos.", "OK");
            }
        }



        public class Item
        {
            public int id { get; set; }
            public string categoria { get; set; }
            public int activo { get; set; }
            public object foto { get; set; }
        }

        public class RootObject
        {
            public List<Item> items { get; set; }
            public bool hasMore { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int count { get; set; }
            public List<Link> links { get; set; }
        }

        public class Link
        {
            public string rel { get; set; }
            public string href { get; set; }
        }

        public class Producto
        {
            public int id { get; set; }
            public string nombre_producto { get; set; }
            public int id_categoria { get; set; }
            public decimal precio { get; set; }
            public object foto { get; set; }
        }

        public class ProductosRootObject
        {
            public List<Producto> items { get; set; }
            public bool hasMore { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int count { get; set; }
            public List<Link> links { get; set; }
        }
    }


    
}
