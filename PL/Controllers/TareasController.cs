using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class TareasController : Controller
    {
        // GET: Tareas
        public ActionResult GetAll()
        {
            ML.Tareas tareas = new ML.Tareas();
            List<object> result = BL.Tarea.GetAll();
            if (result != null)
            {
                tareas.TarealoList = result;
            }
            return View(tareas);
        }
        [HttpGet]
        public ActionResult Form(int? IdTarea)
        {
            ML.Tareas tareas = new ML.Tareas();
            tareas.Estatus = new ML.Estatus();
            List<object> resultEstatus = BL.Estatus.GetAll();
            if (IdTarea > 0)
            {
                object resultGet = BL.Tarea.GetById(IdTarea.Value);
                if (resultGet != null)
                {
                    tareas = (ML.Tareas)resultGet;
                    tareas.Estatus.Estatdos = resultEstatus;
                }
                
            }
            else
            {
                tareas.Estatus.Estatdos = resultEstatus;
            }
            return View(tareas);
        }
        [HttpPost]
        public ActionResult Form(ML.Tareas tareas)
        {
            if (tareas.IdTareas == 0)
            {
                bool result = BL.Tarea.Add(tareas);
                if (result)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente la tarea.";
                }
                else
                {
                    ViewBag.Mensaje = "Error no se agrego la tarea.";
                }
            }
            else {
                bool result = BL.Tarea.Update(tareas);
                if (result)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente la tarea.";
                }
                else
                {
                    ViewBag.Mensaje = "Error no se actualizo la tarea.";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdTarea)
        {
            bool result = BL.Tarea.Delete(IdTarea);
            if (result)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente la tarea.";
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido eliminar la tarea.";
            }
            return PartialView("Modal");
        }
    }
}