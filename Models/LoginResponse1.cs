using ProyectoFinalS8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalS8.Models
{
    public class LoginResponse1
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public CrearUsuario User { get; set; }
    }
}
