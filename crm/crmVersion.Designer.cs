namespace Checador
{
    partial class crmVersion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtg_vista = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRUPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_crm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_version = new System.Windows.Forms.Label();
            this.cb_combo = new System.Windows.Forms.ComboBox();
            this.rdb_terceros = new System.Windows.Forms.RadioButton();
            this.rdb_clientes = new System.Windows.Forms.RadioButton();
            this.rdb_general = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vista)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtg_vista
            // 
            this.dtg_vista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_vista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtg_vista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_vista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.GRUPO,
            this.NOMBRE,
            this.HORA,
            this.TIPO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_vista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_vista.Location = new System.Drawing.Point(12, 62);
            this.dtg_vista.Name = "dtg_vista";
            this.dtg_vista.ReadOnly = true;
            this.dtg_vista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_vista.Size = new System.Drawing.Size(605, 541);
            this.dtg_vista.TabIndex = 0;
            this.dtg_vista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_vista_CellContentClick);
            this.dtg_vista.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_vista_CellMouseDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // GRUPO
            // 
            this.GRUPO.DataPropertyName = "GRUPO";
            this.GRUPO.HeaderText = "GRUPO";
            this.GRUPO.Name = "GRUPO";
            this.GRUPO.ReadOnly = true;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            // 
            // HORA
            // 
            this.HORA.DataPropertyName = "HORA";
            this.HORA.HeaderText = "HORA";
            this.HORA.Name = "HORA";
            this.HORA.ReadOnly = true;
            // 
            // TIPO
            // 
            this.TIPO.DataPropertyName = "TIPO";
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            // 
            // btn_crm
            // 
            this.btn_crm.BackColor = System.Drawing.Color.Transparent;
            this.btn_crm.BackgroundImage = global::Checador.Properties.Resources.email;
            this.btn_crm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_crm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_crm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_crm.FlatAppearance.BorderSize = 0;
            this.btn_crm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_crm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crm.Location = new System.Drawing.Point(551, 0);
            this.btn_crm.Name = "btn_crm";
            this.btn_crm.Size = new System.Drawing.Size(65, 70);
            this.btn_crm.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btn_crm, "Enviar al CRM");
            this.btn_crm.UseVisualStyleBackColor = false;
            this.btn_crm.Click += new System.EventHandler(this.btn_crm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_version);
            this.groupBox1.Controls.Add(this.cb_combo);
            this.groupBox1.Controls.Add(this.rdb_terceros);
            this.groupBox1.Controls.Add(this.rdb_clientes);
            this.groupBox1.Controls.Add(this.rdb_general);
            this.groupBox1.Location = new System.Drawing.Point(18, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 52);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vista de reporte";
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(357, 25);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(42, 13);
            this.lbl_version.TabIndex = 4;
            this.lbl_version.Text = "Version";
            // 
            // cb_combo
            // 
            this.cb_combo.DisplayMember = "version";
            this.cb_combo.FormattingEnabled = true;
            this.cb_combo.Location = new System.Drawing.Point(403, 21);
            this.cb_combo.Name = "cb_combo";
            this.cb_combo.Size = new System.Drawing.Size(121, 21);
            this.cb_combo.TabIndex = 3;
            this.cb_combo.ValueMember = "version";
            this.cb_combo.SelectedIndexChanged += new System.EventHandler(this.cb_combo_SelectedIndexChanged);
            // 
            // rdb_terceros
            // 
            this.rdb_terceros.AutoSize = true;
            this.rdb_terceros.Location = new System.Drawing.Point(190, 23);
            this.rdb_terceros.Name = "rdb_terceros";
            this.rdb_terceros.Size = new System.Drawing.Size(67, 17);
            this.rdb_terceros.TabIndex = 2;
            this.rdb_terceros.Text = "Terceros";
            this.rdb_terceros.UseVisualStyleBackColor = true;
            this.rdb_terceros.CheckedChanged += new System.EventHandler(this.rdb_terceros_CheckedChanged);
            // 
            // rdb_clientes
            // 
            this.rdb_clientes.AutoSize = true;
            this.rdb_clientes.Location = new System.Drawing.Point(109, 24);
            this.rdb_clientes.Name = "rdb_clientes";
            this.rdb_clientes.Size = new System.Drawing.Size(62, 17);
            this.rdb_clientes.TabIndex = 1;
            this.rdb_clientes.Text = "Clientes";
            this.rdb_clientes.UseVisualStyleBackColor = true;
            this.rdb_clientes.CheckedChanged += new System.EventHandler(this.rdb_clientes_CheckedChanged);
            // 
            // rdb_general
            // 
            this.rdb_general.AutoSize = true;
            this.rdb_general.Checked = true;
            this.rdb_general.Location = new System.Drawing.Point(23, 24);
            this.rdb_general.Name = "rdb_general";
            this.rdb_general.Size = new System.Drawing.Size(62, 17);
            this.rdb_general.TabIndex = 0;
            this.rdb_general.TabStop = true;
            this.rdb_general.Text = "General";
            this.rdb_general.UseVisualStyleBackColor = true;
            this.rdb_general.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // crmVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 615);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtg_vista);
            this.Controls.Add(this.btn_crm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "crmVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket\'s por version";
            this.Load += new System.EventHandler(this.pag_caidasdia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vista)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_vista;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_terceros;
        private System.Windows.Forms.RadioButton rdb_clientes;
        private System.Windows.Forms.RadioButton rdb_general;
        private System.Windows.Forms.Button btn_crm;
        private System.Windows.Forms.ComboBox cb_combo;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRUPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
    }
}