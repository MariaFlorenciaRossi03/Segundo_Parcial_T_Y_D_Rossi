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
            // Crear jefe NICO
            jefe = new PERSONA
            {
                Nombre = "Nico",
                Apellido = "Rodriguez",
                Jefe = null
            };

            // Crear empleados que COMPARTEN el mismo jefe
            empleado1 = new PERSONA
            {
                Nombre = "Ana",
                Apellido = "Garcia",
                Jefe = jefe  //  Misma referencia
            };

            empleado2 = new PERSONA
            {
                Nombre = "Luis",
                Apellido = "Martinez",
                Jefe = jefe  //  Misma referencia
            };

            txtResultados.Text = "****ESCENARIO BÁSICO CREADO:****\r\n";
            txtResultados.Text += $"👤 Empleado 1: Ana → {empleado1}\r\n";
            txtResultados.Text += $"👤 Empleado 2: Luis → {empleado2}\r\n";
            txtResultados.Text += $"👨‍💼 Jefe: Nico → {jefe.Nombre} {jefe.Apellido}\r\n\r\n";
            txtResultados.Text += "🎯 Jerarquía: Ana/Luis → Nico (2 niveles)\r\n\r\n";

            btnClonacionSuperficial.Enabled = true;
            btnClonacionProfunda.Enabled = true;
            btmjefedeljefe.Enabled = true;  
        }

        private void btnClonacionSuperficial_Click(object sender, EventArgs e)
        {
            try
            {
                if (empleado1 == null) return;

                PERSONA clonSuperficial = empleado1.ClonarSuperficial();

                // ESTADO INICIAL
                txtResultados.Text += "****CLONACIÓN SUPERFICIAL:****\r\n";
                txtResultados.Text += $"Ana Original: {empleado1}\r\n";
                txtResultados.Text += $"Ana Clon: {clonSuperficial}\r\n";
                txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";

                //CAMBIAR NOMBRE DEL JEFE EN EL CLON
                clonSuperficial.Jefe.Nombre = "LUCIANO";

                // MOSTRAR RESULTADO
                txtResultados.Text += "\r\n--Después de cambiar el jefe del clon a LUCIANO:--\r\n";
                txtResultados.Text += $"Ana Original: {empleado1}\r\n";
                txtResultados.Text += $"Ana Clon: {clonSuperficial}\r\n";
                txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";
                txtResultados.Text += "❌ ¡TODOS cambiaron a LUCIANO! (referencia compartida)\r\n";
                txtResultados.Text += "⚠️ PROBLEMA: El jefe original 'Nico' se perdió para todos\r\n\r\n";

                MessageBox.Show("¡Fíjate! Todos ahora tienen como jefe a LUCIANO (no Nico)");
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

            txtResultados.Text += "****CLONACIÓN PROFUNDA RECURSIVA:****\r\n";
            txtResultados.Text += $"Ana Original: {empleado1}\r\n";
            txtResultados.Text += $"Ana Clon: {clonProfundo}\r\n";
            txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";
            txtResultados.Text += " Ambos objetos inicialmente iguales pero INDEPENDIENTES\r\n\r\n";

            // Cambiar nombre del jefe en el clon
            clonProfundo.Jefe.Nombre = "PEDRO";

            txtResultados.Text += "--Después de cambiar el jefe del clon:--\r\n";
            txtResultados.Text += $"Ana Original: {empleado1}\r\n";
            txtResultados.Text += $"Ana Clon: {clonProfundo}\r\n";
            txtResultados.Text += $"Luis (empleado2): {empleado2}\r\n";
            txtResultados.Text += "✅ Ana Original mantiene 'Nico' - ¡OBJETOS INDEPENDIENTES!\r\n";
            txtResultados.Text += "🎯 RECURSIÓN: this.Jefe?.ClonarProfundo() crea nuevo objeto automáticamente\r\n\r\n";
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtResultados.Clear();
            empleado1 = null;
            empleado2 = null;
            jefe = null;
            btnClonacionSuperficial.Enabled = false;
            btnClonacionProfunda.Enabled = false;
            btmjefedeljefe.Enabled = false;  
        }

        // JERARQUÍA COMPLETA (3 NIVELES)
        private void btmjefedeljefe_Click(object sender, EventArgs e)
        {
            if (empleado1 == null || empleado2 == null)
            {
                txtResultados.Text = "❌ Primero debes crear el escenario básico\r\n";
                return;
            }

            // Crear GERENTE 1 para Ana
            PERSONA gerenteAna = new PERSONA
            {
                Nombre = "Flor",
                Apellido = "Rossi", 
                Jefe = null  // Es la jefa suprema de Ana
            };

            // Crear GERENTE 2 para Luis
            PERSONA gerenteLuis = new PERSONA
            {
                Nombre = "Claudia",
                Apellido = "Martinez", 
                Jefe = null  // Es la jefa suprema de Luis
            };

            // Crear SUPERVISOR 1 para Ana (nivel medio)  
            PERSONA supervisorAna = new PERSONA
            {
                Nombre = "Nico",
                Apellido = "Rodriguez",
                Jefe = gerenteAna  // Su jefe es Flor
            };

            // Crear SUPERVISOR 2 para Luis (nivel medio)  
            PERSONA supervisorLuis = new PERSONA
            {
                Nombre = "Nico",
                Apellido = "Rodriguez",
                Jefe = gerenteLuis  // Su jefe es Claudia
            };

           
            empleado1.Jefe = supervisorAna;  // Ana → Nico → Flor
            empleado2.Jefe = supervisorLuis;  // Luis → Nico → Claudia

            txtResultados.Text = "****JERARQUÍA COMPLETA DE 3 NIVELES:****\r\n\r\n";
            
            txtResultados.Text += "👤 Empleado 1: Ana Garcia\r\n";
            txtResultados.Text += $"   - Jefe: {empleado1.Jefe.Nombre} {empleado1.Jefe.Apellido}\r\n";
            txtResultados.Text += $"   - Jefe del jefe: {empleado1.Jefe.Jefe.Nombre} {empleado1.Jefe.Jefe.Apellido}\r\n\r\n";
            
            txtResultados.Text += "👤 Empleado 2: Luis Martinez\r\n";
            txtResultados.Text += $"   - Jefe: {empleado2.Jefe.Nombre} {empleado2.Jefe.Apellido}\r\n";
            txtResultados.Text += $"   - Jefe del jefe: {empleado2.Jefe.Jefe.Nombre} {empleado2.Jefe.Jefe.Apellido}\r\n\r\n";
            
            txtResultados.Text += "-- JERARQUÍAS COMPLETAS (¡DIFERENTES!):--\r\n";
            txtResultados.Text += "   Ana → Nico → Flor\r\n";
            txtResultados.Text += "   Luis → Nico → Claudia\r\n\r\n";
            
            txtResultados.Text += "¡Ahora puedes clonar y ver cómo la RECURSIÓN maneja jerarquías independientes!\r\n";
            txtResultados.Text += "🔄 ClonarProfundo() clonará cada cadena completa por separado\r\n";
            txtResultados.Text += "🎪 DEMOSTRACIÓN: Ana y Luis tienen 'jefes del jefe' DIFERENTES\r\n";
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
