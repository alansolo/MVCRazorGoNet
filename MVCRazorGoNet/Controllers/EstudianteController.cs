using MediatR;
using MVCRazorGoNet.Aplicacion;
using MVCRazorGoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCRazorGoNet.Controllers
{
    public class EstudianteController : Controller 
    {
        // GET: Lista
        public ActionResult Index()
        {
            Estudiante estudiante = new Estudiante("2005", "", "", "", "Ingenieria", 18);

            return View(estudiante);
        }

        [HttpPost]
        [Route("api/Estudiantes")]
        public JsonResult GetEstudiantes(Consulta.ListEstudiantes data)
        {
            Consulta.Manejador manejador = new Consulta.Manejador();
            var listaEstudiantes = manejador.Handle(data, new System.Threading.CancellationToken());

            return Json(listaEstudiantes.Result, JsonRequestBehavior.AllowGet);
        }

    }

}