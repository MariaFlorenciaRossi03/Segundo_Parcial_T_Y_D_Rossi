namespace Ejercicio_3
{
    partial class Ejercicio_3
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
            this.btnIniciarPares = new System.Windows.Forms.Button();
            this.btnDetenerPares = new System.Windows.Forms.Button();
            this.btnIniciarImpares = new System.Windows.Forms.Button();
            this.btnDetenerImpares = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.txtPares = new System.Windows.Forms.TextBox();
            this.txtImpares = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciarPares
            // 
            this.btnIniciarPares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIniciarPares.Location = new System.Drawing.Point(169, 19);
            this.btnIniciarPares.Name = "btnIniciarPares";
            this.btnIniciarPares.Size = new System.Drawing.Size(119, 23);
            this.btnIniciarPares.TabIndex = 14;
            this.btnIniciarPares.Text = "Iniciar Pares";
            this.btnIniciarPares.UseVisualStyleBackColor = false;
            this.btnIniciarPares.Click += new System.EventHandler(this.btnIniciarPares_Click);
            // 
            // btnDetenerPares
            // 
            this.btnDetenerPares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDetenerPares.Location = new System.Drawing.Point(169, 70);
            this.btnDetenerPares.Name = "btnDetenerPares";
            this.btnDetenerPares.Size = new System.Drawing.Size(119, 23);
            this.btnDetenerPares.TabIndex = 15;
            this.btnDetenerPares.Text = "Detener Pares";
            this.btnDetenerPares.UseVisualStyleBackColor = false;
            this.btnDetenerPares.Click += new System.EventHandler(this.btnDetenerPares_Click);
            // 
            // btnIniciarImpares
            // 
            this.btnIniciarImpares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnIniciarImpares.Location = new System.Drawing.Point(185, 19);
            this.btnIniciarImpares.Name = "btnIniciarImpares";
            this.btnIniciarImpares.Size = new System.Drawing.Size(105, 23);
            this.btnIniciarImpares.TabIndex = 16;
            this.btnIniciarImpares.Text = "Iniciar Impares";
            this.btnIniciarImpares.UseVisualStyleBackColor = false;
            this.btnIniciarImpares.Click += new System.EventHandler(this.btnIniciarImpares_Click);
            // 
            // btnDetenerImpares
            // 
            this.btnDetenerImpares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDetenerImpares.Location = new System.Drawing.Point(185, 60);
            this.btnDetenerImpares.Name = "btnDetenerImpares";
            this.btnDetenerImpares.Size = new System.Drawing.Size(105, 23);
            this.btnDetenerImpares.TabIndex = 17;
            this.btnDetenerImpares.Text = "Detener Impares";
            this.btnDetenerImpares.UseVisualStyleBackColor = false;
            this.btnDetenerImpares.Click += new System.EventHandler(this.btnDetenerImpares_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReiniciar.Location = new System.Drawing.Point(12, 259);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(685, 23);
            this.btnReiniciar.TabIndex = 18;
            this.btnReiniciar.Text = "Reiniciar Todo";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // txtPares
            // 
            this.txtPares.Location = new System.Drawing.Point(18, 27);
            this.txtPares.Multiline = true;
            this.txtPares.Name = "txtPares";
            this.txtPares.Size = new System.Drawing.Size(100, 66);
            this.txtPares.TabIndex = 19;
            // 
            // txtImpares
            // 
            this.txtImpares.Location = new System.Drawing.Point(30, 22);
            this.txtImpares.Multiline = true;
            this.txtImpares.Name = "txtImpares";
            this.txtImpares.Size = new System.Drawing.Size(104, 61);
            this.txtImpares.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPares);
            this.groupBox1.Controls.Add(this.btnIniciarPares);
            this.groupBox1.Controls.Add(this.btnDetenerPares);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 149);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NUEMEROS PARES";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIniciarImpares);
            this.groupBox2.Controls.Add(this.btnDetenerImpares);
            this.groupBox2.Controls.Add(this.txtImpares);
            this.groupBox2.Location = new System.Drawing.Point(374, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 139);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NUMEROS IMPARES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Zilla Slab", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label4.Location = new System.Drawing.Point(23, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 38);
            this.label4.TabIndex = 72;
            this.label4.Text = "Ejercicio 3";
            // 
            // Ejercicio_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(712, 319);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReiniciar);
            this.Name = "Ejercicio_3";
            this.Text = "Ejercicio 3";
            this.Load += new System.EventHandler(this.Ejercicio_3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIniciarPares;
        private System.Windows.Forms.Button btnDetenerPares;
        private System.Windows.Forms.Button btnIniciarImpares;
        private System.Windows.Forms.Button btnDetenerImpares;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.TextBox txtPares;
        private System.Windows.Forms.TextBox txtImpares;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
    }
}

