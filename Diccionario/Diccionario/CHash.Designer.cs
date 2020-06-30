namespace Diccionario
{
    partial class CHash
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvIS = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.dgvES = new System.Windows.Forms.DataGridView();
            this.EntidadS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptEntidadS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptAtributoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptDatosS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bModificaDato = new System.Windows.Forms.Button();
            this.bBajaDato = new System.Windows.Forms.Button();
            this.bAltaDato = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvITS = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvITS)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Tabla";
            // 
            // dgvIS
            // 
            this.dgvIS.AllowUserToAddRows = false;
            this.dgvIS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIS.Location = new System.Drawing.Point(199, 284);
            this.dgvIS.Name = "dgvIS";
            this.dgvIS.Size = new System.Drawing.Size(352, 130);
            this.dgvIS.TabIndex = 34;
            this.dgvIS.SelectionChanged += new System.EventHandler(this.dgvIS_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Entidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 29;
            this.label1.Text = "Datos";
            // 
            // dgvDS
            // 
            this.dgvDS.AllowUserToAddRows = false;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Location = new System.Drawing.Point(6, 442);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(545, 130);
            this.dgvDS.TabIndex = 28;
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
            this.dgvES.Location = new System.Drawing.Point(6, 103);
            this.dgvES.Name = "dgvES";
            this.dgvES.Size = new System.Drawing.Size(545, 150);
            this.dgvES.TabIndex = 27;
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
            // bModificaDato
            // 
            this.bModificaDato.Image = global::Diccionario.Properties.Resources.ModificarAtributo;
            this.bModificaDato.Location = new System.Drawing.Point(368, 20);
            this.bModificaDato.Name = "bModificaDato";
            this.bModificaDato.Size = new System.Drawing.Size(72, 78);
            this.bModificaDato.TabIndex = 33;
            this.bModificaDato.UseVisualStyleBackColor = true;
            this.bModificaDato.Click += new System.EventHandler(this.bModificaDato_Click);
            // 
            // bBajaDato
            // 
            this.bBajaDato.Image = global::Diccionario.Properties.Resources.BajaAtributo;
            this.bBajaDato.Location = new System.Drawing.Point(290, 19);
            this.bBajaDato.Name = "bBajaDato";
            this.bBajaDato.Size = new System.Drawing.Size(72, 78);
            this.bBajaDato.TabIndex = 32;
            this.bBajaDato.UseVisualStyleBackColor = true;
            this.bBajaDato.Click += new System.EventHandler(this.bBajaDato_Click);
            // 
            // bAltaDato
            // 
            this.bAltaDato.Image = global::Diccionario.Properties.Resources.AltaAtributo;
            this.bAltaDato.Location = new System.Drawing.Point(212, 19);
            this.bAltaDato.Name = "bAltaDato";
            this.bAltaDato.Size = new System.Drawing.Size(72, 78);
            this.bAltaDato.TabIndex = 31;
            this.bAltaDato.UseVisualStyleBackColor = true;
            this.bAltaDato.Click += new System.EventHandler(this.bAltaDato_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "Cubetas";
            // 
            // dgvITS
            // 
            this.dgvITS.AllowUserToAddRows = false;
            this.dgvITS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvITS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvITS.Location = new System.Drawing.Point(12, 284);
            this.dgvITS.Name = "dgvITS";
            this.dgvITS.Size = new System.Drawing.Size(166, 130);
            this.dgvITS.TabIndex = 36;
            this.dgvITS.SelectionChanged += new System.EventHandler(this.dgvITS_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Hash Tabla";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // CHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 591);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvITS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvIS);
            this.Controls.Add(this.bModificaDato);
            this.Controls.Add(this.bBajaDato);
            this.Controls.Add(this.bAltaDato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDS);
            this.Controls.Add(this.dgvES);
            this.Name = "CHash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHash";
            this.Load += new System.EventHandler(this.CHash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvITS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvIS;
        private System.Windows.Forms.Button bModificaDato;
        private System.Windows.Forms.Button bBajaDato;
        private System.Windows.Forms.Button bAltaDato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.DataGridView dgvES;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptEntidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptAtributoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptDatosS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvITS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}