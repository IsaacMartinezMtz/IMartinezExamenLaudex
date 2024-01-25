using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatus
    {
        public static List<object> GetAll()
        {
            List<object> estados = new List<object>();
            try
            {
                using(DL.TareasEntities context = new DL.TareasEntities())
                {
                    var query = context.GetAllEstatus();
                    if(query != null)
                    {
                       foreach(var item in query)
                        {
                            ML.Estatus estatus = new ML.Estatus();
                            estatus.IdEstatus = item.IdEstatus;
                            estatus.Nombre = item.Nombre;
                            estados.Add(estatus);
                        }
                    }
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return estados;
        }
    }
}
