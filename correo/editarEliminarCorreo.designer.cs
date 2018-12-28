namespace Checador
{
    partial class editarEliminarCorreo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_idbusc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dg_bus = new System.Windows.Forms.DataGridView();
            this.btn_bus = new System.Windows.Forms.Button();
            this.txt_numTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_referencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_genero = new System.Windows.Forms.GroupBox();
            this.rdb_mujer = new System.Windows.Forms.RadioButton();
            this.rdb_hombre = new System.Windows.Forms.RadioButton();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.txt_ape = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_regresar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_bus)).BeginInit();
            this.gb_genero.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_idbusc);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dg_bus);
            this.groupBox3.Controls.Add(this.btn_bus);
            this.groupBox3.Location = new System.Drawing.Point(0, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 149);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscador";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txt_idbusc
            // 
            this.txt_idbusc.Location = new System.Drawing.Point(8, 19);
            this.txt_idbusc.MaxLength = 50;
            this.txt_idbusc.Name = "txt_idbusc";
            this.txt_idbusc.Size = new System.Drawing.Size(191, 20);
            this.txt_idbusc.TabIndex = 4;
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
            this.btn_bus.Location = new System.Drawing.Point(204, 17);
            this.btn_bus.Name = "btn_bus";
            this.btn_bus.Size = new System.Drawing.Size(75, 23);
            this.btn_bus.TabIndex = 1;
            this.btn_bus.Text = "Buscar";
            this.btn_bus.UseVisualStyleBackColor = true;
            this.btn_bus.Click += new System.EventHandler(this.btn_bus_Click);
            // 
            // txt_numTel
            // 
            this.txt_numTel.Location = new System.Drawing.Point(6, 342);
            this.txt_numTel.Name = "txt_numTel";
            this.txt_numTel.Size = new System.Drawing.Size(272, 20);
            this.txt_numTel.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Número de teléfono ";
            // 
            // txt_referencia
            // 
            this.txt_referencia.Location = new System.Drawing.Point(6, 258);
            this.txt_referencia.Name = "txt_referencia";
            this.txt_referencia.Size = new System.Drawing.Size(272, 20);
            this.txt_referencia.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Referencia";
            // 
            // txt_nom
            // 
            this.txt_nom.Location = new System.Drawing.Point(6, 172);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(272, 20);
            this.txt_nom.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Nombre(s)";
            // 
            // gb_genero
            // 
            this.gb_genero.Controls.Add(this.rdb_mujer);
            this.gb_genero.Controls.Add(this.rdb_hombre);
            this.gb_genero.Location = new System.Drawing.Point(22, 374);
            this.gb_genero.Name = "gb_genero";
            this.gb_genero.Size = new System.Drawing.Size(105, 99);
            this.gb_genero.TabIndex = 39;
            this.gb_genero.TabStop = false;
            this.gb_genero.Text = "Genero";
            // 
            // rdb_mujer
            // 
            this.rdb_mujer.AutoSize = true;
            this.rdb_mujer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_mujer.Location = new System.Drawing.Point(25, 65);
            this.rdb_mujer.Name = "rdb_mujer";
            this.rdb_mujer.Size = new System.Drawing.Size(51, 17);
            this.rdb_mujer.TabIndex = 1;
            this.rdb_mujer.Text = "Mujer";
            this.rdb_mujer.UseVisualStyleBackColor = true;
            // 
            // rdb_hombre
            // 
            this.rdb_hombre.AutoSize = true;
            this.rdb_hombre.Checked = true;
            this.rdb_hombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_hombre.Location = new System.Drawing.Point(25, 30);
            this.rdb_hombre.Name = "rdb_hombre";
            this.rdb_hombre.Size = new System.Drawing.Size(62, 17);
            this.rdb_hombre.TabIndex = 0;
            this.rdb_hombre.TabStop = true;
            this.rdb_hombre.Text = "Hombre";
            this.rdb_hombre.UseVisualStyleBackColor = true;
            // 
            // txt_correo
            // 
            this.txt_correo.Location = new System.Drawing.Point(6, 301);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(272, 20);
            this.txt_correo.TabIndex = 38;
            // 
            // txt_ape
            // 
            this.txt_ape.Location = new System.Drawing.Point(6, 215);
            this.txt_ape.Name = "txt_ape";
            this.txt_ape.Size = new System.Drawing.Size(272, 20);
            this.txt_ape.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Correo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Apellidos";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminar.Location = new System.Drawing.Point(166, 413);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 50;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_regresar
            // 
            this.btn_regresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_regresar.Location = new System.Drawing.Point(166, 442);
            this.btn_regresar.Name = "btn_regresar";
            this.btn_regresar.Size = new System.Drawing.Size(75, 23);
            this.btn_regresar.TabIndex = 51;
            this.btn_regresar.Text = "Cerrar";
            this.btn_regresar.UseVisualStyleBackColor = true;
            this.btn_regresar.Click += new System.EventHandler(this.btn_regresar_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_actualizar.Location = new System.Drawing.Point(166, 384);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(75, 23);
            this.btn_actualizar.TabIndex = 49;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // editarEliminarCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 485);
            this.ControlBox = false;
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_regresar);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.txt_numTel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_referencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_genero);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.txt_ape);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editarEliminarCorreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar/Eliminar contacto";
            this.Load += new System.EventHandler(this.editarEliminarCorreo_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_bus)).EndInit();
            this.gb_genero.ResumeLayout(false);
            this.gb_genero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_idbusc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dg_bus;
        private System.Windows.Forms.Button btn_bus;
        private System.Windows.Forms.TextBox txt_numTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_referencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_genero;
        private System.Windows.Forms.RadioButton rdb_mujer;
        private System.Windows.Forms.RadioButton rdb_hombre;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.TextBox txt_ape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_regresar;
        private System.Windows.Forms.Button btn_actualizar;
    }
}