using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Ejercicio_2
{
    public partial class Ejercicio_1 : Form
    {
        private PERSONA persona;
        private const string ARCHIVO_JSON = "persona.json";
        public Ejercicio_1()
        {
            InitializeComponent();
        }

        private void btm_Crear_Objeto_Click(object sender, EventArgs e)
        {
            persona = new PERSONA
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Edad = (int)nudEdad.Value,
                FechaCreacion = DateTime.Now
            };

            lblEstado.Text = "✅ Objeto creado en memoria";
            MessageBox.Show($"Objeto creado:\n{persona}", "Éxito");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Guardar//
        private void btnSerializar_Click(object sender, EventArgs e)
        {
            if (persona == null)
            {
                MessageBox.Show("Primero debe crear un objeto", "Error");
                return;
            }

            try
            {
                string json = JsonConvert.SerializeObject(persona, Newtonsoft.Json.Formatting.Indented);  

                File.WriteAllText(ARCHIVO_JSON, json);
                lblEstado.Text = "💾 Objeto serializado y guardado";
                MessageBox.Show($"Objeto serializado en:\n{ARCHIVO_JSON}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ARCHIVO_JSON))
            {
                MessageBox.Show("No existe archivo serializado");
                return;
            }

            try
            {
                string json = File.ReadAllText(ARCHIVO_JSON);
                PERSONA personaDeserializada = JsonConvert.DeserializeObject<PERSONA>(json);

                lblEstado.Text = "🔄 Objeto deserializado desde archivo";
                MessageBox.Show($"¡Objeto recuperado!\n\n{personaDeserializada}");

                // Actualizar interfaz
                txtNombre.Text = personaDeserializada.Nombre;
                txtApellido.Text = personaDeserializada.Apellido;
                nudEdad.Value = personaDeserializada.Edad;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
