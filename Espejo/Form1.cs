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
        //Archivo en memoria
        MemoryMappedFile memoria;
        
        //Mutex para acceso concurrido
        Mutex _mutex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCrearArchivo_Click(object sender, EventArgs e)
        {
            try {
                //Abrir archivo
                memoria = MemoryMappedFile.CreateOrOpen("testmap", 10000);
                btCrearArchivo.Enabled = false;
                txLog.Text += "Archivo abierto o creado." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                txLog.Text += "ERROR al intentar crear o abrir el archivo: " + ex.Message + Environment.NewLine;
            }
        }

        private void chActualizar_CheckedChanged(object sender, EventArgs e)
        {
            reloj.Enabled = !reloj.Enabled;
        }

        private void btEscribir_Click(object sender, EventArgs e)
        {
            try {
                Byte[] buffer = Encoding.ASCII.GetBytes(txEntrada.Text);

                _mutex.WaitOne();

                using (MemoryMappedViewStream stream = memoria.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(buffer);
                }
                _mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                txLog.Text += "ERROR al intentar escribir en la memoria: " + ex.Message + Environment.NewLine;
            }
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            try
            {
                _mutex.WaitOne();

                byte[] cadena = new byte[100];
                using (MemoryMappedViewStream stream = memoria.CreateViewStream())
                {
                    BinaryReader reader = new BinaryReader(stream);

                    //Leer bytes
                    stream.Read(cadena, 0, 100);

                    //Escribir en textbox
                    txEspejo.Text = ASCIIEncoding.ASCII.GetString(cadena);

                }
                _mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                txLog.Text += "ERROR al intentar leer la memoria: " + ex.Message + Environment.NewLine;
            }
        }

        private void btCrearMutex_Click(object sender, EventArgs e)
        {
            //Intentar crear o unirse a uno previamente creado
            try
            {
                // Try to open existing mutex.
                _mutex = Mutex.OpenExisting("testmapmutex");
                txLog.Text += "Se abrió un Mutex existente." + Environment.NewLine;
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                _mutex = new Mutex(false, "testmapmutex");
                txLog.Text += "No se encontró un Mutex existente, se creó uno." + Environment.NewLine;
            }
        }

        private void btLiberarMutex_Click(object sender, EventArgs e)
        {

        }
    }
}
