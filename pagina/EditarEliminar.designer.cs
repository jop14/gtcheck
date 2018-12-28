namespace Checador
{
    partial class EditarEliminar
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_servicios = new System.Windows.Forms.GroupBox();
            this.rdb_fe = new System.Windows.Forms.RadioButton();
            this.rdb_control = new System.Windows.Forms.RadioButton();
            this.btn_regresar = new System.Windows.Forms.Button();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.gb_usuarios = new System.Windows.Forms.GroupBox();
            this.rdb_terceros = new System.Windows.Forms.RadioButton();
            this.rdb_cliente = new System.Windows.Forms.RadioButton();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_idbusc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dg_bus = new System.Windows.Forms.DataGridView();
            this.btn_bus = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pb_equis = new System.Windows.Forms.PictureBox();
            this.pb_palomita = new System.Windows.Forms.PictureBox();
            this.txt_engasolinera = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_link = new System.Windows.Forms.ComboBox();
            this.btn_link = new System.Windows.Forms.Button();
            this.btn_ver = new System.Windows.Forms.Button();
            this.btn_ver2 = new System.Windows.Forms.Button();
            this.cb_permiso = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb_servicios.SuspendLayout();
            this.gb_usuarios.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_bus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_equis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_palomita)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_servicios
            // 
            this.gb_servicios.Controls.Add(this.rdb_fe);
            this.gb_servicios.Controls.Add(this.rdb_control);
            this.gb_servicios.Location = new System.Drawing.Point(123, 454);
            this.gb_servicios.Name = "gb_servicios";
            this.gb_servicios.Size = new System.Drawing.Size(163, 99);
            this.gb_servicios.TabIndex = 8;
            this.gb_servicios.TabStop = false;
            this.gb_servicios.Text = "Tipo de servicio:";
            // 
            // rdb_fe
            // 
            this.rdb_fe.AutoSize = true;
            this.rdb_fe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_fe.Location = new System.Drawing.Point(25, 65);
            this.rdb_fe.Name = "rdb_fe";
            this.rdb_fe.Size = new System.Drawing.Size(136, 17);
            this.rdb_fe.TabIndex = 1;
            this.rdb_fe.Text = "Facturación electrónica";
            this.rdb_fe.UseVisualStyleBackColor = true;
            // 
            // rdb_control
            // 
            this.rdb_control.AutoSize = true;
            this.rdb_control.Checked = true;
            this.rdb_control.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_control.Location = new System.Drawing.Point(25, 30);
            this.rdb_control.Name = "rdb_control";
            this.rdb_control.Size = new System.Drawing.Size(107, 17);
            this.rdb_control.TabIndex = 0;
            this.rdb_control.TabStop = true;
            this.rdb_control.Text = "Control de flotillas";
            this.rdb_control.UseVisualStyleBackColor = true;
            // 
            // btn_regresar
            // 
            this.btn_regresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_regresar.Location = new System.Drawing.Point(209, 571);
            this.btn_regresar.Name = "btn_regresar";
            this.btn_regresar.Size = new System.Drawing.Size(75, 23);
            this.btn_regresar.TabIndex = 11;
            this.btn_regresar.Text = "Cerrar";
            this.btn_regresar.UseVisualStyleBackColor = true;
            this.btn_regresar.Click += new System.EventHandler(this.btn_regresar_Click);
            // 
            // btn_registrar
            // 
            this.btn_registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_registrar.Location = new System.Drawing.Point(11, 571);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 9;
            this.btn_registrar.Text = "Actualizar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // gb_usuarios
            // 
            this.gb_usuarios.Controls.Add(this.rdb_terceros);
            this.gb_usuarios.Controls.Add(this.rdb_cliente);
            this.gb_usuarios.Location = new System.Drawing.Point(14, 452);
            this.gb_usuarios.Name = "gb_usuarios";
            this.gb_usuarios.Size = new System.Drawing.Size(105, 102);
            this.gb_usuarios.TabIndex = 7;
            this.gb_usuarios.TabStop = false;
            this.gb_usuarios.Text = "Tipo de usuario:";
            // 
            // rdb_terceros
            // 
            this.rdb_terceros.AutoSize = true;
            this.rdb_terceros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_terceros.Location = new System.Drawing.Point(25, 65);
            this.rdb_terceros.Name = "rdb_terceros";
            this.rdb_terceros.Size = new System.Drawing.Size(62, 17);
            this.rdb_terceros.TabIndex = 1;
            this.rdb_terceros.Text = "Tercero";
            this.rdb_terceros.UseVisualStyleBackColor = true;
            // 
            // rdb_cliente
            // 
            this.rdb_cliente.AutoSize = true;
            this.rdb_cliente.Checked = true;
            this.rdb_cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_cliente.Location = new System.Drawing.Point(25, 30);
            this.rdb_cliente.Name = "rdb_cliente";
            this.rdb_cliente.Size = new System.Drawing.Size(57, 17);
            this.rdb_cliente.TabIndex = 0;
            this.rdb_cliente.TabStop = true;
            this.rdb_cliente.Text = "Cliente";
            this.rdb_cliente.UseVisualStyleBackColor = true;
            // 
            // txt_link
            // 
            this.txt_link.Location = new System.Drawing.Point(14, 375);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(241, 20);
            this.txt_link.TabIndex = 6;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(14, 290);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(272, 20);
            this.txt_nombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enlace de pagina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre de la estacion";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminar.Location = new System.Drawing.Point(110, 571);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 10;
            this.btn_eliminar.Text = "Eliminar";
            this.toolTip1.SetToolTip(this.btn_eliminar, "Borrar de la base de datos los registros \r\nde la gasolinera seleccionada");
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_idbusc);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dg_bus);
            this.groupBox3.Controls.Add(this.btn_bus);
            this.groupBox3.Location = new System.Drawing.Point(7, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 149);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscador";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txt_idbusc
            // 
            this.txt_idbusc.Location = new System.Drawing.Point(10, 19);
            this.txt_idbusc.MaxLength = 50;
            this.txt_idbusc.Name = "txt_idbusc";
            this.txt_idbusc.Size = new System.Drawing.Size(191, 20);
            this.txt_idbusc.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txt_idbusc, "Ingrese el numero de estación o bien\r\nel nombre de la gasolinera");
            this.txt_idbusc.TextChanged += new System.EventHandler(this.txt_idbusc_TextChanged);
            this.txt_idbusc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_idbusc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Seleccionar resultado";
            // 
            // dg_bus
            // 
            this.dg_bus.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.dg_bus.AllowUserToAddRows = false;
            this.dg_bus.AllowUserToDeleteRows = false;
            this.dg_bus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_bus.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dg_bus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_bus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dg_bus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_bus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_bus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_bus.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_bus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_bus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dg_bus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dg_bus.EnableHeadersVisualStyles = false;
            this.dg_bus.Location = new System.Drawing.Point(3, 64);
            this.dg_bus.MultiSelect = false;
            this.dg_bus.Name = "dg_bus";
            this.dg_bus.ReadOnly = true;
            this.dg_bus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dg_bus.RowHeadersVisible = false;
            this.dg_bus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_bus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_bus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_bus.Size = new System.Drawing.Size(279, 82);
            this.dg_bus.StandardTab = true;
            this.dg_bus.TabIndex = 2;
            this.dg_bus.VirtualMode = true;
            this.dg_bus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_bus_CellContentClick);
            this.dg_bus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dg_bus_MouseDoubleClick);
            // 
            // btn_bus
            // 
            this.btn_bus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_bus.Location = new System.Drawing.Point(207, 17);
            this.btn_bus.Name = "btn_bus";
            this.btn_bus.Size = new System.Drawing.Size(75, 23);
            this.btn_bus.TabIndex = 1;
            this.btn_bus.Text = "Buscar";
            this.btn_bus.UseVisualStyleBackColor = true;
            this.btn_bus.Click += new System.EventHandler(this.btn_bus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Gasolinera";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(14, 200);
            this.txt_id.MaxLength = 6;
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(219, 20);
            this.txt_id.TabIndex = 3;
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Identificador de estación ";
            // 
            // pb_equis
            // 
            this.pb_equis.BackgroundImage = global::Checador.Properties.Resources.equis;
            this.pb_equis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_equis.Location = new System.Drawing.Point(239, 200);
            this.pb_equis.Name = "pb_equis";
            this.pb_equis.Size = new System.Drawing.Size(22, 23);
            this.pb_equis.TabIndex = 29;
            this.pb_equis.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_equis, "Identificador repetido, cambie identificador.");
            // 
            // pb_palomita
            // 
            this.pb_palomita.BackgroundImage = global::Checador.Properties.Resources.Green_Round_Tick;
            this.pb_palomita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_palomita.Location = new System.Drawing.Point(239, 200);
            this.pb_palomita.Name = "pb_palomita";
            this.pb_palomita.Size = new System.Drawing.Size(22, 23);
            this.pb_palomita.TabIndex = 28;
            this.pb_palomita.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_palomita, "Identificador aceptado");
            // 
            // txt_engasolinera
            // 
            this.txt_engasolinera.Location = new System.Drawing.Point(14, 333);
            this.txt_engasolinera.Name = "txt_engasolinera";
            this.txt_engasolinera.Size = new System.Drawing.Size(241, 20);
            this.txt_engasolinera.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Enlace de gasolinera";
            // 
            // cb_link
            // 
            this.cb_link.DisplayMember = "Nombre";
            this.cb_link.FormattingEnabled = true;
            this.cb_link.Location = new System.Drawing.Point(14, 247);
            this.cb_link.Name = "cb_link";
            this.cb_link.Size = new System.Drawing.Size(209, 21);
            this.cb_link.TabIndex = 33;
            this.cb_link.ValueMember = "enlace";
            this.cb_link.SelectedIndexChanged += new System.EventHandler(this.cb_link_SelectedIndexChanged);
            // 
            // btn_link
            // 
            this.btn_link.Location = new System.Drawing.Point(229, 247);
            this.btn_link.Name = "btn_link";
            this.btn_link.Size = new System.Drawing.Size(60, 23);
            this.btn_link.TabIndex = 32;
            this.btn_link.Text = "Añadir";
            this.btn_link.UseVisualStyleBackColor = true;
            this.btn_link.Click += new System.EventHandler(this.btn_link_Click);
            // 
            // btn_ver
            // 
            this.btn_ver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ver.Location = new System.Drawing.Point(255, 373);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(34, 23);
            this.btn_ver.TabIndex = 27;
            this.btn_ver.Text = "ver";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btn_ver2
            // 
            this.btn_ver2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ver2.Location = new System.Drawing.Point(258, 331);
            this.btn_ver2.Name = "btn_ver2";
            this.btn_ver2.Size = new System.Drawing.Size(34, 23);
            this.btn_ver2.TabIndex = 34;
            this.btn_ver2.Text = "ver";
            this.btn_ver2.UseVisualStyleBackColor = true;
            this.btn_ver2.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // cb_permiso
            // 
            this.cb_permiso.DisplayMember = "Nombre";
            this.cb_permiso.FormattingEnabled = true;
            this.cb_permiso.Location = new System.Drawing.Point(15, 421);
            this.cb_permiso.Name = "cb_permiso";
            this.cb_permiso.Size = new System.Drawing.Size(240, 21);
            this.cb_permiso.TabIndex = 36;
            this.cb_permiso.ValueMember = "IdPermiso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Permiso de";
            // 
            // EditarEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(299, 599);
            this.ControlBox = false;
            this.Controls.Add(this.cb_permiso);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_ver2);
            this.Controls.Add(this.cb_link);
            this.Controls.Add(this.btn_link);
            this.Controls.Add(this.txt_engasolinera);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pb_equis);
            this.Controls.Add(this.pb_palomita);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.gb_servicios);
            this.Controls.Add(this.btn_regresar);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.gb_usuarios);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarEliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar/Eliminar página";
            this.Load += new System.EventHandler(this.EditarEliminar_Load);
            this.Shown += new System.EventHandler(this.EditarEliminar_Shown);
            this.gb_servicios.ResumeLayout(false);
            this.gb_servicios.PerformLayout();
            this.gb_usuarios.ResumeLayout(false);
            this.gb_usuarios.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_bus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_equis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_palomita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_servicios;
        private System.Windows.Forms.RadioButton rdb_fe;
        private System.Windows.Forms.RadioButton rdb_control;
        private System.Windows.Forms.Button btn_regresar;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.GroupBox gb_usuarios;
        private System.Windows.Forms.RadioButton rdb_terceros;
        private System.Windows.Forms.RadioButton rdb_cliente;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_bus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dg_bus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_idbusc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pb_equis;
        private System.Windows.Forms.PictureBox pb_palomita;
        private System.Windows.Forms.TextBox txt_engasolinera;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cb_link;
        private System.Windows.Forms.Button btn_link;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.Button btn_ver2;
        public System.Windows.Forms.ComboBox cb_permiso;
        private System.Windows.Forms.Label label7;
    }
}