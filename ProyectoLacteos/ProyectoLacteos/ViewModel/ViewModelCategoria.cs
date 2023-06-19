using ProyectoLacteos.Modelo;
using ProyectoLacteos.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;


namespace ProyectoLacteos.ViewModel
{
    public class ViewModelCategoria : INotifyPropertyChanged
    {

        public ViewModelCategoria()
        {

          
            cargarCategorias();
            redirigirCategoria = new Command(() => {


                var pagina = new viewProductos();
                var viewModel = new ViewModelProductoCategoria(CategoriaSeleccionada.id);
                
                pagina.BindingContext = viewModel;
                Application.Current.MainPage.Navigation.PushAsync(pagina);
            });

        }

        public async void cargarCategorias()
        {

            ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/categorias");
            GetCategoriasResponse responseCategoria = await servicio.Get<GetCategoriasResponse>();


            foreach (ItemCategoria x in responseCategoria.items)
            {
                GetCategoriaImagen imgTmp = new GetCategoriaImagen()
                {
                    id = x.id,
                    categoria = x.categoria,
                    activo = x.activo,
                };

                listaCategorias.Add(imgTmp);

            }

        }

        GetCategoriaImagen categoriaSeleccionada;
        public GetCategoriaImagen CategoriaSeleccionada {

            get => categoriaSeleccionada;

            set
            {
                categoriaSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(CategoriaSeleccionada));
                PropertyChanged?.Invoke(this, args);
            }
        
        }

        public ObservableCollection<GetCategoriaImagen> listaCategorias { get; set; } = new ObservableCollection<GetCategoriaImagen>();

        public Command redirigirCategoria { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
