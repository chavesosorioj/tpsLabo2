namespace Chaves.Juliana._2D.TP4
{
    partial class FrmMostrar
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
            this.DgwPasajes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgwPasajes)).BeginInit();
            this.SuspendLayout();
            // 
            // DgwPasajes
            // 
            this.DgwPasajes.AllowUserToAddRows = false;
            this.DgwPasajes.AllowUserToDeleteRows = false;
            this.DgwPasajes.AllowUserToResizeColumns = false;
            this.DgwPasajes.AllowUserToResizeRows = false;
            this.DgwPasajes.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.DgwPasajes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgwPasajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgwPasajes.GridColor = System.Drawing.Color.Plum;
            this.DgwPasajes.Location = new System.Drawing.Point(12, 44);
            this.DgwPasajes.Name = "DgwPasajes";
            this.DgwPasajes.Size = new System.Drawing.Size(653, 197);
            this.DgwPasajes.TabIndex = 0;
            // 
            // FrmMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(677, 298);
            this.Controls.Add(this.DgwPasajes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMostrar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMostrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgwPasajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgwPasajes;
    }
}