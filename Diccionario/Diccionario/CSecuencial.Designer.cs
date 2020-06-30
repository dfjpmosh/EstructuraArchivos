namespace Diccionario
{
    partial class CSecuencial
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
            this.dgvES = new System.Windows.Forms.DataGridView();
            this.EntidadS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptEntidadS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptAtributoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptDatosS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bGuardar = new System.Windows.Forms.Button();
            this.bBajaDato = new System.Windows.Forms.Button();
            this.bModificaDato = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvES
            // 
            this.dgvES.AllowUserToAddRows = false;
            this.dgvES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntidadS,
            this.DireccionS,
            this.AptEntidadS,
            this.AptAtributoS,
            this.AptDatosS});
            this.dgvES.Location = new System.Drawing.Point(12, 95);
            this.dgvES.Name = "dgvES";
            this.dgvES.Size = new System.Drawing.Size(545, 190);
            this.dgvES.TabIndex = 4;
            this.dgvES.SelectionChanged += new System.EventHandler(this.dgvES_SelectionChanged);
            // 
            // EntidadS
            // 
            this.EntidadS.HeaderText = "Entidad";
            this.EntidadS.Name = "EntidadS";
            // 
            // DireccionS
            // 
            this.DireccionS.HeaderText = "Direccion";
            this.DireccionS.Name = "DireccionS";
            // 
            // AptEntidadS
            // 
            this.AptEntidadS.HeaderText = "AptEntidad";
            this.AptEntidadS.Name = "AptEntidadS";
            // 
            // AptAtributoS
            // 
            this.AptAtributoS.HeaderText = "AptAtributo";
            this.AptAtributoS.Name = "AptAtributoS";
            // 
            // AptDatosS
            // 
            this.AptDatosS.HeaderText = "AptDatos";
            this.AptDatosS.Name = "AptDatosS";
            // 
            // dgvDS
            // 
            this.dgvDS.AllowUserToAddRows = false;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Location = new System.Drawing.Point(12, 330);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(545, 190);
            this.dgvDS.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Entidades";
            // 
            // bGuardar
            // 
            this.bGuardar.Image = global::Diccionario.Properties.Resources.AltaAtributo;
            this.bGuardar.Location = new System.Drawing.Point(218, 11);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(72, 78);
            this.bGuardar.TabIndex = 14;
            this.bGuardar.UseVisualStyleBackColor = true;
            this.bGuardar.Click += new System.EventHandler(this.bGuardar_Click);
            // 
            // bBajaDato
            // 
            this.bBajaDato.Image = global::Diccionario.Properties.Resources.BajaAtributo;
            this.bBajaDato.Location = new System.Drawing.Point(296, 11);
            this.bBajaDato.Name = "bBajaDato";
            this.bBajaDato.Size = new System.Drawing.Size(72, 78);
            this.bBajaDato.TabIndex = 15;
            this.bBajaDato.UseVisualStyleBackColor = true;
            this.bBajaDato.Click += new System.EventHandler(this.bBajaDato_Click);
            // 
            // bModificaDato
            // 
            this.bModificaDato.Image = global::Diccionario.Properties.Resources.ModificarAtributo;
            this.bModificaDato.Location = new System.Drawing.Point(374, 12);
            this.bModificaDato.Name = "bModificaDato";
            this.bModificaDato.Size = new System.Drawing.Size(72, 78);
            this.bModificaDato.TabIndex = 16;
            this.bModificaDato.UseVisualStyleBackColor = true;
            this.bModificaDato.Click += new System.EventHandler(this.bModificaDato_Click);
            // 
            // CSecuencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 532);
            this.Controls.Add(this.bModificaDato);
            this.Controls.Add(this.bBajaDato);
            this.Controls.Add(this.bGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDS);
            this.Controls.Add(this.dgvES);
            this.Name = "CSecuencial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSecuencial";
            this.Load += new System.EventHandler(this.CSecuencial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvES;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptEntidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptAtributoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptDatosS;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Button bBajaDato;
        private System.Windows.Forms.Button bModificaDato;
    }
}