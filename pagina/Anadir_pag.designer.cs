namespace Checador
{
    partial class Anadir_pag
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_terceros = new System.Windows.Forms.RadioButton();
            this.rdb_cliente = new System.Windows.Forms.RadioButton();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.btn_regresar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb_fe = new System.Windows.Forms.RadioButton();
            this.rdb_control = new System.Windows.Forms.RadioButton();
            this.txt_engasolinera = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_palomita = new System.Windows.Forms.PictureBox();
            this.pb_equis = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btn_link = new System.Windows.Forms.Button();
            this.cb_link = new System.Windows.Forms.ComboBox();
            this.cblink_permiso = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_palomita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_equis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la estación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enlace de pagina";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(12, 123);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(272, 20);
            this.txt_nombre.TabIndex = 2;
            // 
            // txt_link
            // 
            this.txt_link.Location = new System.Drawing.Point(12, 209);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(272, 20);
            this.txt_link.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txt_link, "Dirección de la pagina web \r\nFacturación electronica ó Control de flotillas");
            this.txt_link.TextChanged += new System.EventHandler(this.txt_link_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_terceros);
            this.groupBox1.Controls.Add(this.rdb_cliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de usuario:";
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
            this.rdb_terceros.CheckedChanged += new System.EventHandler(this.rdb_terceros_CheckedChanged);
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
            // btn_registrar
            // 
            this.btn_registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_registrar.Location = new System.Drawing.Point(42, 399);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 6;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_regresar
            // 
            this.btn_regresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_regresar.Location = new System.Drawing.Point(182, 399);
            this.btn_regresar.Name = "btn_regresar";
            this.btn_regresar.Size = new System.Drawing.Size(75, 23);
            this.btn_regresar.TabIndex = 7;
            this.btn_regresar.Text = "Cancelar";
            this.btn_regresar.UseVisualStyleBackColor = true;
            this.btn_regresar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Identificador de estación ";
            // 
            // txt_id
            // 
            this.txt_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_id.Location = new System.Drawing.Point(12, 37);
            this.txt_id.MaxLength = 6;
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(181, 20);
            this.txt_id.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txt_id, "El identificador debe iniciar con \"E\"\r\nseguida de 5 numeros ej: E12345");
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb_fe);
            this.groupBox2.Controls.Add(this.rdb_control);
            this.groupBox2.Location = new System.Drawing.Point(123, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 99);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de servicio:";
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
            // txt_engasolinera
            // 
            this.txt_engasolinera.Enabled = false;
            this.txt_engasolinera.Location = new System.Drawing.Point(12, 164);
            this.txt_engasolinera.Name = "txt_engasolinera";
            this.txt_engasolinera.Size = new System.Drawing.Size(272, 20);
            this.txt_engasolinera.TabIndex = 1;
            this.txt_engasolinera.TextChanged += new System.EventHandler(this.txt_gasolinera_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre de la gasolinera";
            // 
            // pb_palomita
            // 
            this.pb_palomita.BackgroundImage = global::Checador.Properties.Resources.Green_Round_Tick;
            this.pb_palomita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_palomita.Location = new System.Drawing.Point(199, 36);
            this.pb_palomita.Name = "pb_palomita";
            this.pb_palomita.Size = new System.Drawing.Size(22, 23);
            this.pb_palomita.TabIndex = 12;
            this.pb_palomita.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_palomita, "Identificador aceptado");
            // 
            // pb_equis
            // 
            this.pb_equis.BackgroundImage = global::Checador.Properties.Resources.equis;
            this.pb_equis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_equis.Location = new System.Drawing.Point(199, 36);
            this.pb_equis.Name = "pb_equis";
            this.pb_equis.Size = new System.Drawing.Size(22, 23);
            this.pb_equis.TabIndex = 13;
            this.pb_equis.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_equis, "Identificador repetido, cambie identificador.");
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Enlace de gasolinera";
            // 
            // btn_link
            // 
            this.btn_link.Location = new System.Drawing.Point(227, 79);
            this.btn_link.Name = "btn_link";
            this.btn_link.Size = new System.Drawing.Size(69, 23);
            this.btn_link.TabIndex = 16;
            this.btn_link.Text = "Añadir";
            this.btn_link.UseVisualStyleBackColor = true;
            this.btn_link.Click += new System.EventHandler(this.btn_link_Click);
            // 
            // cb_link
            // 
            this.cb_link.DisplayMember = "Nombre";
            this.cb_link.FormattingEnabled = true;
            this.cb_link.Location = new System.Drawing.Point(12, 79);
            this.cb_link.Name = "cb_link";
            this.cb_link.Size = new System.Drawing.Size(209, 21);
            this.cb_link.TabIndex = 18;
            this.cb_link.ValueMember = "enlace";
            this.cb_link.SelectedIndexChanged += new System.EventHandler(this.cb_link_SelectedIndexChanged_1);
            // 
            // cblink_permiso
            // 
            this.cblink_permiso.DisplayMember = "Nombre";
            this.cblink_permiso.FormattingEnabled = true;
            this.cblink_permiso.Location = new System.Drawing.Point(12, 258);
            this.cblink_permiso.Name = "cblink_permiso";
            this.cblink_permiso.Size = new System.Drawing.Size(272, 21);
            this.cblink_permiso.TabIndex = 20;
            this.cblink_permiso.ValueMember = "IdPermiso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tipo de permiso:";
            // 
            // Anadir_pag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 435);
            this.ControlBox = false;
            this.Controls.Add(this.cblink_permiso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_link);
            this.Controls.Add(this.btn_link);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pb_equis);
            this.Controls.Add(this.pb_palomita);
            this.Controls.Add(this.txt_engasolinera);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_regresar);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Anadir_pag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar página";
            this.Load += new System.EventHandler(this.Anadir_pag_Load);
            this.Shown += new System.EventHandler(this.Anadir_pag_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_palomita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_equis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_terceros;
        private System.Windows.Forms.RadioButton rdb_cliente;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Button btn_regresar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb_fe;
        private System.Windows.Forms.RadioButton rdb_control;
        private System.Windows.Forms.TextBox txt_engasolinera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_palomita;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pb_equis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_link;
        public System.Windows.Forms.ComboBox cb_link;
        public System.Windows.Forms.ComboBox cblink_permiso;
        private System.Windows.Forms.Label label6;
    }
}