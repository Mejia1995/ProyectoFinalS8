using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalS8.Models
{
    public class CrearOrden
    {
        public int ID_orden { get; set; }
        public string TrabajoSolicitado { get; set; }
        public string EmpresaSolicitante { get; set; }
        public string DepartamentoSolicitado { get; set; }
        public string Fecha { get; set; }
    }
}
