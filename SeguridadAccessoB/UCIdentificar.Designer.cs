namespace SeguridadAccessoB
{
    partial class UCIdentificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCIdentificar));
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbTemp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHuella
            // 
            this.pbHuella.Image = ((System.Drawing.Image)(resources.GetObject("pbHuella.Image")));
            this.pbHuella.Location = new System.Drawing.Point(28, 53);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(186, 228);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHuella.TabIndex = 0;
            this.pbHuella.TabStop = false;
            // 
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(526, 64);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(48, 46);
            this.pbIcon.TabIndex = 1;
            this.pbIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(220, 72);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(300, 38);
            this.lbTitulo.TabIndex = 3;
            this.lbTitulo.Text = "CAPTURANDO";
            // 
            // lbNombre
            // 
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(239, 125);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(300, 38);
            this.lbNombre.TabIndex = 4;
            this.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTemp
            // 
            this.lbTemp.Font = new System.Drawing.Font("Segoe UI", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemp.Location = new System.Drawing.Point(344, 171);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(97, 156);
            this.lbTemp.TabIndex = 5;
            this.lbTemp.Text = "1";
            this.lbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCIdentificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTemp);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.pbHuella);
            this.Name = "UCIdentificar";
            this.Size = new System.Drawing.Size(638, 364);
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHuella;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbTemp;
    }
}
