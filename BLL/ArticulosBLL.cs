using Microsoft.EntityFrameworkCore;
using PrimerParcialApl2.DAL;
using PrimerParcialApl2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialApl2.BLL
{
    public class ArticulosBLL
    {
        private static bool Insertar(Articulos articulo)
        {
            Contexto contexto = new Contexto();
           
            bool paso=false;
            try
            {
                contexto.Articulos.Add(articulo);
                paso = contexto.SaveChanges()>0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }
        private static bool Modificar(Articulos articulo)
        {
            Contexto contexto = new Contexto();

            bool paso = false;
            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        private static Articulos Buscar(int id)
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

        private static Articulos Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Articulos articulo = new Articulos();
            
            try
            {
               articulo = contexto.Articulos.Find(id);
               

            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }
    }
}
