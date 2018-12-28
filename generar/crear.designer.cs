namespace Checador
{
    partial class crear
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_ambos = new System.Windows.Forms.RadioButton();
            this.btn_ver = new System.Windows.Forms.Button();
            this.rdb_clientes = new System.Windows.Forms.RadioButton();
            this.btn_llenar = new System.Windows.Forms.Button();
            this.rdb_terceros = new System.Windows.Forms.RadioButton();
            this.chl_correos = new System.Windows.Forms.CheckedListBox();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_ambos);
            this.groupBox1.Controls.Add(this.btn_ver);
            this.groupBox1.Controls.Add(this.rdb_clientes);
            this.groupBox1.Controls.Add(this.btn_llenar);
            this.groupBox1.Controls.Add(this.rdb_terceros);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar excel";
            // 
            // rdb_ambos
            // 
            this.rdb_ambos.AutoSize = true;
            this.rdb_ambos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_ambos.Location = new System.Drawing.Point(26, 75);
            this.rdb_ambos.Name = "rdb_ambos";
            this.rdb_ambos.Size = new System.Drawing.Size(57, 17);
            this.rdb_ambos.TabIndex = 4;
            this.rdb_ambos.TabStop = true;
            this.rdb_ambos.Text = "Ambos";
            this.rdb_ambos.UseVisualStyleBackColor = true;
            this.rdb_ambos.CheckedChanged += new System.EventHandler(this.rdb_ambos_CheckedChanged);
            // 
            // btn_ver
            // 
            this.btn_ver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ver.Location = new System.Drawing.Point(125, 54);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(70, 20);
            this.btn_ver.TabIndex = 3;
            this.btn_ver.Text = "Ver";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // rdb_clientes
            // 
            this.rdb_clientes.AutoSize = true;
            this.rdb_clientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_clientes.Location = new System.Drawing.Point(26, 47);
            this.rdb_clientes.Name = "rdb_clientes";
            this.rdb_clientes.Size = new System.Drawing.Size(62, 17);
            this.rdb_clientes.TabIndex = 1;
            this.rdb_clientes.TabStop = true;
            this.rdb_clientes.Text = "Clientes";
            this.rdb_clientes.UseVisualStyleBackColor = true;
            this.rdb_clientes.CheckedChanged += new System.EventHandler(this.rdb_clientes_CheckedChanged);
            // 
            // btn_llenar
            // 
            this.btn_llenar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_llenar.Location = new System.Drawing.Point(125, 27);
            this.btn_llenar.Name = "btn_llenar";
            this.btn_llenar.Size = new System.Drawing.Size(70, 20);
            this.btn_llenar.TabIndex = 2;
            this.btn_llenar.Text = "LLenar ";
            this.btn_llenar.UseVisualStyleBackColor = true;
            this.btn_llenar.Click += new System.EventHandler(this.btn_llenar_Click);
            // 
            // rdb_terceros
            // 
            this.rdb_terceros.AutoSize = true;
            this.rdb_terceros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdb_terceros.Location = new System.Drawing.Point(26, 19);
            this.rdb_terceros.Name = "rdb_terceros";
            this.rdb_terceros.Size = new System.Drawing.Size(67, 17);
            this.rdb_terceros.TabIndex = 0;
            this.rdb_terceros.TabStop = true;
            this.rdb_terceros.Text = "Terceros";
            this.rdb_terceros.UseVisualStyleBackColor = true;
            this.rdb_terceros.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // chl_correos
            // 
            this.chl_correos.FormattingEnabled = true;
            this.chl_correos.Location = new System.Drawing.Point(15, 126);
            this.chl_correos.Name = "chl_correos";
            this.chl_correos.Size = new System.Drawing.Size(213, 109);
            this.chl_correos.TabIndex = 1;
            // 
            // btn_enviar
            // 
            this.btn_enviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_enviar.Location = new System.Drawing.Point(41, 245);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(70, 20);
            this.btn_enviar.TabIndex = 4;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = true;
            this.btn_enviar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cerrar.Location = new System.Drawing.Point(140, 245);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(70, 20);
            this.btn_cerrar.TabIndex = 5;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.button4_Click);
            // 
            // crear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 282);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.chl_correos);
            this.Controls.Add(this.groupBox1);
            this.Name = "crear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LLenar y enviar";
            this.Load += new System.EventHandler(this.generar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_clientes;
        private System.Windows.Forms.RadioButton rdb_terceros;
        private System.Windows.Forms.CheckedListBox chl_correos;
        private System.Windows.Forms.Button btn_llenar;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.RadioButton rdb_ambos;
    }
}