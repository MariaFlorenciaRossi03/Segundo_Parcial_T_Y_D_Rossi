using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio_2
{
    [Serializable]  
    public class PERSONA
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaCreacion { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}, {Edad} años (Creado: {FechaCreacion:dd/MM/yyyy HH:mm})";
        }
    }
}