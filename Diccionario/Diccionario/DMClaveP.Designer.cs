namespace Diccionario
{
    partial class DMClaveP
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
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.lbAtr = new System.Windows.Forms.Label();
            this.lbEnt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonAceptar
            // 
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonAceptar.Image = global::Diccionario.Properties.Resources.Aceptar;
            this.botonAceptar.Location = new System.Drawing.Point(512, 78);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(50, 50);
            this.botonAceptar.TabIndex = 8;
            this.botonAceptar.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Image = global::Diccionario.Properties.Resources.Cancelar1;
            this.botonCancelar.Location = new System.Drawing.Point(7, 78);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(50, 50);
            this.botonCancelar.TabIndex = 7;
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje.Location = new System.Drawing.Point(3, 20);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(559, 38);
            this.lbMensaje.TabIndex = 9;
            this.lbMensaje.Text = "La Entidad                               ya tiene el Atributo                    " +
                "     con clave primaria.\r\nSi Continua se eliminara esta relación y se creara una" +
                " nueva.";
            // 
            // lbAtr
            // 
            this.lbAtr.AutoSize = true;
            this.lbAtr.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAtr.Location = new System.Drawing.Point(352, 19);
            this.lbAtr.Name = "lbAtr";
            this.lbAtr.Size = new System.Drawing.Size(49, 19);
            this.lbAtr.TabIndex = 10;
            this.lbAtr.Text = "label1";
            // 
            // lbEnt
            // 
            this.lbEnt.AutoSize = true;
            this.lbEnt.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnt.Location = new System.Drawing.Point(117, 19);
            this.lbEnt.Name = "lbEnt";
            this.lbEnt.Size = new System.Drawing.Size(49, 19);
            this.lbEnt.TabIndex = 11;
            this.lbEnt.Text = "label2";
            // 
            // DMClaveP
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(570, 131);
            this.Controls.Add(this.lbEnt);
            this.Controls.Add(this.lbAtr);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.botonCancelar);
            this.Name = "DMClaveP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Clave Primaria";
            this.Load += new System.EventHandler(this.DMClaveP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        public System.Windows.Forms.Label lbAtr;
        public System.Windows.Forms.Label lbEnt;
        public System.Windows.Forms.Label lbMensaje;
    }
}