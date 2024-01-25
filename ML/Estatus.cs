using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Estatus
    {
        [Display(Name = "Estatus")]
        public int IdEstatus {  get; set; }
        public string Nombre { get; set; }
        public List<object> Estatdos { get; set; }
    }
}
