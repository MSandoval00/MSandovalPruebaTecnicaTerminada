using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context =new DL.MSandovalPruebaTecnicaEntities())
                {
                    //ML.Disco disco = new ML.Disco();
                    
                    var query = context.DiscoAdd(disco.Titulo,
                        disco.Artista.IdArtista,
                        disco.Genero.IdGenero,
                        disco.Duracion,
                        disco.Anio,
                        disco.Distribuidora,
                        disco.Ventas,
                        disco.Disponibilidad);
                    /*if (result.Correct)*/ //GET ALL
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No pudo registrar el disco";
                    }
                    result.Correct=true;

                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context=new DL.MSandovalPruebaTecnicaEntities())
                {
                    var query = context.DiscoUpdate(
                        disco.IdDisco,
                        disco.Titulo,
                        disco.Artista.IdArtista,
                        disco.Genero.IdGenero,
                        disco.Duracion,
                        disco.Anio,
                        disco.Distribuidora,
                        disco.Ventas,
                        disco.Disponibilidad);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "No se pudo actualizar el disco";
                    }
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex= ex;
                
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context = new DL.MSandovalPruebaTecnicaEntities())
                {
                    var query = context.DiscoGetAll().ToList();
                    result.Objects = new List<object>();
                    foreach (var row in query)
                    {
                        ML.Disco disco = new ML.Disco();
                        disco.IdDisco=row.IdDisco;
                        disco.Titulo=row.Titulo;

                        disco.Artista = new ML.Artista();
                        disco.Artista.IdArtista=row.IdArtista;
                        disco.Artista.NombreArtista=row.NombreArtista;

                        disco.Genero = new ML.Genero();
                        disco.Genero.IdGenero = row.IdGenero;
                        disco.Genero.NombreGenero = row.NombreGenero;
                        disco.Duracion=row.Duracion;
                        disco.Anio=row.Anio;
                        disco.Distribuidora=row.Distribuidora;
                        disco.Ventas = int.Parse(row.Ventas.ToString());
                        disco.Disponibilidad=row.Disponibilidad;

                        result.Objects.Add(disco);

                    }
                    result.Correct = true;  
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ML.Result Delete(int IdDisco)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context =new DL.MSandovalPruebaTecnicaEntities())
                {
                    var query = context.DiscoDelete(IdDisco);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el disco";
                    }
                    result.Correct=true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
                result.Ex=ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context =new DL.MSandovalPruebaTecnicaEntities())
                {
                    var query = context.DiscoGetById(IdDisco).FirstOrDefault();
                    result.Object=new List<object>();
                    //result.Object = query;
                    if (query!=null)
                    {
                        ML.Disco disco=new ML.Disco();
                        disco.IdDisco=query.IdDisco;
                        disco.Titulo=query.Titulo;
                        disco.Artista = new ML.Artista();
                        disco.Artista.IdArtista = query.IdArtista;
                        disco.Artista.NombreArtista = query.NombreArtista;
                        disco.Genero = new ML.Genero();
                        disco.Genero.IdGenero = query.IdGenero;
                        disco.Genero.NombreGenero=query.NombreGenero;
                        disco.Duracion=query.Duracion;
                        disco.Anio=query.Anio;
                        disco.Distribuidora=query.Distribuidora;
                        disco.Ventas = int.Parse(query.Ventas.ToString());
                        disco.Disponibilidad = query.Disponibilidad;
                        result.Object = disco;
                        result.Correct = true;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex= ex;
                throw;
            }
            return result;
        }
    }
}
