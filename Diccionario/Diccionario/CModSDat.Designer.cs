﻿namespace Diccionario
{
    partial class CModSDat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bGuardar = new System.Windows.Forms.Button();
            this.dgvIngreDat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreDat)).BeginInit();
            this.SuspendLayout();
            // 
            // bGuardar
            // 
            this.bGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bGuardar.Enabled = false;
            this.bGuardar.Location = new System.Drawing.Point(426, 44);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(75, 23);
            this.bGuardar.TabIndex = 3;
            this.bGuardar.Text = "Guardar";
            this.bGuardar.UseVisualStyleBackColor = true;
            this.bGuardar.Click += new System.EventHandler(this.bGuardar_Click);
            // 
            // dgvIngreDat
            // 
            this.dgvIngreDat.AllowUserToAddRows = false;
            this.dgvIngreDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngreDat.Location = new System.Drawing.Point(12, 73);
            this.dgvIngreDat.Name = "dgvIngreDat";
            this.dgvIngreDat.Size = new System.Drawing.Size(493, 150);
            this.dgvIngreDat.TabIndex = 2;
            this.dgvIngreDat.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngreDat_CellValueChanged);
            // 
            // CModSDat
            // 
            this.AcceptButton = this.bGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 234);
            this.Controls.Add(this.bGuardar);
            this.Controls.Add(this.dgvIngreDat);
            this.Name = "CModSDat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CModSDat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CModSDat_FormClosing);
            this.Load += new System.EventHandler(this.CModSDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreDat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bGuardar;
        public System.Windows.Forms.DataGridView dgvIngreDat;
    }
}