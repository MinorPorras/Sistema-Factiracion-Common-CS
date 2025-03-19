using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFactCS.Modelo
{
    internal class clsUsuarios
    {
        internal int ID { get; set; }
        internal string codigo { get; set; }
        internal string usuario { get; set; }
        internal string clave { get; set; }
        internal string color { get; set; }
        //Administrador 0, usuario normal 1
        internal int tipo { get; set; }

        //COnstructor vacío
        public clsUsuarios() { }



    }
}
