using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFactCS.Modelo
{
    internal class ClsUsuarios
    {
        internal int Id { get; set; }
        internal string Codigo { get; set; }
        internal string Usuario { get; set; }
        internal string Clave { get; set; }
        internal string Color { get; set; }
        //Administrador 0, usuario normal 1
        internal int Tipo { get; set; }

        //COnstructor vacío
        public ClsUsuarios() { }



    }
}
