using ProyectoLacteos.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProyectoLacteos.ViewModel
{
    public class ViewModelProductoCategoria : INotifyPropertyChanged
    {

        public  ViewModelProductoCategoria(int IdCategoria)
        {

            this.id_categoria = IdCategoria;
            getArticulos();

        }




        public ViewModelProductoCategoria()
        {


        }


        public async void getArticulos()
        {

            ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/lacteos/Lacteos/producto/" + id_categoria);
            GetProductoCategoria responseCategoria = await servicio.Get<GetProductoCategoria>();

            foreach (ItemProductoCategoria x in responseCategoria.items)
            {

                GetProductoCategoriaImagen imgTmp = new GetProductoCategoriaImagen()
                {
                    fotoBase64 = x.FOTO,
                    NOMBRE_PRODUCTO = x.NOMBRE_PRODUCTO,
                     unidad_medida= x.UNIDAD_MEDIDA,
                    precio = x.PRECIO,
                    
                    

                };

                imgTmp.convertirImagen();

                listaArticulo.Add(imgTmp);


            }


        }




        int id_categoria;

        public ObservableCollection<GetProductoCategoriaImagen> listaArticulo { get; set; } = new ObservableCollection<GetProductoCategoriaImagen>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
