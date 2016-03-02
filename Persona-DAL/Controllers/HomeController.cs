using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using PersonaDALConexion;

namespace Persona_DAL.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
         
        public ActionResult Index()
        {
            manejadoraLista listaPersona = new manejadoraLista();
            return View(listaPersona.listadosPersonasDal());
        }

        public ActionResult Edit(int? id, Persona persona)
        {
            manejadoraLista listaPersona = new manejadoraLista();
            int index = 0;
            if(id == null)
            {
                index = persona.id;
            }
            else
            {
                index = id.Value;
            }
            // id--; // el id es correcto con respecto a la base de datos pero incorrecto con la lista
            return View(listaPersona.getPersona(index));
        }

        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            return RedirectToAction("ConfirmacionSalvar", persona);
        }

        public ActionResult Details(int id)
        {
            manejadoraLista listaPersona = new manejadoraLista();
            // id--; // el id es correcto con respecto a la base de datos pero incorrecto con la lista
            return View(listaPersona.getPersona(id));
        }

        public ActionResult Create()
        {
            Persona persona = new Persona(" ", " ", new DateTime(0), " ", " ");

            return View(persona);
        }

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            manejadoraLista maneja = new manejadoraLista();
            maneja.savePersona(persona);
            return RedirectToAction("Index");
        }

        public ActionResult ConfirmacionSalvar(Persona persona)
        {
            return View(persona);
        }
        //HttpParamAction permite elegir entre varios input de un mismo formulario, es una clase creada exclusivamente para este proposito.
        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult correcto(Persona persona)
        {
            manejadoraLista maneja = new manejadoraLista();
            maneja.savePersona(persona);
            return RedirectToAction("Index");
        }

        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult modificar(Persona persona)
        {
            
            return RedirectToAction("Edit", persona);
        }

        public ActionResult Delete(int id)
        {
            manejadoraLista maneja = new manejadoraLista();
            return View(maneja.getPersona(id));
        }
        [HttpPost]
        public ActionResult Delete(Persona persona)
        {
            manejadoraLista maneja = new manejadoraLista();
            maneja.deletePersona(persona.id);
            return RedirectToAction("Index");
        }

        //public ActionResult ConfirmacionCreacion(Persona persona)
        //{
        //    return View(persona);
        //}
        //[HttpParamAction]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult creacion(Persona persona)
        //{
        //    manejadoraLista maneja = new manejadoraLista();
        //    maneja.savePersona(persona);
        //    return RedirectToAction("Index");
        //}

        //[HttpParamAction]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult repetirCreacion(Persona persona)
        //{

        //    return RedirectToAction("Create", persona);
        //}
    }
}
