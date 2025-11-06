using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_3
{
    public partial class Ejercicio_3 : Form
    {
        private CancellationTokenSource tokenPares;
        private CancellationTokenSource tokenImpares;
        private bool paresEjecutandose = false;
        private bool imparesEjecutandose = false;
        public Ejercicio_3()
        {
            InitializeComponent();
        }

        private void Ejercicio_3_Load(object sender, EventArgs e)
        {

        }

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

        //whileeee paresssss//
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

        // WHILE INFINITO - NÚMEROS IMPARES  
        private void ContadorImpares(CancellationToken token)
        {
            int contador = 1; 

            while (!token.IsCancellationRequested)
            {
              
                if (!IsDisposed)
                {
                    Invoke(new Action(() => txtImpares.Text = contador.ToString()));
                }

                contador += 2; 

                try
                {
                    Thread.Sleep(750); 
                    token.ThrowIfCancellationRequested();
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            tokenPares?.Cancel();
            tokenImpares?.Cancel();
            txtPares.Text = "0";
            txtImpares.Text = "1";
        }

        // CLEANUP AL CERRAR
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tokenPares?.Cancel();
            tokenImpares?.Cancel();
            base.OnFormClosing(e);
        }

    }
}
