namespace Vista
{
    partial class FormReportes
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
            dgvReportes = new DataGridView();
            btnVentasProducto = new Button();
            btnVentasPorPeriodo = new Button();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnVentasSucursal = new Button();
            label4 = new Label();
            label5 = new Label();
            btnSalir = new Button();
            btnEstadoClientes = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // dgvReportes
            // 
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(24, 153);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.RowHeadersWidth = 51;
            dgvReportes.Size = new Size(802, 269);
            dgvReportes.TabIndex = 1;
            // 
            // btnVentasProducto
            // 
            btnVentasProducto.Location = new Point(84, 58);
            btnVentasProducto.Name = "btnVentasProducto";
            btnVentasProducto.Size = new Size(108, 52);
            btnVentasProducto.TabIndex = 3;
            btnVentasProducto.Text = "Mas Vendidos";
            btnVentasProducto.UseVisualStyleBackColor = true;
            btnVentasProducto.Click += btnVentasProducto_Click;
            // 
            // btnVentasPorPeriodo
            // 
            btnVentasPorPeriodo.Location = new Point(596, 58);
            btnVentasPorPeriodo.Name = "btnVentasPorPeriodo";
            btnVentasPorPeriodo.Size = new Size(94, 51);
            btnVentasPorPeriodo.TabIndex = 6;
            btnVentasPorPeriodo.Text = "Ventas Por Fecha";
            btnVentasPorPeriodo.UseVisualStyleBackColor = true;
            btnVentasPorPeriodo.Click += btnVentasPorPeriodo_Click;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(323, 45);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(250, 27);
            dtpDesde.TabIndex = 7;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(323, 102);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(250, 27);
            dtpHasta.TabIndex = 8;
            // 
            // btnVentasSucursal
            // 
            btnVentasSucursal.Location = new Point(696, 58);
            btnVentasSucursal.Name = "btnVentasSucursal";
            btnVentasSucursal.Size = new Size(92, 51);
            btnVentasSucursal.TabIndex = 11;
            btnVentasSucursal.Text = "Ventas Por Sucursal";
            btnVentasSucursal.UseVisualStyleBackColor = true;
            btnVentasSucursal.Click += btnVentasSucursal_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(407, 15);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 12;
            label4.Text = "Desde";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(407, 73);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 13;
            label5.Text = "Hasta";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(11, 447);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEstadoClientes
            // 
            btnEstadoClientes.Location = new Point(198, 58);
            btnEstadoClientes.Name = "btnEstadoClientes";
            btnEstadoClientes.Size = new Size(93, 54);
            btnEstadoClientes.TabIndex = 16;
            btnEstadoClientes.Text = "Cuentas Corriente";
            btnEstadoClientes.UseVisualStyleBackColor = true;
            btnEstadoClientes.Click += btnEstadoClientes_Click;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 496);
            Controls.Add(btnEstadoClientes);
            Controls.Add(btnSalir);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnVentasSucursal);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(btnVentasPorPeriodo);
            Controls.Add(btnVentasProducto);
            Controls.Add(dgvReportes);
            Name = "FormReportes";
            Text = "FormReportes";
            Load += FormReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvReportes;
        private Button btnVentasProducto;
        private Button btnVentasPorPeriodo;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnVentasSucursal;
        private Label label4;
        private Label label5;
        private Button btnSalir;
        private Button button1;
        private Button btnEstadoClientes;
    }
}