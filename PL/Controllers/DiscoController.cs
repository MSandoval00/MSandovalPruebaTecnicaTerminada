using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        public ActionResult GetAll()
        {
            ML.Result result=BL.Disco.GetAll();
            ML.Disco disco=new ML.Disco();
            disco.Discos = new List<object>();
            if (result.Correct)
            {
                disco.Discos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }
            return View(disco);
        }
        [HttpGet]
        public ActionResult Form(int? IdDisco)
        {
            
            ML.Disco disco = new ML.Disco();
            //ML.Disco disco=new ML.Disco();
            ML.Result resultadoArtista=BL.Artista.GetAll(); 
            ML.Result resultadoGenero=BL.Genero.GetAll(); 
            disco.Artista = new ML.Artista();
            disco.Genero=new ML.Genero();

            
            if (IdDisco != null)//Update
            {
                //ML.Result result=new ML.Result();
                ML.Result result = BL.Disco.GetById(IdDisco.Value);
                if (result.Correct)
                {
                    disco=(ML.Disco)result.Object;
                    disco.Discos = resultadoArtista.Objects;
                    disco.Discos2=resultadoGenero.Objects;
                }
            }
            else//Add
            {
                disco.Discos = resultadoArtista.Objects;
                disco.Discos2 = resultadoGenero.Objects;
            }
            return View(disco);
            //return View(disco1);

        }
        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            //ML.Result result = new ML.Result();
            if (disco.IdDisco==0)//Add
            {
                ML.Result result = BL.Disco.Add(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se agrego correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo registrar el disco correctamente" + result.ErrorMessage;
                }
            }
            else//Update
            {
                ML.Result result = BL.Disco.Update(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualizado Correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo registrar el disco"+ result.ErrorMessage;
                }

            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdDisco)
        {
            ML.Result result = BL.Disco.Delete(IdDisco);
           
            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar correctamente "+result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}