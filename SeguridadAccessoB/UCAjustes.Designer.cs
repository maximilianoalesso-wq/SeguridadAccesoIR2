namespace SeguridadAccessoB
{
    partial class UCAjustes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPuertos = new System.Windows.Forms.ComboBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPuertoSel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEstadoPuerto = new System.Windows.Forms.Label();
            this.btnAbrirPuerto = new System.Windows.Forms.Button();
            this.btnCerrarPuerto = new System.Windows.Forms.Button();
            this.btnCerrarPorton = new System.Windows.Forms.Button();
            this.btnAbrirPorton = new System.Windows.Forms.Button();
            this.PuertoArduino = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerto:";
            // 
            // cbPuertos
            // 
            this.cbPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPuertos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPuertos.FormattingEnabled = true;
            this.cbPuertos.Location = new System.Drawing.Point(122, 35);
            this.cbPuertos.Name = "cbPuertos";
            this.cbPuertos.Size = new System.Drawing.Size(121, 38);
            this.cbPuertos.TabIndex = 1;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(224)))), ((int)(((byte)(239)))));
            this.btnSeleccionar.FlatAppearance.BorderSize = 3;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.DimGray;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(259, 27);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(189, 55);
            this.btnSeleccionar.TabIndex = 7;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Puerto seleccionado:";
            // 
            // lbPuertoSel
            // 
            this.lbPuertoSel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuertoSel.Location = new System.Drawing.Point(254, 86);
            this.lbPuertoSel.Name = "lbPuertoSel";
            this.lbPuertoSel.Size = new System.Drawing.Size(218, 30);
            this.lbPuertoSel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "Estado del puerto:";
            // 
            // lbEstadoPuerto
            // 
            this.lbEstadoPuerto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoPuerto.Location = new System.Drawing.Point(254, 132);
            this.lbEstadoPuerto.Name = "lbEstadoPuerto";
            this.lbEstadoPuerto.Size = new System.Drawing.Size(218, 30);
            this.lbEstadoPuerto.TabIndex = 11;
            this.lbEstadoPuerto.Text = "Puerto cerrado";
            // 
            // btnAbrirPuerto
            // 
            this.btnAbrirPuerto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(224)))), ((int)(((byte)(239)))));
            this.btnAbrirPuerto.FlatAppearance.BorderSize = 3;
            this.btnAbrirPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPuerto.ForeColor = System.Drawing.Color.DimGray;
            this.btnAbrirPuerto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrirPuerto.Location = new System.Drawing.Point(35, 174);
            this.btnAbrirPuerto.Name = "btnAbrirPuerto";
            this.btnAbrirPuerto.Size = new System.Drawing.Size(189, 55);
            this.btnAbrirPuerto.TabIndex = 12;
            this.btnAbrirPuerto.Text = "Abrir Puerto";
            this.btnAbrirPuerto.UseVisualStyleBackColor = true;
            this.btnAbrirPuerto.Click += new System.EventHandler(this.btnAbrirPuerto_Click);
            // 
            // btnCerrarPuerto
            // 
            this.btnCerrarPuerto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(224)))), ((int)(((byte)(239)))));
            this.btnCerrarPuerto.FlatAppearance.BorderSize = 3;
            this.btnCerrarPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPuerto.ForeColor = System.Drawing.Color.DimGray;
            this.btnCerrarPuerto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarPuerto.Location = new System.Drawing.Point(283, 174);
            this.btnCerrarPuerto.Name = "btnCerrarPuerto";
            this.btnCerrarPuerto.Size = new System.Drawing.Size(189, 55);
            this.btnCerrarPuerto.TabIndex = 13;
            this.btnCerrarPuerto.Text = "Cerrar Puerto";
            this.btnCerrarPuerto.UseVisualStyleBackColor = true;
            this.btnCerrarPuerto.Click += new System.EventHandler(this.btnCerrarPuerto_Click);
            // 
            // btnCerrarPorton
            // 
            this.btnCerrarPorton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(224)))), ((int)(((byte)(239)))));
            this.btnCerrarPorton.FlatAppearance.BorderSize = 3;
            this.btnCerrarPorton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPorton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPorton.ForeColor = System.Drawing.Color.DimGray;
            this.btnCerrarPorton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarPorton.Location = new System.Drawing.Point(283, 246);
            this.btnCerrarPorton.Name = "btnCerrarPorton";
            this.btnCerrarPorton.Size = new System.Drawing.Size(189, 55);
            this.btnCerrarPorton.TabIndex = 15;
            this.btnCerrarPorton.Text = "Cerrar Portón";
            this.btnCerrarPorton.UseVisualStyleBackColor = true;
            this.btnCerrarPorton.Click += new System.EventHandler(this.btnCerrarPorton_Click);
            // 
            // btnAbrirPorton
            // 
            this.btnAbrirPorton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(224)))), ((int)(((byte)(239)))));
            this.btnAbrirPorton.FlatAppearance.BorderSize = 3;
            this.btnAbrirPorton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirPorton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPorton.ForeColor = System.Drawing.Color.DimGray;
            this.btnAbrirPorton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrirPorton.Location = new System.Drawing.Point(35, 246);
            this.btnAbrirPorton.Name = "btnAbrirPorton";
            this.btnAbrirPorton.Size = new System.Drawing.Size(189, 55);
            this.btnAbrirPorton.TabIndex = 14;
            this.btnAbrirPorton.Text = "Abrir Portón";
            this.btnAbrirPorton.UseVisualStyleBackColor = true;
            this.btnAbrirPorton.Click += new System.EventHandler(this.btnAbrirPorton_Click);
            // 
            // UCAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCerrarPorton);
            this.Controls.Add(this.btnAbrirPorton);
            this.Controls.Add(this.btnCerrarPuerto);
            this.Controls.Add(this.btnAbrirPuerto);
            this.Controls.Add(this.lbEstadoPuerto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPuertoSel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.cbPuertos);
            this.Controls.Add(this.label1);
            this.Name = "UCAjustes";
            this.Size = new System.Drawing.Size(770, 388);
            this.Load += new System.EventHandler(this.UCAjustes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPuertos;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPuertoSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEstadoPuerto;
        private System.Windows.Forms.Button btnAbrirPuerto;
        private System.Windows.Forms.Button btnCerrarPuerto;
        private System.Windows.Forms.Button btnCerrarPorton;
        private System.Windows.Forms.Button btnAbrirPorton;
        private System.IO.Ports.SerialPort PuertoArduino;
    }
}
