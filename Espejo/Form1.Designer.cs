﻿namespace Espejo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txEntrada = new System.Windows.Forms.TextBox();
            this.btCrearArchivo = new System.Windows.Forms.Button();
            this.txEspejo = new System.Windows.Forms.TextBox();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.btEscribir = new System.Windows.Forms.Button();
            this.chActualizar = new System.Windows.Forms.CheckBox();
            this.txLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txEntrada
            // 
            this.txEntrada.Location = new System.Drawing.Point(12, 31);
            this.txEntrada.MaxLength = 100;
            this.txEntrada.Multiline = true;
            this.txEntrada.Name = "txEntrada";
            this.txEntrada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txEntrada.Size = new System.Drawing.Size(296, 222);
            this.txEntrada.TabIndex = 0;
            // 
            // btCrearArchivo
            // 
            this.btCrearArchivo.Location = new System.Drawing.Point(314, 31);
            this.btCrearArchivo.Name = "btCrearArchivo";
            this.btCrearArchivo.Size = new System.Drawing.Size(111, 34);
            this.btCrearArchivo.TabIndex = 1;
            this.btCrearArchivo.Text = "Crear memoria";
            this.btCrearArchivo.UseVisualStyleBackColor = true;
            this.btCrearArchivo.Click += new System.EventHandler(this.btCrearArchivo_Click);
            // 
            // txEspejo
            // 
            this.txEspejo.Location = new System.Drawing.Point(431, 31);
            this.txEspejo.Multiline = true;
            this.txEspejo.Name = "txEspejo";
            this.txEspejo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txEspejo.Size = new System.Drawing.Size(296, 222);
            this.txEspejo.TabIndex = 4;
            // 
            // reloj
            // 
            this.reloj.Interval = 1;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // btEscribir
            // 
            this.btEscribir.Location = new System.Drawing.Point(314, 71);
            this.btEscribir.Name = "btEscribir";
            this.btEscribir.Size = new System.Drawing.Size(111, 34);
            this.btEscribir.TabIndex = 2;
            this.btEscribir.Text = "Escribir en memoria";
            this.btEscribir.UseVisualStyleBackColor = true;
            this.btEscribir.Click += new System.EventHandler(this.btEscribir_Click);
            // 
            // chActualizar
            // 
            this.chActualizar.AutoSize = true;
            this.chActualizar.Location = new System.Drawing.Point(431, 8);
            this.chActualizar.Name = "chActualizar";
            this.chActualizar.Size = new System.Drawing.Size(107, 17);
            this.chActualizar.TabIndex = 3;
            this.chActualizar.Text = "Actualizar Espejo";
            this.chActualizar.UseVisualStyleBackColor = true;
            this.chActualizar.CheckedChanged += new System.EventHandler(this.chActualizar_CheckedChanged);
            // 
            // txLog
            // 
            this.txLog.Location = new System.Drawing.Point(12, 259);
            this.txLog.Multiline = true;
            this.txLog.Name = "txLog";
            this.txLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txLog.Size = new System.Drawing.Size(715, 159);
            this.txLog.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 427);
            this.Controls.Add(this.txLog);
            this.Controls.Add(this.chActualizar);
            this.Controls.Add(this.btEscribir);
            this.Controls.Add(this.btCrearArchivo);
            this.Controls.Add(this.txEspejo);
            this.Controls.Add(this.txEntrada);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Espejo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txEntrada;
        private System.Windows.Forms.Button btCrearArchivo;
        private System.Windows.Forms.TextBox txEspejo;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Button btEscribir;
        private System.Windows.Forms.CheckBox chActualizar;
        private System.Windows.Forms.TextBox txLog;
    }
}

