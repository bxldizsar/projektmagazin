namespace Proiect2Magazin
{
    partial class FormAdaugare
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
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblDenumire = new System.Windows.Forms.Label();
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.lblDescriere = new System.Windows.Forms.Label();
            this.txtDescriere = new System.Windows.Forms.TextBox();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.lblIntrare = new System.Windows.Forms.Label();
            this.dtpIntrare = new System.Windows.Forms.DateTimePicker();
            this.lblExpirare = new System.Windows.Forms.Label();
            this.dtpExpirare = new System.Windows.Forms.DateTimePicker();
            this.lblCantitate = new System.Windows.Forms.Label();
            this.numCantitate = new System.Windows.Forms.NumericUpDown();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).BeginInit();
            this.SuspendLayout();
            //
            // lblId
            //
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(83, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id produs:";
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(200, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(120, 26);
            this.txtId.TabIndex = 1;
            //
            // lblDenumire
            //
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(20, 63);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(82, 20);
            this.lblDenumire.TabIndex = 2;
            this.lblDenumire.Text = "Denumire:";
            //
            // txtDenumire
            //
            this.txtDenumire.Location = new System.Drawing.Point(200, 60);
            this.txtDenumire.MaxLength = 30;
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(290, 26);
            this.txtDenumire.TabIndex = 3;
            //
            // lblDescriere
            //
            this.lblDescriere.AutoSize = true;
            this.lblDescriere.Location = new System.Drawing.Point(20, 103);
            this.lblDescriere.Name = "lblDescriere";
            this.lblDescriere.Size = new System.Drawing.Size(81, 20);
            this.lblDescriere.TabIndex = 4;
            this.lblDescriere.Text = "Descriere:";
            //
            // txtDescriere
            //
            this.txtDescriere.Location = new System.Drawing.Point(200, 100);
            this.txtDescriere.MaxLength = 500;
            this.txtDescriere.Multiline = true;
            this.txtDescriere.Name = "txtDescriere";
            this.txtDescriere.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescriere.Size = new System.Drawing.Size(290, 100);
            this.txtDescriere.TabIndex = 5;
            //
            // lblCategorie
            //
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(20, 218);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(82, 20);
            this.lblCategorie.TabIndex = 14;
            this.lblCategorie.Text = "Categorie:";
            //
            // cmbCategorie
            //
            this.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(200, 215);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(290, 28);
            this.cmbCategorie.TabIndex = 6;
            //
            // lblIntrare
            //
            this.lblIntrare.AutoSize = true;
            this.lblIntrare.Location = new System.Drawing.Point(20, 258);
            this.lblIntrare.Name = "lblIntrare";
            this.lblIntrare.Size = new System.Drawing.Size(104, 20);
            this.lblIntrare.TabIndex = 6;
            this.lblIntrare.Text = "Data intrarii:";
            //
            // dtpIntrare
            //
            this.dtpIntrare.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIntrare.Location = new System.Drawing.Point(200, 255);
            this.dtpIntrare.Name = "dtpIntrare";
            this.dtpIntrare.Size = new System.Drawing.Size(160, 26);
            this.dtpIntrare.TabIndex = 7;
            //
            // lblExpirare
            //
            this.lblExpirare.AutoSize = true;
            this.lblExpirare.Location = new System.Drawing.Point(20, 298);
            this.lblExpirare.Name = "lblExpirare";
            this.lblExpirare.Size = new System.Drawing.Size(117, 20);
            this.lblExpirare.TabIndex = 8;
            this.lblExpirare.Text = "Data expirarii:";
            //
            // dtpExpirare
            //
            this.dtpExpirare.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpirare.Location = new System.Drawing.Point(200, 295);
            this.dtpExpirare.Name = "dtpExpirare";
            this.dtpExpirare.Size = new System.Drawing.Size(160, 26);
            this.dtpExpirare.TabIndex = 9;
            //
            // lblCantitate
            //
            this.lblCantitate.AutoSize = true;
            this.lblCantitate.Location = new System.Drawing.Point(20, 338);
            this.lblCantitate.Name = "lblCantitate";
            this.lblCantitate.Size = new System.Drawing.Size(76, 20);
            this.lblCantitate.TabIndex = 10;
            this.lblCantitate.Text = "Cantitate:";
            //
            // numCantitate
            //
            this.numCantitate.Location = new System.Drawing.Point(200, 336);
            this.numCantitate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCantitate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantitate.Name = "numCantitate";
            this.numCantitate.Size = new System.Drawing.Size(120, 26);
            this.numCantitate.TabIndex = 11;
            this.numCantitate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // btnSalvare
            //
            this.btnSalvare.Location = new System.Drawing.Point(258, 390);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(112, 35);
            this.btnSalvare.TabIndex = 12;
            this.btnSalvare.Text = "Salvare";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            //
            // btnAnulare
            //
            this.btnAnulare.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnulare.Location = new System.Drawing.Point(378, 390);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(112, 35);
            this.btnAnulare.TabIndex = 13;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.UseVisualStyleBackColor = true;
            //
            // FormAdaugare
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnulare;
            this.ClientSize = new System.Drawing.Size(520, 445);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.numCantitate);
            this.Controls.Add(this.lblCantitate);
            this.Controls.Add(this.dtpExpirare);
            this.Controls.Add(this.lblExpirare);
            this.Controls.Add(this.cmbCategorie);
            this.Controls.Add(this.lblCategorie);
            this.Controls.Add(this.dtpIntrare);
            this.Controls.Add(this.lblIntrare);
            this.Controls.Add(this.txtDescriere);
            this.Controls.Add(this.lblDescriere);
            this.Controls.Add(this.txtDenumire);
            this.Controls.Add(this.lblDenumire);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdaugare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adaugare produs";
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblDenumire;
        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.Label lblDescriere;
        private System.Windows.Forms.TextBox txtDescriere;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Label lblIntrare;
        private System.Windows.Forms.DateTimePicker dtpIntrare;
        private System.Windows.Forms.Label lblExpirare;
        private System.Windows.Forms.DateTimePicker dtpExpirare;
        private System.Windows.Forms.Label lblCantitate;
        private System.Windows.Forms.NumericUpDown numCantitate;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAnulare;
    }
}
