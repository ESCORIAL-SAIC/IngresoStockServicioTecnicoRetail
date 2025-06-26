namespace IngresoStockServicioTecnicoRetail
{
    partial class FrmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtNumeroSerie = new TextBox();
            LblTitulo = new Label();
            BtnAceptar = new Button();
            TxtPlacaMarcado = new TextBox();
            LblPlacaMarcado = new Label();
            GpbIngreso = new GroupBox();
            DgvItemsIngresados = new DataGridView();
            NumeroDocumento = new DataGridViewTextBoxColumn();
            CodigoProducto = new DataGridViewTextBoxColumn();
            Serie = new DataGridViewTextBoxColumn();
            GpbIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvItemsIngresados).BeginInit();
            SuspendLayout();
            // 
            // TxtNumeroSerie
            // 
            TxtNumeroSerie.Location = new Point(6, 44);
            TxtNumeroSerie.Name = "TxtNumeroSerie";
            TxtNumeroSerie.Size = new Size(312, 23);
            TxtNumeroSerie.TabIndex = 0;
            TxtNumeroSerie.KeyDown += TxtNumeroSerie_KeyDown;
            // 
            // LblTitulo
            // 
            LblTitulo.AutoSize = true;
            LblTitulo.Location = new Point(6, 26);
            LblTitulo.Name = "LblTitulo";
            LblTitulo.Size = new Size(85, 15);
            LblTitulo.TabIndex = 1;
            LblTitulo.Text = "Etiqueta retail: ";
            // 
            // BtnAceptar
            // 
            BtnAceptar.Location = new Point(391, 479);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(75, 23);
            BtnAceptar.TabIndex = 2;
            BtnAceptar.Text = "Aceptar";
            BtnAceptar.UseVisualStyleBackColor = true;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // TxtPlacaMarcado
            // 
            TxtPlacaMarcado.Location = new Point(6, 97);
            TxtPlacaMarcado.Name = "TxtPlacaMarcado";
            TxtPlacaMarcado.Size = new Size(312, 23);
            TxtPlacaMarcado.TabIndex = 3;
            TxtPlacaMarcado.KeyDown += TxtPlacaMarcado_KeyDown;
            // 
            // LblPlacaMarcado
            // 
            LblPlacaMarcado.AutoSize = true;
            LblPlacaMarcado.Location = new Point(6, 79);
            LblPlacaMarcado.Name = "LblPlacaMarcado";
            LblPlacaMarcado.Size = new Size(104, 15);
            LblPlacaMarcado.TabIndex = 4;
            LblPlacaMarcado.Text = "Placa de marcado:";
            // 
            // GpbIngreso
            // 
            GpbIngreso.Controls.Add(DgvItemsIngresados);
            GpbIngreso.Controls.Add(TxtPlacaMarcado);
            GpbIngreso.Controls.Add(LblPlacaMarcado);
            GpbIngreso.Controls.Add(TxtNumeroSerie);
            GpbIngreso.Controls.Add(LblTitulo);
            GpbIngreso.Location = new Point(12, 12);
            GpbIngreso.Name = "GpbIngreso";
            GpbIngreso.Size = new Size(454, 461);
            GpbIngreso.TabIndex = 5;
            GpbIngreso.TabStop = false;
            GpbIngreso.Text = "Ingreso";
            // 
            // DgvItemsIngresados
            // 
            DgvItemsIngresados.AllowUserToAddRows = false;
            DgvItemsIngresados.AllowUserToDeleteRows = false;
            DgvItemsIngresados.AllowUserToResizeColumns = false;
            DgvItemsIngresados.AllowUserToResizeRows = false;
            DgvItemsIngresados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvItemsIngresados.Columns.AddRange(new DataGridViewColumn[] { NumeroDocumento, CodigoProducto, Serie });
            DgvItemsIngresados.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvItemsIngresados.Location = new Point(6, 127);
            DgvItemsIngresados.MultiSelect = false;
            DgvItemsIngresados.Name = "DgvItemsIngresados";
            DgvItemsIngresados.Size = new Size(442, 328);
            DgvItemsIngresados.TabIndex = 6;
            // 
            // NumeroDocumento
            // 
            NumeroDocumento.HeaderText = "Documento";
            NumeroDocumento.Name = "NumeroDocumento";
            // 
            // CodigoProducto
            // 
            CodigoProducto.HeaderText = "Producto";
            CodigoProducto.Name = "CodigoProducto";
            // 
            // Serie
            // 
            Serie.HeaderText = "Serie";
            Serie.Name = "Serie";
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 514);
            Controls.Add(GpbIngreso);
            Controls.Add(BtnAceptar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmInicio";
            Text = "Ingreso Retail";
            GpbIngreso.ResumeLayout(false);
            GpbIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvItemsIngresados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtNumeroSerie;
        private Label LblTitulo;
        private Button BtnAceptar;
        private TextBox TxtPlacaMarcado;
        private Label LblPlacaMarcado;
        private GroupBox GpbIngreso;
        private DataGridView DgvItemsIngresados;
        private DataGridViewTextBoxColumn NumeroDocumento;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn Serie;
    }
}
