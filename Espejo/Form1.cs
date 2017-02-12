using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Espejo
{
    public partial class Form1 : Form
    {
        //Memoria compartida
        MemoriaCompartida _memoriaCompartida;

        public Form1()
        {
            InitializeComponent();
        }

        private void btCrearArchivo_Click(object sender, EventArgs e)
        {
            String log = string.Empty;

            _memoriaCompartida = new MemoriaCompartida("EspejoMem", "EspejoMutex", 100);
            _memoriaCompartida.IniciarConexion(ref log);

            //Log
            txLog.Text += log + Environment.NewLine;
        }

        private void chActualizar_CheckedChanged(object sender, EventArgs e)
        {
            reloj.Enabled = !reloj.Enabled;
        }

        private void btEscribir_Click(object sender, EventArgs e)
        {
            String log = string.Empty;

            _memoriaCompartida.EscribirEnMemoria(txEntrada.Text, ref log);

            //Log
            txLog.Text += log + Environment.NewLine;
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            String log = string.Empty;
            String cadena;

            _memoriaCompartida.LeerEnMemoria(out cadena, true, ref log);

            txEspejo.Text = cadena;

            //Log
            txLog.Text += log + Environment.NewLine;
        }
    }
}
