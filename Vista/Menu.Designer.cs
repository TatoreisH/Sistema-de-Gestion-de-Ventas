namespace Vista
{
    partial class Menu
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
            btnProducto = new Button();
            btnCategoria = new Button();
            btnCliente = new Button();
            btnSucursal = new Button();
            btnReportes = new Button();
            btnVentas = new Button();
            lblTechStore = new Label();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnProducto
            // 
            btnProducto.Location = new Point(149, 152);
            btnProducto.Margin = new Padding(3, 4, 3, 4);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(714, 56);
            btnProducto.TabIndex = 0;
            btnProducto.Text = "Producto";
            btnProducto.UseVisualStyleBackColor = true;
            btnProducto.Click += btnProducto_Click;
            // 
            // btnCategoria
            // 
            btnCategoria.Location = new Point(149, 216);
            btnCategoria.Margin = new Padding(3, 4, 3, 4);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Size = new Size(714, 56);
            btnCategoria.TabIndex = 1;
            btnCategoria.Text = "Categoria del producto";
            btnCategoria.UseVisualStyleBackColor = true;
            btnCategoria.Click += btnCategoria_Click;
            // 
            // btnCliente
            // 
            btnCliente.Location = new Point(149, 280);
            btnCliente.Margin = new Padding(3, 4, 3, 4);
            btnCliente.Name = "btnCliente";
            btnCliente.Size = new Size(714, 56);
            btnCliente.TabIndex = 2;
            btnCliente.Text = "Agregar cliente";
            btnCliente.UseVisualStyleBackColor = true;
            btnCliente.Click += btnCliente_Click;
            // 
            // btnSucursal
            // 
            btnSucursal.Location = new Point(149, 344);
            btnSucursal.Margin = new Padding(3, 4, 3, 4);
            btnSucursal.Name = "btnSucursal";
            btnSucursal.Size = new Size(714, 56);
            btnSucursal.TabIndex = 3;
            btnSucursal.Text = "Agregar sucursales";
            btnSucursal.UseVisualStyleBackColor = true;
            btnSucursal.Click += btnSucursal_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(149, 472);
            btnReportes.Margin = new Padding(3, 4, 3, 4);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(714, 56);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Ver Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(149, 408);
            btnVentas.Margin = new Padding(3, 4, 3, 4);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(714, 56);
            btnVentas.TabIndex = 5;
            btnVentas.Text = "Ver ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // lblTechStore
            // 
            lblTechStore.AutoSize = true;
            lblTechStore.BackColor = Color.Transparent;
            lblTechStore.Font = new Font("Impact", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTechStore.ForeColor = SystemColors.ActiveCaption;
            lblTechStore.Location = new Point(405, 55);
            lblTechStore.Name = "lblTechStore";
            lblTechStore.Size = new Size(216, 48);
            lblTechStore.TabIndex = 6;
            lblTechStore.Text = "TECH STORE";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(14, 687);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(137, 45);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 748);
            Controls.Add(btnSalir);
            Controls.Add(lblTechStore);
            Controls.Add(btnVentas);
            Controls.Add(btnReportes);
            Controls.Add(btnSucursal);
            Controls.Add(btnCliente);
            Controls.Add(btnCategoria);
            Controls.Add(btnProducto);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProducto;
        private Button btnCategoria;
        private Button btnCliente;
        private Button btnSucursal;
        private Button btnReportes;
        private Button btnVentas;
        private Label lblTechStore;
        private Button btnSalir;
    }
}