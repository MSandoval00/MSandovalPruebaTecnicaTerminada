using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MSandovalPruebaTecnicaEntities context=new DL.MSandovalPruebaTecnicaEntities())
                {
                    var query = context.GeneroGetAll().ToList();
                    result.Objects = new List<object>();
                    foreach (var row in query)
                    {
                        ML.Genero genero=new ML.Genero();
                        genero.IdGenero = row.IdGenero;
                        genero.NombreGenero = row.NombreGenero;

                        result.Objects.Add(genero); 

                    }
                    if (result.Correct)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No hay registros por consultar";
                    }
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
