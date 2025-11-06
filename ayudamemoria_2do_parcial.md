# Ayudamemoria - Segundo Parcial T&D
### Alumna: Florencia Rossi  
### Lenguaje: C# (.NET – Windows Forms)

---

## 📋 Estructura General del Proyecto

```
Segundo_Parcial_Rossi/
├── Segundo_Parcial_Rossi.sln
├── ayudamemoria_2do_parcial.md
├── Ejercicio1_Serializacion/
│   ├── Program.cs
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Persona.cs
│   └── Ejercicio1_Serializacion.csproj
├── Ejercicio2_ClonacionProfunda/
│   ├── Program.cs
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Persona.cs
│   └── Ejercicio2_ClonacionProfunda.csproj
└── Ejercicio3_HilosConcurrentes/
    ├── Program.cs
    ├── Form1.cs
    ├── Form1.Designer.cs
    └── Ejercicio3_HilosConcurrentes.csproj
```

---

## 🔹 EJERCICIO 1: Serialización y Deserialización

### 🎯 **Consigna**
*"Posea tres botones. El primero debe crear un objeto. El segundo debe serializar ese objeto. El tercero debe deserializarlo y demostrar que el objeto existe nuevamente en memoria."*

### 💾 **Persistencia**: ✅ Archivo JSON (`persona.json`)
### 🏗️ **Arquitectura**: 1 capa simple

### 📦 **PASO PREVIO: Instalar Newtonsoft.Json**
1. **Click derecho** en tu proyecto → **"Administrar paquetes NuGet..."**
2. Pestaña **"Examinar"** → Buscar: `Newtonsoft.Json`
3. **Instalar** el primer resultado
4. **O usar consola**: `Install-Package Newtonsoft.Json`

---

### **Persona.cs**
```csharp
using System;

namespace Ejercicio1_Serializacion
{
    [Serializable]
    public class Persona
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
```

### **Form1.cs - Código Principal**
```csharp
using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Ejercicio1_Serializacion
{
    public partial class Form1 : Form
    {
        private Persona persona;
        private const string ARCHIVO_JSON = "persona.json";

        public Form1()
        {
            InitializeComponent();
        }

        // 🔹 BOTÓN 1: CREAR OBJETO
        private void btnCrearObjeto_Click(object sender, EventArgs e)
        {
            persona = new Persona
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Edad = (int)nudEdad.Value,
                FechaCreacion = DateTime.Now
            };

            lblEstado.Text = "✅ Objeto creado en memoria";
            MessageBox.Show($"Objeto creado:\n{persona}", "Éxito");
        }

        // 🔹 BOTÓN 2: SERIALIZAR (GUARDAR)
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

        // 🔹 BOTÓN 3: DESERIALIZAR (LEER)
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
                Persona personaDeserializada = JsonConvert.DeserializeObject<Persona>(json);

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
```

### **Form1.Designer.cs - Controles**
```csharp
private void InitializeComponent()
{
    this.txtNombre = new TextBox();
    this.txtApellido = new TextBox();
    this.nudEdad = new NumericUpDown();
    this.btnCrearObjeto = new Button();
    this.btnSerializar = new Button();
    this.btnDeserializar = new Button();
    this.lblEstado = new Label();

    // txtNombre
    this.txtNombre.Location = new System.Drawing.Point(120, 30);
    this.txtNombre.Size = new System.Drawing.Size(200, 23);
    this.txtNombre.Text = "Florencia";

    // txtApellido
    this.txtApellido.Location = new System.Drawing.Point(120, 70);
    this.txtApellido.Size = new System.Drawing.Size(200, 23);
    this.txtApellido.Text = "Rossi";

    // nudEdad
    this.nudEdad.Location = new System.Drawing.Point(120, 110);
    this.nudEdad.Size = new System.Drawing.Size(100, 23);
    this.nudEdad.Value = 22;
    this.nudEdad.Minimum = 1;
    this.nudEdad.Maximum = 120;

    // btnCrearObjeto
    this.btnCrearObjeto.Location = new System.Drawing.Point(30, 160);
    this.btnCrearObjeto.Size = new System.Drawing.Size(120, 35);
    this.btnCrearObjeto.Text = "1. Crear Objeto";
    this.btnCrearObjeto.Click += this.btnCrearObjeto_Click;

    // btnSerializar
    this.btnSerializar.Location = new System.Drawing.Point(170, 160);
    this.btnSerializar.Size = new System.Drawing.Size(120, 35);
    this.btnSerializar.Text = "2. Serializar";
    this.btnSerializar.Click += this.btnSerializar_Click;

    // btnDeserializar
    this.btnDeserializar.Location = new System.Drawing.Point(310, 160);
    this.btnDeserializar.Size = new System.Drawing.Size(120, 35);
    this.btnDeserializar.Text = "3. Deserializar";
    this.btnDeserializar.Click += this.btnDeserializar_Click;

    // lblEstado
    this.lblEstado.Location = new System.Drawing.Point(30, 220);
    this.lblEstado.Size = new System.Drawing.Size(400, 23);
    this.lblEstado.Text = "Listo para comenzar...";

    // Form1
    this.ClientSize = new System.Drawing.Size(464, 261);
    this.Text = "Ejercicio 1 - Serialización";
    this.Controls.Add(this.txtNombre);
    this.Controls.Add(this.txtApellido);
    this.Controls.Add(this.nudEdad);
    this.Controls.Add(this.btnCrearObjeto);
    this.Controls.Add(this.btnSerializar);
    this.Controls.Add(this.btnDeserializar);
    this.Controls.Add(this.lblEstado);
}
```

---

## 🔹 EJERCICIO 2: Clonación Profunda

### 🎯 **Consigna**
*"Realice una clonación profunda de un objeto persona que posee: Nombre (string), Apellido (string), Jefe (Persona). Demostrar que funciona haciendo que dos personas tengan el mismo jefe y cambiándole el nombre del jefe a una de ellas y mostrando que el nombre del jefe de la otra permanece inmutable."*

### 💾 **Persistencia**: ❌ Todo en memoria
### 🏗️ **Arquitectura**: 1 capa simple

---

### **Persona.cs**
```csharp
using System;

namespace Ejercicio2_ClonacionProfunda
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Persona Jefe { get; set; }

        // ⚠️ CLONACIÓN SUPERFICIAL (copia la referencia)
        public Persona ClonarSuperficial()
        {
            return new Persona
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Jefe = this.Jefe  // ⚠️ Misma referencia!
            };
        }

        // ✅ CLONACIÓN PROFUNDA (crea nuevo objeto)
        public Persona ClonarProfundo()
        {
            return new Persona
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Jefe = this.Jefe == null ? null : new Persona
                {
                    Nombre = this.Jefe.Nombre,
                    Apellido = this.Jefe.Apellido,
                    Jefe = this.Jefe.Jefe // Recursivo si es necesario
                }
            };
        }

        public override string ToString()
        {
            string jefeInfo = Jefe != null ? $"{Jefe.Nombre} {Jefe.Apellido}" : "Sin jefe";
            return $"{Nombre} {Apellido} (Jefe: {jefeInfo})";
        }
    }
}
```

### **Form1.cs - Código Principal**
```csharp
using System;
using System.Windows.Forms;

namespace Ejercicio2_ClonacionProfunda
{
    public partial class Form1 : Form
    {
        private Persona empleado1;
        private Persona empleado2;
        private Persona jefe;

        public Form1()
        {
            InitializeComponent();
        }

        // 🔹 CREAR ESCENARIO DE PRUEBA
        private void btnCrearEscenario_Click(object sender, EventArgs e)
        {
            // Crear jefe
            jefe = new Persona
            {
                Nombre = "Carlos",
                Apellido = "Rodriguez",
                Jefe = null
            };

            // Crear empleados que COMPARTEN el mismo jefe
            empleado1 = new Persona
            {
                Nombre = "Ana",
                Apellido = "Garcia",
                Jefe = jefe  // ⚠️ Misma referencia
            };

            empleado2 = new Persona
            {
                Nombre = "Luis",
                Apellido = "Martinez",
                Jefe = jefe  // ⚠️ Misma referencia
            };

            txtResultados.Text = "🔧 ESCENARIO CREADO:\r\n";
            txtResultados.Text += $"Empleado 1: {empleado1}\r\n";
            txtResultados.Text += $"Empleado 2: {empleado2}\r\n";
            txtResultados.Text += "✅ Ambos comparten la misma referencia del jefe\r\n\r\n";

            btnClonacionSuperficial.Enabled = true;
            btnClonacionProfunda.Enabled = true;
        }

        // 🔹 DEMOSTRACIÓN CLONACIÓN SUPERFICIAL
        private void btnClonacionSuperficial_Click(object sender, EventArgs e)
        {
            if (empleado1 == null) return;

            Persona clonSuperficial = empleado1.ClonarSuperficial();
            
            txtResultados.Text += "⚠️ CLONACIÓN SUPERFICIAL:\r\n";
            txtResultados.Text += $"Original: {empleado1}\r\n";
            txtResultados.Text += $"Clon: {clonSuperficial}\r\n";

            // Cambiar nombre del jefe en el clon
            clonSuperficial.Jefe.Nombre = "CARLOS MODIFICADO";

            txtResultados.Text += "\r\n🔄 Después de cambiar el jefe del clon:\r\n";
            txtResultados.Text += $"Original: {empleado1}\r\n";
            txtResultados.Text += $"Clon: {clonSuperficial}\r\n";
            txtResultados.Text += "❌ El original TAMBIÉN cambió (referencia compartida)\r\n\r\n";

            // Restaurar para siguiente prueba
            jefe.Nombre = "Carlos";
        }

        // 🔹 DEMOSTRACIÓN CLONACIÓN PROFUNDA
        private void btnClonacionProfunda_Click(object sender, EventArgs e)
        {
            if (empleado1 == null) return;

            Persona clonProfundo = empleado1.ClonarProfundo();
            
            txtResultados.Text += "✅ CLONACIÓN PROFUNDA:\r\n";
            txtResultados.Text += $"Original: {empleado1}\r\n";
            txtResultados.Text += $"Clon: {clonProfundo}\r\n";

            // Cambiar nombre del jefe en el clon
            clonProfundo.Jefe.Nombre = "CARLOS MODIFICADO";

            txtResultados.Text += "\r\n🔄 Después de cambiar el jefe del clon:\r\n";
            txtResultados.Text += $"Original: {empleado1}\r\n";
            txtResultados.Text += $"Clon: {clonProfundo}\r\n";
            txtResultados.Text += "✅ El original NO cambió (objetos independientes)\r\n\r\n";
            txtResultados.Text += "🎯 DEMOSTRACIÓN COMPLETA: ¡La clonación profunda funciona!\r\n";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtResultados.Clear();
            empleado1 = null;
            empleado2 = null;
            jefe = null;
            btnClonacionSuperficial.Enabled = false;
            btnClonacionProfunda.Enabled = false;
        }
    }
}
```

### **Form1.Designer.cs - Controles**
```csharp
private void InitializeComponent()
{
    this.btnCrearEscenario = new Button();
    this.btnClonacionSuperficial = new Button();
    this.btnClonacionProfunda = new Button();
    this.btnLimpiar = new Button();
    this.txtResultados = new TextBox();

    // btnCrearEscenario
    this.btnCrearEscenario.Location = new System.Drawing.Point(30, 30);
    this.btnCrearEscenario.Size = new System.Drawing.Size(150, 35);
    this.btnCrearEscenario.Text = "1. Crear Escenario";
    this.btnCrearEscenario.Click += this.btnCrearEscenario_Click;

    // btnClonacionSuperficial
    this.btnClonacionSuperficial.Location = new System.Drawing.Point(200, 30);
    this.btnClonacionSuperficial.Size = new System.Drawing.Size(150, 35);
    this.btnClonacionSuperficial.Text = "2. Clon Superficial";
    this.btnClonacionSuperficial.Enabled = false;
    this.btnClonacionSuperficial.Click += this.btnClonacionSuperficial_Click;

    // btnClonacionProfunda
    this.btnClonacionProfunda.Location = new System.Drawing.Point(370, 30);
    this.btnClonacionProfunda.Size = new System.Drawing.Size(150, 35);
    this.btnClonacionProfunda.Text = "3. Clon Profundo";
    this.btnClonacionProfunda.Enabled = false;
    this.btnClonacionProfunda.Click += this.btnClonacionProfunda_Click;

    // btnLimpiar
    this.btnLimpiar.Location = new System.Drawing.Point(540, 30);
    this.btnLimpiar.Size = new System.Drawing.Size(100, 35);
    this.btnLimpiar.Text = "Limpiar";
    this.btnLimpiar.Click += this.btnLimpiar_Click;

    // txtResultados
    this.txtResultados.Location = new System.Drawing.Point(30, 85);
    this.txtResultados.Multiline = true;
    this.txtResultados.ScrollBars = ScrollBars.Vertical;
    this.txtResultados.Size = new System.Drawing.Size(610, 350);
    this.txtResultados.Font = new System.Drawing.Font("Consolas", 9F);
    this.txtResultados.ReadOnly = true;

    // Form1
    this.ClientSize = new System.Drawing.Size(674, 461);
    this.Text = "Ejercicio 2 - Clonación Profunda";
    this.Controls.Add(this.btnCrearEscenario);
    this.Controls.Add(this.btnClonacionSuperficial);
    this.Controls.Add(this.btnClonacionProfunda);
    this.Controls.Add(this.btnLimpiar);
    this.Controls.Add(this.txtResultados);
}
```

---

## 🔹 EJERCICIO 3: Hilos Concurrentes

### 🎯 **Consigna**  
*"Muestre en dos cajas de texto el resultado de correr dos whiles infinitos donde uno es contador de números pares y el otro de impares. Ambos whiles se arrancan con botones individuales y deben actualizar las cajas de texto simultáneamente."*

### 💾 **Persistencia**: ❌ Solo ejecución en tiempo real
### 🏗️ **Arquitectura**: 1 capa simple

---

### **Form1.cs - Código Principal**
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3_HilosConcurrentes
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource tokenPares;
        private CancellationTokenSource tokenImpares;
        private bool paresEjecutandose = false;
        private bool imparesEjecutandose = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 🔹 INICIAR CONTADOR PARES
        private async void btnIniciarPares_Click(object sender, EventArgs e)
        {
            if (paresEjecutandose) return;

            paresEjecutandose = true;
            tokenPares = new CancellationTokenSource();
            btnIniciarPares.Enabled = false;
            btnDetenerPares.Enabled = true;

            try
            {
                await Task.Run(() => ContadorPares(tokenPares.Token));
            }
            catch (OperationCanceledException)
            {
                // Hilo cancelado correctamente
            }
            finally
            {
                paresEjecutandose = false;
                if (!IsDisposed)
                {
                    Invoke(new Action(() =>
                    {
                        btnIniciarPares.Enabled = true;
                        btnDetenerPares.Enabled = false;
                    }));
                }
            }
        }

        private void btnDetenerPares_Click(object sender, EventArgs e)
        {
            tokenPares?.Cancel();
        }

        // 🔹 INICIAR CONTADOR IMPARES
        private async void btnIniciarImpares_Click(object sender, EventArgs e)
        {
            if (imparesEjecutandose) return;

            imparesEjecutandose = true;
            tokenImpares = new CancellationTokenSource();
            btnIniciarImpares.Enabled = false;
            btnDetenerImpares.Enabled = true;

            try
            {
                await Task.Run(() => ContadorImpares(tokenImpares.Token));
            }
            catch (OperationCanceledException)
            {
                // Hilo cancelado correctamente
            }
            finally
            {
                imparesEjecutandose = false;
                if (!IsDisposed)
                {
                    Invoke(new Action(() =>
                    {
                        btnIniciarImpares.Enabled = true;
                        btnDetenerImpares.Enabled = false;
                    }));
                }
            }
        }

        private void btnDetenerImpares_Click(object sender, EventArgs e)
        {
            tokenImpares?.Cancel();
        }

        // 🔹 WHILE INFINITO - NÚMEROS PARES
        private void ContadorPares(CancellationToken token)
        {
            int contador = 0;
            
            while (!token.IsCancellationRequested)
            {
                // Actualizar UI desde hilo secundario
                if (!IsDisposed)
                {
                    Invoke(new Action(() => txtPares.Text = contador.ToString()));
                }

                contador += 2; // Incrementar de 2 en 2 (0, 2, 4, 6...)
                
                try
                {
                    Thread.Sleep(500); // Pausa 500ms
                    token.ThrowIfCancellationRequested();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        // 🔹 WHILE INFINITO - NÚMEROS IMPARES  
        private void ContadorImpares(CancellationToken token)
        {
            int contador = 1; // Empezar en 1 (primer impar)
            
            while (!token.IsCancellationRequested)
            {
                // Actualizar UI desde hilo secundario
                if (!IsDisposed)
                {
                    Invoke(new Action(() => txtImpares.Text = contador.ToString()));
                }

                contador += 2; // Incrementar de 2 en 2 (1, 3, 5, 7...)
                
                try
                {
                    Thread.Sleep(750); // Pausa 750ms (diferente velocidad)
                    token.ThrowIfCancellationRequested();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        // 🔹 REINICIAR TODO
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            tokenPares?.Cancel();
            tokenImpares?.Cancel();
            txtPares.Text = "0";
            txtImpares.Text = "1";
        }

        // 🔹 CLEANUP AL CERRAR
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tokenPares?.Cancel();
            tokenImpares?.Cancel();
            base.OnFormClosing(e);
        }
    }
}
```

### **Form1.Designer.cs - Controles**
```csharp
private void InitializeComponent()
{
    this.txtPares = new TextBox();
    this.txtImpares = new TextBox();
    this.btnIniciarPares = new Button();
    this.btnDetenerPares = new Button();
    this.btnIniciarImpares = new Button();
    this.btnDetenerImpares = new Button();
    this.btnReiniciar = new Button();
    this.lblPares = new Label();
    this.lblImpares = new Label();

    // lblPares
    this.lblPares.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
    this.lblPares.Location = new System.Drawing.Point(50, 30);
    this.lblPares.Text = "🔢 Números Pares";

    // txtPares
    this.txtPares.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
    this.txtPares.Location = new System.Drawing.Point(50, 60);
    this.txtPares.Size = new System.Drawing.Size(200, 32);
    this.txtPares.Text = "0";
    this.txtPares.TextAlign = HorizontalAlignment.Center;
    this.txtPares.ReadOnly = true;
    this.txtPares.BackColor = System.Drawing.Color.LightBlue;

    // btnIniciarPares
    this.btnIniciarPares.Location = new System.Drawing.Point(50, 110);
    this.btnIniciarPares.Size = new System.Drawing.Size(90, 30);
    this.btnIniciarPares.Text = "▶️ Iniciar";
    this.btnIniciarPares.Click += this.btnIniciarPares_Click;

    // btnDetenerPares
    this.btnDetenerPares.Location = new System.Drawing.Point(160, 110);
    this.btnDetenerPares.Size = new System.Drawing.Size(90, 30);
    this.btnDetenerPares.Text = "⏹️ Detener";
    this.btnDetenerPares.Enabled = false;
    this.btnDetenerPares.Click += this.btnDetenerPares_Click;

    // lblImpares
    this.lblImpares.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
    this.lblImpares.Location = new System.Drawing.Point(350, 30);
    this.lblImpares.Text = "🔣 Números Impares";

    // txtImpares
    this.txtImpares.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
    this.txtImpares.Location = new System.Drawing.Point(350, 60);
    this.txtImpares.Size = new System.Drawing.Size(200, 32);
    this.txtImpares.Text = "1";
    this.txtImpares.TextAlign = HorizontalAlignment.Center;
    this.txtImpares.ReadOnly = true;
    this.txtImpares.BackColor = System.Drawing.Color.LightGreen;

    // btnIniciarImpares
    this.btnIniciarImpares.Location = new System.Drawing.Point(350, 110);
    this.btnIniciarImpares.Size = new System.Drawing.Size(90, 30);
    this.btnIniciarImpares.Text = "▶️ Iniciar";
    this.btnIniciarImpares.Click += this.btnIniciarImpares_Click;

    // btnDetenerImpares
    this.btnDetenerImpares.Location = new System.Drawing.Point(460, 110);
    this.btnDetenerImpares.Size = new System.Drawing.Size(90, 30);
    this.btnDetenerImpares.Text = "⏹️ Detener";
    this.btnDetenerImpares.Enabled = false;
    this.btnDetenerImpares.Click += this.btnDetenerImpares_Click;

    // btnReiniciar
    this.btnReiniciar.Location = new System.Drawing.Point(225, 170);
    this.btnReiniciar.Size = new System.Drawing.Size(150, 35);
    this.btnReiniciar.Text = "🔄 Reiniciar Todo";
    this.btnReiniciar.Click += this.btnReiniciar_Click;

    // Form1
    this.ClientSize = new System.Drawing.Size(600, 240);
    this.Text = "Ejercicio 3 - Hilos Concurrentes";
    this.Controls.Add(this.lblPares);
    this.Controls.Add(this.txtPares);
    this.Controls.Add(this.btnIniciarPares);
    this.Controls.Add(this.btnDetenerPares);
    this.Controls.Add(this.lblImpares);
    this.Controls.Add(this.txtImpares);
    this.Controls.Add(this.btnIniciarImpares);
    this.Controls.Add(this.btnDetenerImpares);
    this.Controls.Add(this.btnReiniciar);
}
```

---

## 📦 **Program.cs** (Para todos los proyectos)

```csharp
using System;
using System.Windows.Forms;

namespace [NombreDelProyecto]
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
```

---

## 🎯 **RESUMEN DE LOS 3 BOTONES - EJERCICIO 1**

### **🔹 BOTÓN 1: "Crear Objeto"**
**¿Qué hace?**
- Toma los datos del formulario (Nombre, Apellido, Edad)
- Crea un objeto `Persona` en la **memoria** de la computadora
- Es como crear una "cajita" con tus datos adentro

**¿Cómo funciona?**
```csharp
persona = new Persona
{
    Nombre = "Florencia",
    Apellido = "Rossi", 
    Edad = 22
};
```

**¿Qué ves?** 
- MessageBox: "Objeto creado: Florencia Rossi, 22 años..."
- Estado: "✅ Objeto creado en memoria"

---

### **🔹 BOTÓN 2: "Serializar" (GUARDAR)**
**¿Qué hace?**
- Convierte el objeto en **texto JSON**
- Guarda ese texto en un archivo `persona.json`
- Es como **escribir** los datos de la cajita en un papel

**¿Cómo funciona?**
```csharp
string json = JsonConvert.SerializeObject(persona);  // Objeto → Texto
File.WriteAllText("persona.json", json);             // Texto → Archivo
```

**¿Qué ves?**
- MessageBox: "Objeto serializado en: persona.json"
- Estado: "💾 Objeto serializado y guardado"
- **Se crea el archivo** `persona.json` en tu carpeta

**El archivo contiene:**
```json
{
  "Nombre": "Florencia",
  "Apellido": "Rossi",
  "Edad": 22,
  "FechaCreacion": "2025-11-06T15:30:45"
}
```

---

### **🔹 BOTÓN 3: "Deserializar" (LEER/RECUPERAR)**
**¿Qué hace?**
- **Lee** el archivo `persona.json`
- **Convierte** el texto JSON de vuelta en un objeto
- **Restaura** los datos en el formulario
- Es como **leer** el papel y recrear la cajita

**¿Cómo funciona?**
```csharp
string json = File.ReadAllText("persona.json");              // Archivo → Texto
Persona persona = JsonConvert.DeserializeObject<Persona>(json); // Texto → Objeto

// Actualizar formulario con los datos recuperados
txtNombre.Text = persona.Nombre;      // "Florencia"
txtApellido.Text = persona.Apellido;  // "Rossi"  
nudEdad.Value = persona.Edad;         // 22
```

**¿Qué ves?**
- MessageBox: "¡Objeto recuperado! Florencia Rossi, 22 años..."
- Estado: "🔄 Objeto deserializado desde archivo"
- **Los campos del formulario vuelven** a los valores originales

---

## 🎪 **EJEMPLO COMPLETO PASO A PASO:**

### **Situación inicial:**
- Formulario con: Nombre="Ana", Apellido="Garcia", Edad=25

### **1. Crear Objeto:**
- Se crea persona en memoria con Ana Garcia, 25 años
- **Memoria**: [Persona: Ana Garcia, 25]

### **2. Serializar:**
- Se crea archivo `persona.json` con los datos de Ana
- **Archivo**: `{"Nombre":"Ana","Apellido":"Garcia","Edad":25}`

### **3. Cambio los datos del formulario:**
- Escribo: Nombre="Luis", Apellido="Martinez", Edad=30
- **Formulario muestra**: Luis Martinez, 30
- **Pero el archivo sigue teniendo**: Ana Garcia, 25

### **4. Deserializar:**
- Lee el archivo `persona.json`
- **Restaura** el formulario con los datos del archivo
- **Formulario vuelve a mostrar**: Ana Garcia, 25 ¡Los datos originales!

---

## 🔑 **LA CLAVE DEL DESERIALIZAR:**

**Deserializar = "Recuperar datos que guardé antes"**

Es como:
- 💾 Guardar un juego
- 🔄 Cerrar el juego  
- 📱 Abrir el juego otra vez
- ✅ **Cargar la partida guardada**

¡El deserializar es "cargar la partida guardada" de tus datos! 🎮

---

## ⚡ **Conceptos Clave para Recordar**

### **Ejercicio 1 - Serialización**
- **JsonConvert.SerializeObject()** → Objeto a JSON
- **JsonConvert.DeserializeObject<T>()** → JSON a Objeto  
- **File.WriteAllText()** → Guardar archivo
- **File.ReadAllText()** → Leer archivo
- **[Serializable]** → Atributo en la clase
- **Newtonsoft.Json.Formatting.Indented** → JSON con formato legible

### **Ejercicio 2 - Clonación**
- **Superficial**: Copia referencias (problemas compartidos)
- **Profunda**: Crea nuevos objetos (independientes)
- **new Persona { ... }** → Constructor de objetos
- **this.Jefe?.Propiedad** → Null conditional operator

### **Ejercicio 3 - Hilos**
- **Task.Run()** → Ejecutar en hilo secundario
- **CancellationTokenSource** → Controlar cancelación
- **Invoke()** → Actualizar UI desde otro hilo
- **Thread.Sleep()** → Pausar ejecución
- **async/await** → Programación asíncrona

---

## 🚨 **Errores Comunes a Evitar**

1. **No usar Invoke()** para actualizar UI desde hilos → CrossThreadException
2. **No validar objetos null** antes de usar → NullReferenceException  
3. **No cancelar hilos** al cerrar → Memory leaks
4. **Olvidar [Serializable]** → Problemas de serialización
5. **Confundir clonación superficial con profunda** → Referencias compartidas
6. **No instalar Newtonsoft.Json** → Errores de compilación
7. **Usar System.Text.Json en .NET Framework** → No existe
8. **Usar solo 'Formatting'** → Referencia ambigua (usar namespace completo)

---

## ✅ **Checklist Final**

### **Ejercicio 1**
- [ ] **Instalar Newtonsoft.Json** (NuGet Package)
- [ ] Clase Persona con [Serializable]
- [ ] **using Newtonsoft.Json;** agregado
- [ ] 3 botones funcionales
- [ ] **JsonConvert.SerializeObject()** y **DeserializeObject()**
- [ ] Manejo de excepciones
- [ ] Validación de objetos null
- [ ] Archivo JSON generado correctamente

### **Ejercicio 2**  
- [ ] Clase Persona con propiedad Jefe
- [ ] Método ClonarProfundo()
- [ ] Demostración práctica paso a paso
- [ ] Comparación superficial vs profunda
- [ ] Interface clara y botones descriptivos

### **Ejercicio 3**
- [ ] Dos hilos independientes
- [ ] Botones individuales para cada contador
- [ ] Actualización simultánea de TextBox
- [ ] CancellationToken para control
- [ ] Cleanup al cerrar formulario
- [ ] Invoke() para thread safety

---

## 🎯 **Resumen Ejecutivo**

| Ejercicio | Concepto | Persistencia | Complejidad | Tiempo Est. |
|-----------|----------|--------------|-------------|-------------|
| **1** | Serialización JSON | ✅ Archivo | Baja | 30 min |
| **2** | Clonación Profunda | ❌ Memoria | Media | 45 min |  
| **3** | Hilos Concurrentes | ❌ Tiempo Real | Alta | 60 min |

### **🏆 Estrategia de Parcial:**
1. **Empezar por Ejercicio 1** (más simple)
2. **Seguir con Ejercicio 2** (lógica intermedia) 
3. **Terminar con Ejercicio 3** (más complejo)
4. **Probar cada ejercicio** antes de continuar
5. **Documentar problemas** encontrados

---

## 🔧 **Solución de Errores Comunes**

### **Error: 'JsonSerializer' no existe**
**Causa**: Estás en .NET Framework, no tiene System.Text.Json  
**Solución**: Usar Newtonsoft.Json (ya instalado)

### **Error: 'File' no existe**
**Causa**: Falta using System.IO  
**Solución**: Agregar `using System.IO;`

### **Error: 'Persona' no se encontró**
**Causa**: Clase no definida o namespace incorrecto  
**Solución**: Verificar que la clase Persona esté en el mismo proyecto

### **Error: Versión de .NET**
**Causa**: Incompatibilidad de versiones  
**Solución**: Usar .NET Framework 4.7.2 con Newtonsoft.Json

### **Error: 'Formatting' es una referencia ambigua**
**Causa**: Conflicto entre Newtonsoft.Json.Formatting y System.Xml.Formatting  
**Solución**: Usar `Newtonsoft.Json.Formatting.Indented` (namespace completo)

---

**¡Éxito en el parcial! 🚀**