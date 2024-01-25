using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tarea
    {
        public static List<object> GetAll()
        {
            List<object> tareas = new List<object>();
            try
            {
                using(DL.TareasEntities context = new DL.TareasEntities())
                {
                    var query = context.GetAllTareas();
                    if(query != null)
                    {
                        foreach (var tareaF in query)
                        {
                            ML.Tareas tareas1 = new ML.Tareas();
                            tareas1.Estatus = new ML.Estatus();
                            tareas1.IdTareas = tareaF.IdTarea;
                            tareas1.Titulo = tareaF.Titulo;
                            tareas1.Descripcion = tareaF.Descripcion;
                            tareas1.Fecha = (DateTime)tareaF.FechaVencimiento;
                            tareas1.Estatus.IdEstatus = (int)tareaF.Estado;
                            tareas1.Estatus.Nombre = tareaF.Nombre;
                            tareas.Add(tareas1);
                        }
                    }
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tareas;
        }
        public static object GetById(int IdTareas)
        {
            object tarea = new object();
            try
            {
                using(DL.TareasEntities context = new DL.TareasEntities())
                {
                    var query = context.GetByIdTareas(IdTareas).FirstOrDefault();
                    if(query != null)
                    {
                        ML.Tareas tareas = new ML.Tareas();
                        tareas.Estatus = new ML.Estatus();
                        tareas.IdTareas = query.IdTarea;
                        tareas.Titulo = query.Titulo;
                        tareas.Descripcion = query.Descripcion;
                        tareas.Fecha = (DateTime)query.FechaVencimiento;
                        tareas.Estatus.IdEstatus = (int)query.Estado;
                        tareas.Estatus.Nombre = query.Nombre;
                        tarea = tareas;
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tarea;
        }
        public static bool Add(ML.Tareas tareas)
        {
            tareas.Estatus = new ML.Estatus();
            bool Correct = false;
            try
            {
                using(DL.TareasEntities context = new DL.TareasEntities())
                {
                      
                    var query = context.AddTareas(tareas.Titulo, tareas.Descripcion, tareas.Fecha, tareas.Estatus.IdEstatus);
                    if(query > 0)
                    {
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                Correct = false;
            }
            return Correct;
        }
        public static bool Update(ML.Tareas tareas)
        {
            bool Correct = false;
            try
            {
                using(DL.TareasEntities context = new DL.TareasEntities())
                {
                    var query = context.UpdateTarea(tareas.IdTareas, tareas.Titulo, tareas.Descripcion, tareas.Fecha, tareas.Estatus.IdEstatus);
                    if(query > 0)
                    {
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                Correct = false;
            }
            return Correct;
        }
        public static bool Delete(int IdTarea)
        {
            bool Correct = false;
            try
            {
                using(DL.TareasEntities context = new DL.TareasEntities())
                {
                    var query = context.DeleteTarea(IdTarea);
                    if(query > 0)
                    {
                        Correct = true;
                    }
                    else
                    {
                        Correct=false;
                    }
                }

            }catch(Exception ex)
            {
                Correct=false;
            }
            return Correct;
        }
    }
}
