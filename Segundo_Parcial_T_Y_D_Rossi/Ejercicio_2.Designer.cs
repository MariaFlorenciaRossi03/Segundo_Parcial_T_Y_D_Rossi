namespace Segundo_Parcial_T_Y_D_Rossi
{
    partial class Ejercicio_2
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrearEscenario = new System.Windows.Forms.Button();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.btnClonacionSuperficial = new System.Windows.Forms.Button();
            this.btnClonacionProfunda = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCrearEscenario
            // 
            this.btnCrearEscenario.BackColor = System.Drawing.Color.Plum;
            this.btnCrearEscenario.Location = new System.Drawing.Point(501, 77);
            this.btnCrearEscenario.Name = "btnCrearEscenario";
            this.btnCrearEscenario.Size = new System.Drawing.Size(143, 23);
            this.btnCrearEscenario.TabIndex = 0;
            this.btnCrearEscenario.Text = "CrearEscenario";
            this.btnCrearEscenario.UseVisualStyleBackColor = false;
            this.btnCrearEscenario.Click += new System.EventHandler(this.btnCrearEscenario_Click);
            // 
            // txtResultados
            // 
            this.txtResultados.Location = new System.Drawing.Point(35, 77);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultados.Size = new System.Drawing.Size(450, 244);
            this.txtResultados.TabIndex = 1;
            // 
            // btnClonacionSuperficial
            // 
            this.btnClonacionSuperficial.BackColor = System.Drawing.Color.Plum;
            this.btnClonacionSuperficial.Location = new System.Drawing.Point(501, 125);
            this.btnClonacionSuperficial.Name = "btnClonacionSuperficial";
            this.btnClonacionSuperficial.Size = new System.Drawing.Size(143, 23);
            this.btnClonacionSuperficial.TabIndex = 2;
            this.btnClonacionSuperficial.Text = "Clonacion Superficial";
            this.btnClonacionSuperficial.UseVisualStyleBackColor = false;
            this.btnClonacionSuperficial.Click += new System.EventHandler(this.btnClonacionSuperficial_Click);
            // 
            // btnClonacionProfunda
            // 
            this.btnClonacionProfunda.BackColor = System.Drawing.Color.Plum;
            this.btnClonacionProfunda.Location = new System.Drawing.Point(501, 177);
            this.btnClonacionProfunda.Name = "btnClonacionProfunda";
            this.btnClonacionProfunda.Size = new System.Drawing.Size(143, 23);
            this.btnClonacionProfunda.TabIndex = 3;
            this.btnClonacionProfunda.Text = "Clonacion Profunda";
            this.btnClonacionProfunda.UseVisualStyleBackColor = false;
            this.btnClonacionProfunda.Click += new System.EventHandler(this.btnClonacionProfunda_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Plum;
            this.button1.Location = new System.Drawing.Point(501, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Plum;
            this.button2.Location = new System.Drawing.Point(641, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Zilla Slab", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label4.Location = new System.Drawing.Point(38, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 38);
            this.label4.TabIndex = 71;
            this.label4.Text = "Ejercicio 2";
            // 
            // Ejercicio_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(775, 373);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClonacionProfunda);
            this.Controls.Add(this.btnClonacionSuperficial);
            this.Controls.Add(this.txtResultados);
            this.Controls.Add(this.btnCrearEscenario);
            this.Name = "Ejercicio_2";
            this.Text = "Ejercicio 2";
            this.Load += new System.EventHandler(this.Ejercicio_2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearEscenario;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.Button btnClonacionSuperficial;
        private System.Windows.Forms.Button btnClonacionProfunda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}

