namespace Diccionario
{
    partial class CMultillave
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
            this.bGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptAtributoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptEntidadA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Entidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Datos";
            // 
            // dgvDS
            // 
            this.dgvDS.AllowUserToAddRows = false;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Location = new System.Drawing.Point(12, 444);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(545, 131);
            this.dgvDS.TabIndex = 18;
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
            this.dgvES.Location = new System.Drawing.Point(12, 93);
            this.dgvES.Name = "dgvES";
            this.dgvES.Size = new System.Drawing.Size(545, 145);
            this.dgvES.TabIndex = 17;
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
            this.bModificaDato.Location = new System.Drawing.Point(374, 10);
            this.bModificaDato.Name = "bModificaDato";
            this.bModificaDato.Size = new System.Drawing.Size(72, 78);
            this.bModificaDato.TabIndex = 23;
            this.bModificaDato.UseVisualStyleBackColor = true;
            this.bModificaDato.Click += new System.EventHandler(this.bModificaDato_Click);
            // 
            // bBajaDato
            // 
            this.bBajaDato.Image = global::Diccionario.Properties.Resources.BajaAtributo;
            this.bBajaDato.Location = new System.Drawing.Point(296, 9);
            this.bBajaDato.Name = "bBajaDato";
            this.bBajaDato.Size = new System.Drawing.Size(72, 78);
            this.bBajaDato.TabIndex = 22;
            this.bBajaDato.UseVisualStyleBackColor = true;
            this.bBajaDato.Click += new System.EventHandler(this.bBajaDato_Click);
            // 
            // bGuardar
            // 
            this.bGuardar.Image = global::Diccionario.Properties.Resources.AltaAtributo;
            this.bGuardar.Location = new System.Drawing.Point(218, 9);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(72, 78);
            this.bGuardar.TabIndex = 21;
            this.bGuardar.UseVisualStyleBackColor = true;
            this.bGuardar.Click += new System.EventHandler(this.bGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 25;
            this.label3.Text = "Atributos";
            // 
            // dgvA
            // 
            this.dgvA.AllowUserToAddRows = false;
            this.dgvA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DireccionA,
            this.AptAtributoA,
            this.AptEntidadA,
            this.TipoClave});
            this.dgvA.Location = new System.Drawing.Point(12, 268);
            this.dgvA.Name = "dgvA";
            this.dgvA.Size = new System.Drawing.Size(545, 144);
            this.dgvA.TabIndex = 24;
            this.dgvA.SelectionChanged += new System.EventHandler(this.dgvA_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Atributo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // DireccionA
            // 
            this.DireccionA.HeaderText = "Direccion";
            this.DireccionA.Name = "DireccionA";
            // 
            // AptAtributoA
            // 
            this.AptAtributoA.HeaderText = "AptAtributo";
            this.AptAtributoA.Name = "AptAtributoA";
            // 
            // AptEntidadA
            // 
            this.AptEntidadA.HeaderText = "AptEntidad";
            this.AptEntidadA.Name = "AptEntidadA";
            // 
            // TipoClave
            // 
            this.TipoClave.HeaderText = "Tipo Clave";
            this.TipoClave.Name = "TipoClave";
            // 
            // CMultillave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 587);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.bModificaDato);
            this.Controls.Add(this.bBajaDato);
            this.Controls.Add(this.bGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDS);
            this.Controls.Add(this.dgvES);
            this.Name = "CMultillave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMultillave";
            this.Load += new System.EventHandler(this.CMultillave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bModificaDato;
        private System.Windows.Forms.Button bBajaDato;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.DataGridView dgvES;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptEntidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptAtributoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptDatosS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptAtributoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptEntidadA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoClave;
    }
}