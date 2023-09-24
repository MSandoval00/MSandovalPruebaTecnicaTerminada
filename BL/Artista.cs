using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Artista
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context=new DL.MSandovalPruebaTecnicaEntities())
                {
                    var query = context.ArtistaGetAll().ToList();
                    result.Objects = new List<object>();
                    foreach (var row in query)
                    {
                        ML.Artista artista = new ML.Artista();
                        artista.IdArtista = int.Parse(row.IdArtista.ToString());
                        artista.NombreArtista = row.NombreArtista;

                        result.Objects.Add(artista);
                        
                    }
                    result.Correct = true;
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
    }
}
