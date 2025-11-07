using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Parcial_T_Y_D_Rossi
{
    public class PERSONA
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public PERSONA Jefe { get; set; }


        public PERSONA ClonarSuperficial()
        {
            return new PERSONA
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Jefe = this.Jefe  // Misma referencia!
            };
        }

     
        public PERSONA ClonarProfundo()
        {
            return new PERSONA
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Jefe = this.Jefe?.ClonarProfundo()  // RECURSIÓN 
            };
        }

        public override string ToString()
        {
            string jefeInfo = Jefe != null ? $"{Jefe.Nombre} {Jefe.Apellido}" : "Sin jefe";
            return $"{Nombre} {Apellido} (Jefe: {jefeInfo})";
        }
    }
}