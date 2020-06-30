namespace Diccionario
{
    partial class DModificaAtr
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
            this.rbCalveNin = new System.Windows.Forms.RadioButton();
            this.cbEntExt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbClaveExt = new System.Windows.Forms.RadioButton();
            this.rbClavePrim = new System.Windows.Forms.RadioButton();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAtrSel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEntSel = new System.Windows.Forms.TextBox();
            this.tbTam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbCalveNin
            // 
            this.rbCalveNin.AutoSize = true;
            this.rbCalveNin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbCalveNin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCalveNin.Location = new System.Drawing.Point(19, 210);
            this.rbCalveNin.Name = "rbCalveNin";
            this.rbCalveNin.Size = new System.Drawing.Size(126, 23);
            this.rbCalveNin.TabIndex = 39;
            this.rbCalveNin.TabStop = true;
            this.rbCalveNin.Text = "Clave Ninguna";
            this.rbCalveNin.UseVisualStyleBackColor = true;
            this.rbCalveNin.CheckedChanged += new System.EventHandler(this.rbCalveNin_CheckedChanged);
            // 
            // cbEntExt
            // 
            this.cbEntExt.Enabled = false;
            this.cbEntExt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntExt.FormattingEnabled = true;
            this.cbEntExt.Location = new System.Drawing.Point(151, 201);
            this.cbEntExt.Name = "cbEntExt";
            this.cbEntExt.Size = new System.Drawing.Size(121, 27);
            this.cbEntExt.TabIndex = 38;
            this.cbEntExt.SelectedIndexChanged += new System.EventHandler(this.cbEntExt_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(173, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "Entidad:";
            // 
            // rbClaveExt
            // 
            this.rbClaveExt.AutoSize = true;
            this.rbClaveExt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbClaveExt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClaveExt.Location = new System.Drawing.Point(22, 181);
            this.rbClaveExt.Name = "rbClaveExt";
            this.rbClaveExt.Size = new System.Drawing.Size(123, 23);
            this.rbClaveExt.TabIndex = 36;
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
            this.rbClavePrim.Location = new System.Drawing.Point(18, 151);
            this.rbClavePrim.Name = "rbClavePrim";
            this.rbClavePrim.Size = new System.Drawing.Size(127, 23);
            this.rbClavePrim.TabIndex = 35;
            this.rbClavePrim.TabStop = true;
            this.rbClavePrim.Text = "Clave Primaria";
            this.rbClavePrim.UseVisualStyleBackColor = true;
            this.rbClavePrim.CheckedChanged += new System.EventHandler(this.rbClavePrim_CheckedChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(113, 111);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(159, 27);
            this.cbTipo.TabIndex = 34;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 22);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 31;
            this.label2.Text = "Entidad:";
            // 
            // tbNom
            // 
            this.tbNom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNom.Location = new System.Drawing.Point(113, 79);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(159, 26);
            this.tbNom.TabIndex = 1;
            // 
            // botonAceptar
            // 
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonAceptar.Image = global::Diccionario.Properties.Resources.Aceptar;
            this.botonAceptar.Location = new System.Drawing.Point(233, 244);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(50, 50);
            this.botonAceptar.TabIndex = 29;
            this.botonAceptar.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Image = global::Diccionario.Properties.Resources.Cancelar1;
            this.botonCancelar.Location = new System.Drawing.Point(1, 244);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(50, 50);
            this.botonCancelar.TabIndex = 28;
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre:";
            // 
            // tbAtrSel
            // 
            this.tbAtrSel.Enabled = false;
            this.tbAtrSel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAtrSel.Location = new System.Drawing.Point(113, 41);
            this.tbAtrSel.Name = "tbAtrSel";
            this.tbAtrSel.Size = new System.Drawing.Size(159, 26);
            this.tbAtrSel.TabIndex = 41;
            this.tbAtrSel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 22);
            this.label5.TabIndex = 40;
            this.label5.Text = "Atributo:";
            // 
            // tbEntSel
            // 
            this.tbEntSel.Enabled = false;
            this.tbEntSel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEntSel.Location = new System.Drawing.Point(113, 7);
            this.tbEntSel.Name = "tbEntSel";
            this.tbEntSel.Size = new System.Drawing.Size(159, 26);
            this.tbEntSel.TabIndex = 42;
            this.tbEntSel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTam
            // 
            this.tbTam.Enabled = false;
            this.tbTam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTam.Location = new System.Drawing.Point(203, 144);
            this.tbTam.Name = "tbTam";
            this.tbTam.Size = new System.Drawing.Size(69, 26);
            this.tbTam.TabIndex = 43;
            this.tbTam.Text = "30";
            // 
            // DModificaAtr
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.Controls.Add(this.tbTam);
            this.Controls.Add(this.tbEntSel);
            this.Controls.Add(this.tbAtrSel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbCalveNin);
            this.Controls.Add(this.cbEntExt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbClaveExt);
            this.Controls.Add(this.rbClavePrim);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.label1);
            this.Name = "DModificaAtr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Atributo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DModificaAtr_FormClosing);
            this.Load += new System.EventHandler(this.DModificaAtr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton rbCalveNin;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.RadioButton rbClaveExt;
        public System.Windows.Forms.RadioButton rbClavePrim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbAtrSel;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbEntSel;
        public System.Windows.Forms.ComboBox cbEntExt;
        public System.Windows.Forms.ComboBox cbTipo;
        public System.Windows.Forms.TextBox tbTam;
    }
}