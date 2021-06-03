using Microsoft.EntityFrameworkCore;
using PrimerParcialApl2.DAL;
using PrimerParcialApl2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerParcialApl2.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            Contexto contexto = new Contexto();

            bool paso = false;
            try
            {
                if (articulo.ArticuloId != 0)
                    paso = Modificar(articulo);
                else
                    paso = Insertar(articulo);
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static bool Insertar(Articulos articulo)
        {
            Contexto contexto = new Contexto();
           
            bool paso=false;
            try
            {
                contexto.Articulos.Add(articulo);
                Calcular();
                paso = contexto.SaveChanges()>0;
                Calcular();
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static void Calcular()
        {
            
            var lista = GetList(p => true);
            decimal valor = 0;
            foreach (var item in lista)
            {
                valor += item.Cantidad * item.Costo;
            }
            foreach (var item in lista)
            {
                item.Inventario = valor;
            }
            
            
        }
        public static bool Modificar(Articulos articulo)
        {
            Contexto contexto = new Contexto();

            bool paso = false;
            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                Calcular();
                paso = contexto.SaveChanges() > 0;
                
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulo = new Articulos();
            bool paso = false;
            try
            {
                if (id!=0)
                {
                    articulo = contexto.Articulos.Find(id);
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return articulo;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Articulos articulo = new Articulos();
            
            try
            {
               articulo = contexto.Articulos.Find(id);
               contexto.Articulos.Remove(articulo);
               paso = contexto.SaveChanges()>0;
                Calcular();

            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Articulos> list = new List<Articulos>();
            try
            {
                list = contexto.Articulos.Where(expression).ToList();
                //Calcular();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
    }
}
