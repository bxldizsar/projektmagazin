namespace Proiect2Magazin
{
    partial class FormCategorii
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
            this.lstCategorii = new System.Windows.Forms.ListBox();
            this.lblDenumire = new System.Windows.Forms.Label();
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnRedenumeste = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnInchide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lstCategorii
            //
            this.lstCategorii.FormattingEnabled = true;
            this.lstCategorii.ItemHeight = 20;
            this.lstCategorii.Location = new System.Drawing.Point(20, 20);
            this.lstCategorii.Name = "lstCategorii";
            this.lstCategorii.Size = new System.Drawing.Size(250, 284);
            this.lstCategorii.TabIndex = 0;
            this.lstCategorii.SelectedIndexChanged += new System.EventHandler(this.lstCategorii_SelectedIndexChanged);
            //
            // lblDenumire
            //
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(290, 20);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(82, 20);
            this.lblDenumire.TabIndex = 1;
            this.lblDenumire.Text = "Denumire:";
            //
            // txtDenumire
            //
            this.txtDenumire.Location = new System.Drawing.Point(290, 45);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(150, 26);
            this.txtDenumire.TabIndex = 2;
            //
            // btnAdauga
            //
            this.btnAdauga.Location = new System.Drawing.Point(290, 90);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(150, 35);
            this.btnAdauga.TabIndex = 3;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            //
            // btnRedenumeste
            //
            this.btnRedenumeste.Location = new System.Drawing.Point(290, 135);
            this.btnRedenumeste.Name = "btnRedenumeste";
            this.btnRedenumeste.Size = new System.Drawing.Size(150, 35);
            this.btnRedenumeste.TabIndex = 4;
            this.btnRedenumeste.Text = "Redenumeste";
            this.btnRedenumeste.UseVisualStyleBackColor = true;
            this.btnRedenumeste.Click += new System.EventHandler(this.btnRedenumeste_Click);
            //
            // btnSterge
            //
            this.btnSterge.Location = new System.Drawing.Point(290, 180);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(150, 35);
            this.btnSterge.TabIndex = 5;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            //
            // btnInchide
            //
            this.btnInchide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnInchide.Location = new System.Drawing.Point(290, 269);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(150, 35);
            this.btnInchide.TabIndex = 6;
            this.btnInchide.Text = "Inchide";
            this.btnInchide.UseVisualStyleBackColor = true;
            //
            // FormCategorii
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnInchide;
            this.ClientSize = new System.Drawing.Size(460, 325);
            this.Controls.Add(this.btnInchide);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnRedenumeste);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.txtDenumire);
            this.Controls.Add(this.lblDenumire);
            this.Controls.Add(this.lstCategorii);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCategorii";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Categorii de produse";
            this.Load += new System.EventHandler(this.FormCategorii_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCategorii;
        private System.Windows.Forms.Label lblDenumire;
        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnRedenumeste;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnInchide;
    }
}
