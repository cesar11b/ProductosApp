using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Productos
{
    class ProductoModel
    {
        private Producto[] productos;

        #region CRUD
        public void Add(Producto p)
        {


            if (p == null)
            {

                throw new ArgumentException("el producto no puede estar vacio");

            }
            Add(p, ref productos);


        }


        public int Update(Producto p)
        {
            if (p == null)
            {
                throw new ArgumentException("el producto no puede ser negativo");


            }
            int index = GetIndexById(p.Id);
            if (index < 0){

                throw new ArgumentException($"el producto con id: {p.Id} no existe");

            }

            productos[index] = p;

            return index;


        }


        public bool Delete(Producto p)
        {


            if (p == null)
            {
                throw new ArgumentException("el producto no puede ser negativo");


            }
            int index = GetIndexById(p.Id);
            if (index < 0)
            {

                throw new ArgumentException($"el producto con id: {p.Id} no existe");

            }
            if(index != (productos.Length - 1))
            {

                productos[index] = productos[productos.Length - 1];



            }
            Producto[] tmp = new Producto[productos.Length - 1];
            Array.Copy(productos, tmp, tmp.Length);
            productos = tmp;



            return productos.Length == tmp.Length;

        }

        public Producto[] GetAll()
        {

            return productos;



        }




        #endregion

        #region private method

        private void Add(Producto p,ref Producto[] pds)
        {

            if (pds == null)
            {

                pds = new Producto[1];
                pds[pds.Length - 1] = p;
                return;

            }

            Producto[] tmp = new Producto[pds.Length + 1];
            Array.Copy(pds, tmp, pds.Length);
            tmp[tmp.Length - 1] = p;
            pds = tmp;


        }




        private int GetIndexById(int id)
        {

            int index = int.MinValue, i = 0;


            if(id<= 0)
            {
                throw new ArgumentException($"el id:{id} no puede ser negativo o 0");


            }


            if(productos == null)
            {
                return index;


            }

            foreach(Producto p in productos)
            {

                if (p.Id == id)
                {


                    index = i;

                    break;


                }


            }


            return index;

        }


        #endregion




        #region Queries

        public Producto getproductobyid(int id)
        {


            int index = GetIndexById(id);

            return index < 0 ? null : productos[index];


            #endregion


        }


        public Producto[] GetProductosByUnidadMedida(UnidadMedida um)
        {

            Producto[] tmp = null;

            if(productos == null)
            {

                return tmp;



            }


            foreach(Producto p in productos)
            {

                if(p.UnidadMedida == um)
                {

                    Add(p, ref tmp);



                }



            }
            return tmp;





        }



    }


}
