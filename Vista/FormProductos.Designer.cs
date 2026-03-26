namespace Vista
{
    partial class FormProductos
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dgvProductos = new DataGridView();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSalir = new Button();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            cmbSucursal = new ComboBox();
            txtCantidadStock = new TextBox();
            btnAgregarStock = new Button();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dgvStock = new DataGridView();
            cmbProductosStock = new ComboBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(86, 256);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(266, 256);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(437, 256);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(25, 311);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(587, 245);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellClick += ddgvProductos_CellContentClick;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(219, 168);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(382, 27);
            txtDescripcion.TabIndex = 5;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(219, 215);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(125, 27);
            txtPrecio.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(219, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 80);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 9;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 175);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 10;
            label3.Text = "Descripcion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 217);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 11;
            label4.Text = "Precio";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(12, 607);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(219, 118);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(138, 28);
            cmbCategoria.TabIndex = 14;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(81, 122);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 20);
            lblCategoria.TabIndex = 15;
            lblCategoria.Text = "Categoria";
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(879, 59);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(151, 28);
            cmbSucursal.TabIndex = 16;
            cmbSucursal.SelectedIndexChanged += cmbSucursal_SelectedIndexChanged;
            // 
            // txtCantidadStock
            // 
            txtCantidadStock.Location = new Point(879, 403);
            txtCantidadStock.Name = "txtCantidadStock";
            txtCantidadStock.Size = new Size(125, 27);
            txtCantidadStock.TabIndex = 17;
            // 
            // btnAgregarStock
            // 
            btnAgregarStock.Location = new Point(828, 449);
            btnAgregarStock.Name = "btnAgregarStock";
            btnAgregarStock.Size = new Size(94, 53);
            btnAgregarStock.TabIndex = 18;
            btnAgregarStock.Text = "Agregar Stock";
            btnAgregarStock.UseVisualStyleBackColor = true;
            btnAgregarStock.Click += btnAgregarStock_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(854, 20);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 19;
            label1.Text = "Agregar Stocks";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(771, 62);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 20;
            label5.Text = "Sucursal";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(771, 406);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 21;
            label6.Text = "Cantidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(169, 20);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 22;
            label7.Text = "Productos";
            // 
            // dgvStock
            // 
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(626, 105);
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersWidth = 51;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(506, 245);
            dgvStock.TabIndex = 23;
            // 
            // cmbProductosStock
            // 
            cmbProductosStock.FormattingEnabled = true;
            cmbProductosStock.Location = new Point(879, 356);
            cmbProductosStock.Name = "cmbProductosStock";
            cmbProductosStock.Size = new Size(151, 28);
            cmbProductosStock.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(773, 364);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 25;
            label8.Text = "Producto";
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 646);
            Controls.Add(label8);
            Controls.Add(cmbProductosStock);
            Controls.Add(dgvStock);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(btnAgregarStock);
            Controls.Add(txtCantidadStock);
            Controls.Add(cmbSucursal);
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategoria);
            Controls.Add(btnSalir);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(txtPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(dgvProductos);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Name = "FormProductos";
            Text = "FormProductos";
            Load += FormProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dgvProductos;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private TextBox txtNombre;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSalir;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private ComboBox cmbSucursal;
        private TextBox txtCantidadStock;
        private Button btnAgregarStock;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgvStock;
        private ComboBox cmbProductosStock;
        private Label label8;
    }
}