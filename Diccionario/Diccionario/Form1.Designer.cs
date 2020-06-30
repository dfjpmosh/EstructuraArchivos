namespace Diccionario
{
    partial class Diccionario
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diccionario));
            this.menuPrincipalDiccionario = new System.Windows.Forms.MenuStrip();
            this.dgvE = new System.Windows.Forms.DataGridView();
            this.Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptAtributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptAtributoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AptEntidadA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dialogoAbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.botonModificaAtributo = new System.Windows.Forms.Button();
            this.botonBajaAtributo = new System.Windows.Forms.Button();
            this.botonAltaAtributo = new System.Windows.Forms.Button();
            this.botonModificaEntidad = new System.Windows.Forms.Button();
            this.botonBajaEntidad = new System.Windows.Forms.Button();
            this.botonAltaEntidad = new System.Windows.Forms.Button();
            this.botonAbrir = new System.Windows.Forms.Button();
            this.botonNuevo = new System.Windows.Forms.Button();
            this.menuDiccionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNuevoDiccionario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbrirDiccionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAltaEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBajaEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuModificarEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAltaAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBajaAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuModificarAtributo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMDiccionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrganizaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOSecuencial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrearSecuencial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbrirSecuencial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrearSecIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbrirSecIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrearHash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbrirHash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrearMultillave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAbrirMultillave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipalDiccionario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipalDiccionario
            // 
            this.menuPrincipalDiccionario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDiccionario,
            this.menuEntidad,
            this.menuAtributo,
            this.menuMantenimiento,
            this.menuOrganizaciones});
            this.menuPrincipalDiccionario.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipalDiccionario.Name = "menuPrincipalDiccionario";
            this.menuPrincipalDiccionario.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuPrincipalDiccionario.Size = new System.Drawing.Size(684, 27);
            this.menuPrincipalDiccionario.TabIndex = 0;
            this.menuPrincipalDiccionario.Text = "menuPrincipalDiccionario";
            // 
            // dgvE
            // 
            this.dgvE.AllowUserToAddRows = false;
            this.dgvE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entidad,
            this.Direccion,
            this.AptEntidad,
            this.AptAtributo,
            this.AptDatos});
            this.dgvE.Location = new System.Drawing.Point(56, 155);
            this.dgvE.Name = "dgvE";
            this.dgvE.Size = new System.Drawing.Size(545, 190);
            this.dgvE.TabIndex = 3;
            this.dgvE.SelectionChanged += new System.EventHandler(this.dgvE_SelectionChanged);
            // 
            // Entidad
            // 
            this.Entidad.HeaderText = "Entidad";
            this.Entidad.Name = "Entidad";
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            // 
            // AptEntidad
            // 
            this.AptEntidad.HeaderText = "AptEntidad";
            this.AptEntidad.Name = "AptEntidad";
            // 
            // AptAtributo
            // 
            this.AptAtributo.HeaderText = "AptAtributo";
            this.AptAtributo.Name = "AptAtributo";
            // 
            // AptDatos
            // 
            this.AptDatos.HeaderText = "AptDatos";
            this.AptDatos.Name = "AptDatos";
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
            this.dgvA.Location = new System.Drawing.Point(56, 383);
            this.dgvA.Name = "dgvA";
            this.dgvA.Size = new System.Drawing.Size(545, 190);
            this.dgvA.TabIndex = 4;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Entidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Atributos";
            // 
            // botonModificaAtributo
            // 
            this.botonModificaAtributo.Image = global::Diccionario.Properties.Resources.ModificarAtributo;
            this.botonModificaAtributo.Location = new System.Drawing.Point(593, 32);
            this.botonModificaAtributo.Name = "botonModificaAtributo";
            this.botonModificaAtributo.Size = new System.Drawing.Size(75, 80);
            this.botonModificaAtributo.TabIndex = 10;
            this.botonModificaAtributo.UseVisualStyleBackColor = true;
            this.botonModificaAtributo.Click += new System.EventHandler(this.menuModificarAtributo_Click);
            // 
            // botonBajaAtributo
            // 
            this.botonBajaAtributo.Image = global::Diccionario.Properties.Resources.BajaAtributo;
            this.botonBajaAtributo.Location = new System.Drawing.Point(512, 32);
            this.botonBajaAtributo.Name = "botonBajaAtributo";
            this.botonBajaAtributo.Size = new System.Drawing.Size(75, 80);
            this.botonBajaAtributo.TabIndex = 9;
            this.botonBajaAtributo.UseVisualStyleBackColor = true;
            this.botonBajaAtributo.Click += new System.EventHandler(this.menuBajaAtributo_Click);
            // 
            // botonAltaAtributo
            // 
            this.botonAltaAtributo.Image = global::Diccionario.Properties.Resources.AltaAtributo;
            this.botonAltaAtributo.Location = new System.Drawing.Point(431, 32);
            this.botonAltaAtributo.Name = "botonAltaAtributo";
            this.botonAltaAtributo.Size = new System.Drawing.Size(75, 80);
            this.botonAltaAtributo.TabIndex = 8;
            this.botonAltaAtributo.UseVisualStyleBackColor = true;
            this.botonAltaAtributo.Click += new System.EventHandler(this.menuAltaAtributo_Click);
            // 
            // botonModificaEntidad
            // 
            this.botonModificaEntidad.Image = global::Diccionario.Properties.Resources.ModificarEntidad;
            this.botonModificaEntidad.Location = new System.Drawing.Point(345, 32);
            this.botonModificaEntidad.Name = "botonModificaEntidad";
            this.botonModificaEntidad.Size = new System.Drawing.Size(75, 80);
            this.botonModificaEntidad.TabIndex = 7;
            this.botonModificaEntidad.UseVisualStyleBackColor = true;
            this.botonModificaEntidad.Click += new System.EventHandler(this.menuModificarEntidad_Click);
            // 
            // botonBajaEntidad
            // 
            this.botonBajaEntidad.Image = global::Diccionario.Properties.Resources.BajaEntidad;
            this.botonBajaEntidad.Location = new System.Drawing.Point(264, 32);
            this.botonBajaEntidad.Name = "botonBajaEntidad";
            this.botonBajaEntidad.Size = new System.Drawing.Size(75, 80);
            this.botonBajaEntidad.TabIndex = 6;
            this.botonBajaEntidad.UseVisualStyleBackColor = true;
            this.botonBajaEntidad.Click += new System.EventHandler(this.menuBajaEntidad_Click);
            // 
            // botonAltaEntidad
            // 
            this.botonAltaEntidad.Image = global::Diccionario.Properties.Resources.AltaEntidad;
            this.botonAltaEntidad.Location = new System.Drawing.Point(183, 32);
            this.botonAltaEntidad.Name = "botonAltaEntidad";
            this.botonAltaEntidad.Size = new System.Drawing.Size(75, 80);
            this.botonAltaEntidad.TabIndex = 5;
            this.botonAltaEntidad.UseVisualStyleBackColor = true;
            this.botonAltaEntidad.Click += new System.EventHandler(this.menuAltaEntidad_Click);
            // 
            // botonAbrir
            // 
            this.botonAbrir.Image = global::Diccionario.Properties.Resources.Abrir;
            this.botonAbrir.Location = new System.Drawing.Point(93, 32);
            this.botonAbrir.Name = "botonAbrir";
            this.botonAbrir.Size = new System.Drawing.Size(75, 80);
            this.botonAbrir.TabIndex = 2;
            this.botonAbrir.UseVisualStyleBackColor = true;
            this.botonAbrir.Click += new System.EventHandler(this.menuAbrirDiccionario_Click);
            // 
            // botonNuevo
            // 
            this.botonNuevo.Image = global::Diccionario.Properties.Resources.Nueva_Carpeta1;
            this.botonNuevo.Location = new System.Drawing.Point(12, 32);
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(75, 80);
            this.botonNuevo.TabIndex = 1;
            this.botonNuevo.UseVisualStyleBackColor = true;
            this.botonNuevo.Click += new System.EventHandler(this.menuNuevoDiccionario_Click);
            // 
            // menuDiccionario
            // 
            this.menuDiccionario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNuevoDiccionario,
            this.toolStripSeparator1,
            this.menuAbrirDiccionario});
            this.menuDiccionario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDiccionario.Image = global::Diccionario.Properties.Resources.biohazard;
            this.menuDiccionario.Name = "menuDiccionario";
            this.menuDiccionario.Size = new System.Drawing.Size(113, 23);
            this.menuDiccionario.Text = "&Diccionario";
            // 
            // menuNuevoDiccionario
            // 
            this.menuNuevoDiccionario.Name = "menuNuevoDiccionario";
            this.menuNuevoDiccionario.Size = new System.Drawing.Size(122, 24);
            this.menuNuevoDiccionario.Text = "&Nuevo";
            this.menuNuevoDiccionario.Click += new System.EventHandler(this.menuNuevoDiccionario_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // menuAbrirDiccionario
            // 
            this.menuAbrirDiccionario.Name = "menuAbrirDiccionario";
            this.menuAbrirDiccionario.Size = new System.Drawing.Size(122, 24);
            this.menuAbrirDiccionario.Text = "&Abrir";
            this.menuAbrirDiccionario.Click += new System.EventHandler(this.menuAbrirDiccionario_Click);
            // 
            // menuEntidad
            // 
            this.menuEntidad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAltaEntidad,
            this.toolStripSeparator2,
            this.menuBajaEntidad,
            this.toolStripSeparator3,
            this.menuModificarEntidad});
            this.menuEntidad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuEntidad.Image = global::Diccionario.Properties.Resources.Umbrella_Corporation;
            this.menuEntidad.Name = "menuEntidad";
            this.menuEntidad.Size = new System.Drawing.Size(88, 23);
            this.menuEntidad.Text = "&Entidad";
            // 
            // menuAltaEntidad
            // 
            this.menuAltaEntidad.Name = "menuAltaEntidad";
            this.menuAltaEntidad.Size = new System.Drawing.Size(144, 24);
            this.menuAltaEntidad.Text = "&Alta";
            this.menuAltaEntidad.Click += new System.EventHandler(this.menuAltaEntidad_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // menuBajaEntidad
            // 
            this.menuBajaEntidad.Name = "menuBajaEntidad";
            this.menuBajaEntidad.Size = new System.Drawing.Size(144, 24);
            this.menuBajaEntidad.Text = "&Baja";
            this.menuBajaEntidad.Click += new System.EventHandler(this.menuBajaEntidad_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // menuModificarEntidad
            // 
            this.menuModificarEntidad.Name = "menuModificarEntidad";
            this.menuModificarEntidad.Size = new System.Drawing.Size(144, 24);
            this.menuModificarEntidad.Text = "&Modificar";
            this.menuModificarEntidad.Click += new System.EventHandler(this.menuModificarEntidad_Click);
            // 
            // menuAtributo
            // 
            this.menuAtributo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAltaAtributo,
            this.toolStripSeparator4,
            this.menuBajaAtributo,
            this.toolStripSeparator5,
            this.menuModificarAtributo});
            this.menuAtributo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAtributo.Image = global::Diccionario.Properties.Resources.Untitled_1_copy;
            this.menuAtributo.Name = "menuAtributo";
            this.menuAtributo.Size = new System.Drawing.Size(92, 23);
            this.menuAtributo.Text = "&Atributo";
            // 
            // menuAltaAtributo
            // 
            this.menuAltaAtributo.Name = "menuAltaAtributo";
            this.menuAltaAtributo.Size = new System.Drawing.Size(144, 24);
            this.menuAltaAtributo.Text = "&Alta";
            this.menuAltaAtributo.Click += new System.EventHandler(this.menuAltaAtributo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // menuBajaAtributo
            // 
            this.menuBajaAtributo.Name = "menuBajaAtributo";
            this.menuBajaAtributo.Size = new System.Drawing.Size(144, 24);
            this.menuBajaAtributo.Text = "&Baja";
            this.menuBajaAtributo.Click += new System.EventHandler(this.menuBajaAtributo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(141, 6);
            // 
            // menuModificarAtributo
            // 
            this.menuModificarAtributo.Name = "menuModificarAtributo";
            this.menuModificarAtributo.Size = new System.Drawing.Size(144, 24);
            this.menuModificarAtributo.Text = "&Modificar";
            this.menuModificarAtributo.Click += new System.EventHandler(this.menuModificarAtributo_Click);
            // 
            // menuMantenimiento
            // 
            this.menuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMDiccionario});
            this.menuMantenimiento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMantenimiento.Image = global::Diccionario.Properties.Resources.Mantenimiento;
            this.menuMantenimiento.Name = "menuMantenimiento";
            this.menuMantenimiento.Size = new System.Drawing.Size(139, 23);
            this.menuMantenimiento.Text = "&Mantenimiento";
            // 
            // menuMDiccionario
            // 
            this.menuMDiccionario.Name = "menuMDiccionario";
            this.menuMDiccionario.Size = new System.Drawing.Size(178, 24);
            this.menuMDiccionario.Text = "M. &Diccionario";
            this.menuMDiccionario.Click += new System.EventHandler(this.menuMDiccionario_Click);
            // 
            // menuOrganizaciones
            // 
            this.menuOrganizaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOSecuencial,
            this.toolStripSeparator8,
            this.toolStripMenuItem1,
            this.toolStripSeparator9,
            this.toolStripMenuItem5,
            this.toolStripSeparator11,
            this.toolStripMenuItem2,
            this.toolStripSeparator13,
            this.toolStripMenuItem8});
            this.menuOrganizaciones.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOrganizaciones.Image = global::Diccionario.Properties.Resources.Mantenimiento;
            this.menuOrganizaciones.Name = "menuOrganizaciones";
            this.menuOrganizaciones.Size = new System.Drawing.Size(139, 23);
            this.menuOrganizaciones.Text = "&Organizaciones";
            // 
            // menuOSecuencial
            // 
            this.menuOSecuencial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCrearSecuencial,
            this.toolStripSeparator6,
            this.menuAbrirSecuencial});
            this.menuOSecuencial.Name = "menuOSecuencial";
            this.menuOSecuencial.Size = new System.Drawing.Size(172, 24);
            this.menuOSecuencial.Text = "&Secuencial";
            // 
            // menuCrearSecuencial
            // 
            this.menuCrearSecuencial.Name = "menuCrearSecuencial";
            this.menuCrearSecuencial.Size = new System.Drawing.Size(117, 24);
            this.menuCrearSecuencial.Text = "Crear";
            this.menuCrearSecuencial.Click += new System.EventHandler(this.menuCrearSecuencial_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(114, 6);
            // 
            // menuAbrirSecuencial
            // 
            this.menuAbrirSecuencial.Name = "menuAbrirSecuencial";
            this.menuAbrirSecuencial.Size = new System.Drawing.Size(117, 24);
            this.menuAbrirSecuencial.Text = "Abrir";
            this.menuAbrirSecuencial.Click += new System.EventHandler(this.menuAbrirSecuencial_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCrearSecIndex,
            this.toolStripSeparator7,
            this.menuAbrirSecIndex});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 24);
            this.toolStripMenuItem1.Text = "Sec. &Indexada";
            // 
            // menuCrearSecIndex
            // 
            this.menuCrearSecIndex.Name = "menuCrearSecIndex";
            this.menuCrearSecIndex.Size = new System.Drawing.Size(117, 24);
            this.menuCrearSecIndex.Text = "Crear";
            this.menuCrearSecIndex.Click += new System.EventHandler(this.menuCrearSecIndex_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(114, 6);
            // 
            // menuAbrirSecIndex
            // 
            this.menuAbrirSecIndex.Name = "menuAbrirSecIndex";
            this.menuAbrirSecIndex.Size = new System.Drawing.Size(117, 24);
            this.menuAbrirSecIndex.Text = "Abrir";
            this.menuAbrirSecIndex.Click += new System.EventHandler(this.menuAbrirSecIndex_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripSeparator12,
            this.toolStripMenuItem7});
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(172, 24);
            this.toolStripMenuItem5.Text = "&Arboles";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(117, 24);
            this.toolStripMenuItem6.Text = "Crear";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(114, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(117, 24);
            this.toolStripMenuItem7.Text = "Abrir";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCrearHash,
            this.toolStripSeparator10,
            this.menuAbrirHash});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 24);
            this.toolStripMenuItem2.Text = "&Hash";
            // 
            // menuCrearHash
            // 
            this.menuCrearHash.Name = "menuCrearHash";
            this.menuCrearHash.Size = new System.Drawing.Size(152, 24);
            this.menuCrearHash.Text = "Crear";
            this.menuCrearHash.Click += new System.EventHandler(this.menuCrearHash_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(149, 6);
            // 
            // menuAbrirHash
            // 
            this.menuAbrirHash.Name = "menuAbrirHash";
            this.menuAbrirHash.Size = new System.Drawing.Size(152, 24);
            this.menuAbrirHash.Text = "Abrir";
            this.menuAbrirHash.Click += new System.EventHandler(this.menuAbrirHash_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCrearMultillave,
            this.toolStripSeparator14,
            this.menuAbrirMultillave});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(172, 24);
            this.toolStripMenuItem8.Text = "&Multillave";
            // 
            // menuCrearMultillave
            // 
            this.menuCrearMultillave.Name = "menuCrearMultillave";
            this.menuCrearMultillave.Size = new System.Drawing.Size(152, 24);
            this.menuCrearMultillave.Text = "Crear";
            this.menuCrearMultillave.Click += new System.EventHandler(this.menuCrearMultillave_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(149, 6);
            // 
            // menuAbrirMultillave
            // 
            this.menuAbrirMultillave.Name = "menuAbrirMultillave";
            this.menuAbrirMultillave.Size = new System.Drawing.Size(152, 24);
            this.menuAbrirMultillave.Text = "Abrir";
            this.menuAbrirMultillave.Click += new System.EventHandler(this.menuAbrirMultillave_Click);
            // 
            // Diccionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(684, 589);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.dgvE);
            this.Controls.Add(this.botonModificaAtributo);
            this.Controls.Add(this.botonBajaAtributo);
            this.Controls.Add(this.botonAltaAtributo);
            this.Controls.Add(this.botonModificaEntidad);
            this.Controls.Add(this.botonBajaEntidad);
            this.Controls.Add(this.botonAltaEntidad);
            this.Controls.Add(this.botonAbrir);
            this.Controls.Add(this.botonNuevo);
            this.Controls.Add(this.menuPrincipalDiccionario);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuPrincipalDiccionario;
            this.Name = "Diccionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diccionario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Diccionario_FormClosing);
            this.Load += new System.EventHandler(this.Diccionario_Load);
            this.menuPrincipalDiccionario.ResumeLayout(false);
            this.menuPrincipalDiccionario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipalDiccionario;
        private System.Windows.Forms.ToolStripMenuItem menuDiccionario;
        private System.Windows.Forms.ToolStripMenuItem menuEntidad;
        private System.Windows.Forms.ToolStripMenuItem menuAtributo;
        private System.Windows.Forms.ToolStripMenuItem menuNuevoDiccionario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirDiccionario;
        private System.Windows.Forms.Button botonNuevo;
        private System.Windows.Forms.Button botonAbrir;
        private System.Windows.Forms.Button botonAltaEntidad;
        private System.Windows.Forms.Button botonAltaAtributo;
        private System.Windows.Forms.Button botonModificaEntidad;
        private System.Windows.Forms.Button botonBajaEntidad;
        private System.Windows.Forms.Button botonModificaAtributo;
        private System.Windows.Forms.Button botonBajaAtributo;
        private System.Windows.Forms.DataGridView dgvE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entidad;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptAtributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptAtributoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AptEntidadA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoClave;
        private System.Windows.Forms.ToolStripMenuItem menuAltaEntidad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuBajaEntidad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuModificarEntidad;
        private System.Windows.Forms.ToolStripMenuItem menuAltaAtributo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuBajaAtributo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuModificarAtributo;
        private System.Windows.Forms.OpenFileDialog dialogoAbrirArchivo;
        private System.Windows.Forms.ToolStripMenuItem menuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem menuMDiccionario;
        private System.Windows.Forms.ToolStripMenuItem menuOrganizaciones;
        private System.Windows.Forms.ToolStripMenuItem menuOSecuencial;
        private System.Windows.Forms.ToolStripMenuItem menuCrearSecuencial;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirSecuencial;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuCrearSecIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirSecIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuCrearHash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirHash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem menuCrearMultillave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirMultillave;
    }
}

