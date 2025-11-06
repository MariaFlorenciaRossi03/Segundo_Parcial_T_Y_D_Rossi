using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segundo_Parcial_T_Y_D_Rossi
{
    public partial class Ejercicio_2 : Form
    {
        private PERSONA empleado1;
        private PERSONA empleado2;
        private PERSONA jefe;
        public Ejercicio_2()
        {
            InitializeComponent();
        }

        private void btnCrearEscenario_Click(object sender, EventArgs e)
        {
            // Crear jefe
            jefe = new PERSONA
            {
                Nombre = "Carlos",
                Apellido = "Rodriguez",
                Jefe = null
            };

            // Crear empleados que COMPARTEN el mismo jefe
            empleado1 = new PERSONA
            {
                Nombre = "Ana",
                Apellido = "Garcia",
                Jefe = jefe  // ⚠️ Misma referencia
            };

            empleado2 = new PERSONA
            {
                Nombre = "Luis",
                Apellido = "Martinez",
                Jefe = jefe  // ⚠️ Misma referencia
            };

            txtResultados.Text = "****ESCENARIO CREADO:****\r\n";
            txtResultados.Text += $"Empleado 1: {empleado1}\r\n";
            txtResultados.Text += $"Empleado 2: {empleado2}\r\n";
            txtResultados.Text += "✅ Ambos comparten la misma referencia del jefe\r\n\r\n";

            btnClonacionSuperficial.Enabled = true;
            btnClonacionProfunda.Enabled = true;
        }

        private void btnClonacionSuperficial_Click(object sender, EventArgs e)
        {
            try
            {
                if (empleado1 == null) return;

                PERSONA clonSuperficial = empleado1.ClonarSuperficial();

                // ✅ MOSTRAR ESTADO INICIAL
                txtResultados.Text += "****CLONACIÓN SUPERFICIAL:****\r\n";
                txtResultados.Text += $"Ana Original: {empleado1}\r\n";
                txtResultados.Text += $"Ana Clon: {clonSuperficial}\r\n";
                txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";

                // ✅ CAMBIAR NOMBRE DEL JEFE EN EL CLON
                clonSuperficial.Jefe.Nombre = "NICOLAS";

                // ✅ MOSTRAR RESULTADO
                txtResultados.Text += "\r\n🔄 Después de cambiar el jefe del clon:\r\n";
                txtResultados.Text += $"Ana Original: {empleado1}\r\n";
                txtResultados.Text += $"Ana Clon: {clonSuperficial}\r\n";
                txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";
                txtResultados.Text += "❌ TODOS cambiaron porque comparten la misma referencia del jefe\r\n\r\n";

                MessageBox.Show("¡Completado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error específico: {ex.Message}\r\n\r\nStackTrace: {ex.StackTrace}", "Error Detallado");
            }
           
        }

        private void btnClonacionProfunda_Click(object sender, EventArgs e)
        {
            if (empleado1 == null) return;

            PERSONA clonProfundo = empleado1.ClonarProfundo();

            txtResultados.Text += "****CLONACIÓN PROFUNDA:****\r\n";
            txtResultados.Text += $"Ana Original: {empleado1}\r\n";
            txtResultados.Text += $"Ana Clon: {clonProfundo}\r\n";
            txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";

            // Cambiar nombre del jefe en el clon
            clonProfundo.Jefe.Nombre = "PEDRO";

            txtResultados.Text += "\r\n🔄 Después de cambiar el jefe del clon:\r\n";
            txtResultados.Text += $"Ana Original: {empleado1}\r\n";
            txtResultados.Text += $"Ana Clon: {clonProfundo}\r\n";
            txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";
            txtResultados.Text += "✅ Ana Original y Luis NO cambiaron (objetos independientes)\r\n\r\n";
            txtResultados.Text += "🎯 DEMOSTRACIÓN COMPLETA: ¡La clonación profunda funciona!\r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResultados.Clear();
            empleado1 = null;
            empleado2 = null;
            jefe = null;
            btnClonacionSuperficial.Enabled = false;
            btnClonacionProfunda.Enabled = false;
        }

        private void Ejercicio_2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
