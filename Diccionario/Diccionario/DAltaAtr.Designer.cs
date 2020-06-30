namespace Diccionario
{
    partial class DAltaAtr
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
            this.cbEntSel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbClaveExt = new System.Windows.Forms.RadioButton();
            this.rbClavePrim = new System.Windows.Forms.RadioButton();
            this.cbEntExt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbClaveNin = new System.Windows.Forms.RadioButton();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.tbTam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbEntSel
            // 
            this.cbEntSel.Enabled = false;
            this.cbEntSel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntSel.FormattingEnabled = true;
            this.cbEntSel.Location = new System.Drawing.Point(112, 15);
            this.cbEntSel.Name = "cbEntSel";
            this.cbEntSel.Size = new System.Drawing.Size(159, 27);
            this.cbEntSel.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Entidad:";
            // 
            // tbNom
            // 
            this.tbNom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNom.Location = new System.Drawing.Point(112, 48);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(159, 26);
            this.tbNom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(112, 80);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(159, 27);
            this.cbTipo.TabIndex = 17;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tipo:";
            // 
            // rbClaveExt
            // 
            this.rbClaveExt.AutoSize = true;
            this.rbClaveExt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbClaveExt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClaveExt.Location = new System.Drawing.Point(21, 150);
            this.rbClaveExt.Name = "rbClaveExt";
            this.rbClaveExt.Size = new System.Drawing.Size(123, 23);
            this.rbClaveExt.TabIndex = 23;
            this.rbClaveExt.TabStop = true;
            this.rbClaveExt.Text = "Clave Externa";
            this.rbClaveExt.UseVisualStyleBackColor = true;
            this.rbClaveExt.CheckedChanged += new System.EventHandler(this.rbClaveExt_CheckedChanged);
            // 
            // rbClavePrim
            // 
            this.rbClavePrim.AutoSize = true;
            this.rbClavePrim.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbClavePrim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClavePrim.Location = new System.Drawing.Point(17, 120);
            this.rbClavePrim.Name = "rbClavePrim";
            this.rbClavePrim.Size = new System.Drawing.Size(127, 23);
            this.rbClavePrim.TabIndex = 22;
            this.rbClavePrim.TabStop = true;
            this.rbClavePrim.Text = "Clave Primaria";
            this.rbClavePrim.UseVisualStyleBackColor = true;
            this.rbClavePrim.CheckedChanged += new System.EventHandler(this.rbClavePrim_CheckedChanged);
            // 
            // cbEntExt
            // 
            this.cbEntExt.Enabled = false;
            this.cbEntExt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntExt.FormattingEnabled = true;
            this.cbEntExt.Location = new System.Drawing.Point(150, 168);
            this.cbEntExt.Name = "cbEntExt";
            this.cbEntExt.Size = new System.Drawing.Size(121, 27);
            this.cbEntExt.TabIndex = 25;
            this.cbEntExt.SelectedIndexChanged += new System.EventHandler(this.cbEntExt_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(172, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 24;
            this.label4.Text = "Entidad:";
            // 
            // rbClaveNin
            // 
            this.rbClaveNin.AutoSize = true;
            this.rbClaveNin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbClaveNin.Checked = true;
            this.rbClaveNin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClaveNin.Location = new System.Drawing.Point(18, 179);
            this.rbClaveNin.Name = "rbClaveNin";
            this.rbClaveNin.Size = new System.Drawing.Size(126, 23);
            this.rbClaveNin.TabIndex = 26;
            this.rbClaveNin.TabStop = true;
            this.rbClaveNin.Text = "Clave Ninguna";
            this.rbClaveNin.UseVisualStyleBackColor = true;
            this.rbClaveNin.CheckedChanged += new System.EventHandler(this.rbClaveNin_CheckedChanged);
            // 
            // botonAceptar
            // 
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonAceptar.Image = global::Diccionario.Properties.Resources.Aceptar;
            this.botonAceptar.Location = new System.Drawing.Point(232, 213);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(50, 50);
            this.botonAceptar.TabIndex = 12;
            this.botonAceptar.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Image = global::Diccionario.Properties.Resources.Cancelar1;
            this.botonCancelar.Location = new System.Drawing.Point(0, 213);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(50, 50);
            this.botonCancelar.TabIndex = 11;
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // tbTam
            // 
            this.tbTam.Enabled = false;
            this.tbTam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTam.Location = new System.Drawing.Point(200, 113);
            this.tbTam.Name = "tbTam";
            this.tbTam.Size = new System.Drawing.Size(69, 26);
            this.tbTam.TabIndex = 27;
            this.tbTam.Text = "30";
            // 
            // DAltaAtr
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(281, 262);
            this.Controls.Add(this.tbTam);
            this.Controls.Add(this.rbClaveNin);
            this.Controls.Add(this.cbEntExt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbClaveExt);
            this.Controls.Add(this.rbClavePrim);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEntSel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.label1);
            this.Name = "DAltaAtr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Atributo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DAltaAtr_FormClosing);
            this.Load += new System.EventHandler(this.DAltaAtr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RadioButton rbClaveExt;
        public System.Windows.Forms.RadioButton rbClavePrim;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.RadioButton rbClaveNin;
        public System.Windows.Forms.ComboBox cbEntSel;
        public System.Windows.Forms.ComboBox cbTipo;
        public System.Windows.Forms.ComboBox cbEntExt;
        public System.Windows.Forms.TextBox tbTam;
    }
}