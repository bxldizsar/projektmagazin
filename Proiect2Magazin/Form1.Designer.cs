namespace Proiect2Magazin
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adaugareProduseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produsNouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produsExistentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vanzareProduseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cautareProduseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.istoricVanzariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSus = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCauta = new System.Windows.Forms.Button();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.lblCautare = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cmbFiltruCategorie = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panelSus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugareProduseToolStripMenuItem,
            this.vanzareProduseToolStripMenuItem,
            this.cautareProduseToolStripMenuItem,
            this.categoriiToolStripMenuItem,
            this.istoricVanzariToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            //
            // adaugareProduseToolStripMenuItem
            //
            this.adaugareProduseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produsNouToolStripMenuItem,
            this.produsExistentToolStripMenuItem});
            this.adaugareProduseToolStripMenuItem.Name = "adaugareProduseToolStripMenuItem";
            this.adaugareProduseToolStripMenuItem.Size = new System.Drawing.Size(171, 29);
            this.adaugareProduseToolStripMenuItem.Text = "Adaugare produse";
            //
            // produsNouToolStripMenuItem
            //
            this.produsNouToolStripMenuItem.Name = "produsNouToolStripMenuItem";
            this.produsNouToolStripMenuItem.Size = new System.Drawing.Size(360, 34);
            this.produsNouToolStripMenuItem.Text = "Produs nou";
            this.produsNouToolStripMenuItem.Click += new System.EventHandler(this.produsNouToolStripMenuItem_Click);
            //
            // produsExistentToolStripMenuItem
            //
            this.produsExistentToolStripMenuItem.Name = "produsExistentToolStripMenuItem";
            this.produsExistentToolStripMenuItem.Size = new System.Drawing.Size(360, 34);
            this.produsExistentToolStripMenuItem.Text = "Cantitate la produs existent";
            this.produsExistentToolStripMenuItem.Click += new System.EventHandler(this.produsExistentToolStripMenuItem_Click);
            //
            // vanzareProduseToolStripMenuItem
            //
            this.vanzareProduseToolStripMenuItem.Name = "vanzareProduseToolStripMenuItem";
            this.vanzareProduseToolStripMenuItem.Size = new System.Drawing.Size(158, 29);
            this.vanzareProduseToolStripMenuItem.Text = "Vanzare produse";
            this.vanzareProduseToolStripMenuItem.Click += new System.EventHandler(this.vanzareProduseToolStripMenuItem_Click);
            //
            // cautareProduseToolStripMenuItem
            //
            this.cautareProduseToolStripMenuItem.Name = "cautareProduseToolStripMenuItem";
            this.cautareProduseToolStripMenuItem.Size = new System.Drawing.Size(155, 29);
            this.cautareProduseToolStripMenuItem.Text = "Cautare produse";
            this.cautareProduseToolStripMenuItem.Click += new System.EventHandler(this.cautareProduseToolStripMenuItem_Click);
            //
            // categoriiToolStripMenuItem
            //
            this.categoriiToolStripMenuItem.Name = "categoriiToolStripMenuItem";
            this.categoriiToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.categoriiToolStripMenuItem.Text = "Categorii";
            this.categoriiToolStripMenuItem.Click += new System.EventHandler(this.categoriiToolStripMenuItem_Click);
            //
            // istoricVanzariToolStripMenuItem
            //
            this.istoricVanzariToolStripMenuItem.Name = "istoricVanzariToolStripMenuItem";
            this.istoricVanzariToolStripMenuItem.Size = new System.Drawing.Size(138, 29);
            this.istoricVanzariToolStripMenuItem.Text = "Istoric vanzari";
            this.istoricVanzariToolStripMenuItem.Click += new System.EventHandler(this.istoricVanzariToolStripMenuItem_Click);
            //
            // panelSus
            //
            this.panelSus.Controls.Add(this.cmbFiltruCategorie);
            this.panelSus.Controls.Add(this.lblCategorie);
            this.panelSus.Controls.Add(this.btnRefresh);
            this.panelSus.Controls.Add(this.btnCauta);
            this.panelSus.Controls.Add(this.txtCautare);
            this.panelSus.Controls.Add(this.lblCautare);
            this.panelSus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSus.Location = new System.Drawing.Point(0, 33);
            this.panelSus.Name = "panelSus";
            this.panelSus.Size = new System.Drawing.Size(1100, 55);
            this.panelSus.TabIndex = 1;
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1076, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnCauta
            //
            this.btnCauta.Location = new System.Drawing.Point(410, 10);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(112, 35);
            this.btnCauta.TabIndex = 2;
            this.btnCauta.Text = "Cauta";
            this.btnCauta.UseVisualStyleBackColor = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            //
            // txtCautare
            //
            this.txtCautare.Location = new System.Drawing.Point(140, 14);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(260, 26);
            this.txtCautare.TabIndex = 1;
            this.txtCautare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCautare_KeyDown);
            //
            // lblCautare
            //
            this.lblCautare.AutoSize = true;
            this.lblCautare.Location = new System.Drawing.Point(12, 17);
            this.lblCautare.Name = "lblCautare";
            this.lblCautare.Size = new System.Drawing.Size(113, 20);
            this.lblCautare.TabIndex = 0;
            this.lblCautare.Text = "Cauta produs:";
            //
            // lblCategorie
            //
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(560, 17);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(82, 20);
            this.lblCategorie.TabIndex = 4;
            this.lblCategorie.Text = "Categorie:";
            //
            // cmbFiltruCategorie
            //
            this.cmbFiltruCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltruCategorie.FormattingEnabled = true;
            this.cmbFiltruCategorie.Location = new System.Drawing.Point(650, 14);
            this.cmbFiltruCategorie.Name = "cmbFiltruCategorie";
            this.cmbFiltruCategorie.Size = new System.Drawing.Size(200, 28);
            this.cmbFiltruCategorie.TabIndex = 5;
            this.cmbFiltruCategorie.SelectedIndexChanged += new System.EventHandler(this.cmbFiltruCategorie_SelectedIndexChanged);
            //
            // dataGridView1
            //
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 88);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1100, 480);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            //
            // statusStrip1
            //
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 568);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 32);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            //
            // lblStatus
            //
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 25);
            this.lblStatus.Text = "Gata";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelSus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrare magazin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSus.ResumeLayout(false);
            this.panelSus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adaugareProduseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produsNouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produsExistentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vanzareProduseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cautareProduseToolStripMenuItem;
        private System.Windows.Forms.Panel panelSus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCauta;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.Label lblCautare;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.ComboBox cmbFiltruCategorie;
        private System.Windows.Forms.ToolStripMenuItem categoriiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem istoricVanzariToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
