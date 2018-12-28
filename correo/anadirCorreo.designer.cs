namespace Checador
{
    partial class anadirCorreo
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
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.gb_genero = new System.Windows.Forms.GroupBox();
            this.rdb_mujer = new System.Windows.Forms.RadioButton();
            this.rdb_hombre = new System.Windows.Forms.RadioButton();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.txt_ape = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_referencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inf_email = new System.Windows.Forms.ToolTip(this.components);
            this.txt_numTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gb_genero.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_nom
            // 
            this.txt_nom.Location = new System.Drawing.Point(15, 27);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(272, 20);
            this.txt_nom.TabIndex = 0;
            this.inf_email.SetToolTip(this.txt_nom, "Ingrese los nombres de la personar a registrar.");
            this.txt_nom.TextChanged += new System.EventHandler(this.txt_nom_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nombre(s)";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.Location = new System.Drawing.Point(192, 295);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 37);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_registrar
            // 
            this.btn_registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_registrar.Location = new System.Drawing.Point(192, 247);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 37);
            this.btn_registrar.TabIndex = 7;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // gb_genero
            // 
            this.gb_genero.Controls.Add(this.rdb_mujer);
            this.gb_genero.Controls.Add(this.rdb_hombre);
            this.gb_genero.Location = new System.Drawing.Point(29, 233);
            this.gb_genero.Name = "gb_genero";
            this.gb_genero.Size = new System.Drawing.Size(105, 99);
            this.gb_genero.TabIndex = 6;
            this.gb_genero.TabStop = false;
            this.gb_genero.Text = "Genero";
            this.inf_email.SetToolTip(this.gb_genero, "Seleccione genero de la persona que se\r\nesta registrando.");
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
            this.txt_correo.Location = new System.Drawing.Point(15, 156);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(272, 20);
            this.txt_correo.TabIndex = 3;
            this.inf_email.SetToolTip(this.txt_correo, "Ingrese el correo electronico de la persona\r\na registrar.");
            // 
            // txt_ape
            // 
            this.txt_ape.Location = new System.Drawing.Point(15, 70);
            this.txt_ape.Name = "txt_ape";
            this.txt_ape.Size = new System.Drawing.Size(272, 20);
            this.txt_ape.TabIndex = 1;
            this.inf_email.SetToolTip(this.txt_ape, "Ingrese el apellido o los apellidos de la persona\r\na registrar.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Correo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Apellidos";
            // 
            // txt_referencia
            // 
            this.txt_referencia.Location = new System.Drawing.Point(15, 113);
            this.txt_referencia.Name = "txt_referencia";
            this.txt_referencia.Size = new System.Drawing.Size(272, 20);
            this.txt_referencia.TabIndex = 2;
            this.inf_email.SetToolTip(this.txt_referencia, "Ingrese la referencia de  la persona, ej. \"GT Soluciones\".");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Referencia";
            // 
            // txt_numTel
            // 
            this.txt_numTel.Location = new System.Drawing.Point(14, 207);
            this.txt_numTel.MaxLength = 10;
            this.txt_numTel.Name = "txt_numTel";
            this.txt_numTel.Size = new System.Drawing.Size(272, 20);
            this.txt_numTel.TabIndex = 5;
            this.inf_email.SetToolTip(this.txt_numTel, "Ingrese el correo electronico de la persona\r\na registrar.");
            this.txt_numTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_numTel_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Numero de telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Apellidos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Correo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Nombre(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Referencia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Número de teléfono ";
            // 
            // anadirCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 354);
            this.ControlBox = false;
            this.Controls.Add(this.txt_numTel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_referencia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.gb_genero);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_ape);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "anadirCorreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar contacto";
            this.Load += new System.EventHandler(this.anadirCorreo_Load);
            this.gb_genero.ResumeLayout(false);
            this.gb_genero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.GroupBox gb_genero;
        private System.Windows.Forms.RadioButton rdb_mujer;
        private System.Windows.Forms.RadioButton rdb_hombre;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.TextBox txt_ape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip inf_email;
        private System.Windows.Forms.TextBox txt_referencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_numTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}