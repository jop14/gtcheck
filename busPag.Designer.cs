namespace Checador
{
    partial class busPag
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
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_bus)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_idbusc);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dg_bus);
            this.groupBox3.Controls.Add(this.btn_bus);
            this.groupBox3.Location = new System.Drawing.Point(0, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 203);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscador";
            // 
            // txt_idbusc
            // 
            this.txt_idbusc.Location = new System.Drawing.Point(10, 19);
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
            this.dg_bus.Location = new System.Drawing.Point(3, 63);
            this.dg_bus.MultiSelect = false;
            this.dg_bus.Name = "dg_bus";
            this.dg_bus.ReadOnly = true;
            this.dg_bus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dg_bus.RowHeadersVisible = false;
            this.dg_bus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_bus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_bus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_bus.Size = new System.Drawing.Size(279, 137);
            this.dg_bus.StandardTab = true;
            this.dg_bus.TabIndex = 2;
            this.dg_bus.VirtualMode = true;
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
            // btn_cancelar
            // 
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.Location = new System.Drawing.Point(104, 226);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cerrar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // busPag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "busPag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar pagina";
            this.Load += new System.EventHandler(this.busPag_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_bus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_idbusc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dg_bus;
        private System.Windows.Forms.Button btn_bus;
        private System.Windows.Forms.Button btn_cancelar;
    }
}