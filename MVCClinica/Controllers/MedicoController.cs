using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCClinica.Data;
using MVCClinica.Models;
using System.Data.Entity;
using MVCClinica.Admin;
using MVCClinica.Filters;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        
        // GET: Medico
        public ActionResult Index()
        {          
            return View("Index",AdmMedico.Listar());
        }

        [HttpGet]
        [MyFilter]
        public ActionResult Crear()
        {
            Medico medico = new Medico();
            return View("Crear", medico);
        }

        public ActionResult Crear(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Cargar(medico);
                return RedirectToAction("Index");
            }
            return View("Crear", medico);
        }
        public ActionResult Modificar(int id)
        {
            Medico medico = AdmMedico.Buscar(id);
            if(medico == null)
            {
                
                return HttpNotFound();
            }

            return View("Modificar", medico);
        }
        [HttpPost]
        public ActionResult Modificar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Modificar(medico);
                return RedirectToAction("Index");
            }
            return View("Modificar", medico);
        }

        public ActionResult Eliminar(int id)
        {
            Medico medico = AdmMedico.Listar(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View("Eliminar", medico);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult ConfirmarEliminacion(int id)
        {
            Medico medico = AdmMedico.Listar(id);
            if(medico == null)
            {
                return HttpNotFound();
            }
            AdmMedico.Eliminar(medico);
            return RedirectToAction("Index");
        }

        public ActionResult TraerId(int id)
        {
            Medico medico = AdmMedico.Listar(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View("TraerId", medico);
        }

        public ActionResult BuscarEspecialidad(string especialidad)
        {
            if (especialidad == null)
            {
                return RedirectToAction("Index");
            }
            return View("Index", AdmMedico.TraerEspecialidad(especialidad));
        }

        public ActionResult BuscarNombreApellido(string nombre , string apellido)
        {
            if (nombre == null && apellido == null)
            {
                return RedirectToAction("Index");
            }
            return View("Index", AdmMedico.TraerNombreApellido(nombre,apellido));
        }
    }
}