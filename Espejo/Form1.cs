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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCrearArchivo_Click(object sender, EventArgs e)
        {
            //Abrir archivo
            memoria = MemoryMappedFile.CreateNew("testmap", 10000);
            btCrearArchivo.Enabled = false;
        }

        private void chActualizar_CheckedChanged(object sender, EventArgs e)
        {
            reloj.Enabled = !reloj.Enabled;
        }

        private void btEscribir_Click(object sender, EventArgs e)
        {
            Byte[] buffer = Encoding.ASCII.GetBytes(txEntrada.Text);

            bool mutexCreated;
            Mutex mutex = new Mutex(true, "testmapmutex", out mutexCreated);

            mutex.WaitOne();

            using (MemoryMappedViewStream stream = memoria.CreateViewStream())
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(buffer);
            }
            mutex.ReleaseMutex();
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            bool mutexCreated;
            Mutex mutex = new Mutex(true, "testmapmutex", out mutexCreated);

            mutex.WaitOne();

            byte[] cadena = new byte[100];
            using (MemoryMappedViewStream stream = memoria.CreateViewStream())
            {
                BinaryReader reader = new BinaryReader(stream);

                //Leer bytes
                stream.Read(cadena, 0, 100);

                //Escribir en textbox
                txEspejo.Text = ASCIIEncoding.ASCII.GetString(cadena);

            }
            mutex.ReleaseMutex();
        }
    }
}
