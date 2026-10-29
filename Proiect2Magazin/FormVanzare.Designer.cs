namespace Proiect2Magazin
{
    partial class FormVanzare
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIdVal = new System.Windows.Forms.Label();
            this.lblDenumireVal = new System.Windows.Forms.Label();
            this.lblDescriereVal = new System.Windows.Forms.Label();
            this.lblExpirareVal = new System.Windows.Forms.Label();
            this.lblDisponibilVal = new System.Windows.Forms.Label();
            this.numCantitate = new System.Windows.Forms.NumericUpDown();
            this.btnVinde = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).BeginInit();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produs:";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descriere:";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data expirarii:";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Disponibil:";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cantitate vanduta:";
            //
            // lblIdVal
            //
            this.lblIdVal.AutoSize = true;
            this.lblIdVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblIdVal.Location = new System.Drawing.Point(180, 20);
            this.lblIdVal.Name = "lblIdVal";
            this.lblIdVal.Size = new System.Drawing.Size(19, 20);
            this.lblIdVal.TabIndex = 6;
            this.lblIdVal.Text = "-";
            //
            // lblDenumireVal
            //
            this.lblDenumireVal.AutoSize = true;
            this.lblDenumireVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDenumireVal.Location = new System.Drawing.Point(180, 55);
            this.lblDenumireVal.Name = "lblDenumireVal";
            this.lblDenumireVal.Size = new System.Drawing.Size(19, 20);
            this.lblDenumireVal.TabIndex = 7;
            this.lblDenumireVal.Text = "-";
            //
            // lblDescriereVal
            //
            this.lblDescriereVal.Location = new System.Drawing.Point(180, 90);
            this.lblDescriereVal.Name = "lblDescriereVal";
            this.lblDescriereVal.Size = new System.Drawing.Size(300, 65);
            this.lblDescriereVal.TabIndex = 8;
            this.lblDescriereVal.Text = "-";
            //
            // lblExpirareVal
            //
            this.lblExpirareVal.AutoSize = true;
            this.lblExpirareVal.Location = new System.Drawing.Point(180, 165);
            this.lblExpirareVal.Name = "lblExpirareVal";
            this.lblExpirareVal.Size = new System.Drawing.Size(14, 20);
            this.lblExpirareVal.TabIndex = 9;
            this.lblExpirareVal.Text = "-";
            //
            // lblDisponibilVal
            //
            this.lblDisponibilVal.AutoSize = true;
            this.lblDisponibilVal.Location = new System.Drawing.Point(180, 200);
            this.lblDisponibilVal.Name = "lblDisponibilVal";
            this.lblDisponibilVal.Size = new System.Drawing.Size(14, 20);
            this.lblDisponibilVal.TabIndex = 10;
            this.lblDisponibilVal.Text = "-";
            //
            // numCantitate
            //
            this.numCantitate.Location = new System.Drawing.Point(180, 243);
            this.numCantitate.Name = "numCantitate";
            this.numCantitate.Size = new System.Drawing.Size(120, 26);
            this.numCantitate.TabIndex = 11;
            //
            // btnVinde
            //
            this.btnVinde.Location = new System.Drawing.Point(248, 295);
            this.btnVinde.Name = "btnVinde";
            this.btnVinde.Size = new System.Drawing.Size(112, 35);
            this.btnVinde.TabIndex = 12;
            this.btnVinde.Text = "Vinde";
            this.btnVinde.UseVisualStyleBackColor = true;
            this.btnVinde.Click += new System.EventHandler(this.btnVinde_Click);
            //
            // btnAnulare
            //
            this.btnAnulare.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnulare.Location = new System.Drawing.Point(368, 295);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(112, 35);
            this.btnAnulare.TabIndex = 13;
            this.btnAnulare.Text = "Anulare";
            this.btnAnulare.UseVisualStyleBackColor = true;
            //
            // FormVanzare
            //
            this.AcceptButton = this.btnVinde;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnulare;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnVinde);
            this.Controls.Add(this.numCantitate);
            this.Controls.Add(this.lblDisponibilVal);
            this.Controls.Add(this.lblExpirareVal);
            this.Controls.Add(this.lblDescriereVal);
            this.Controls.Add(this.lblDenumireVal);
            this.Controls.Add(this.lblIdVal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVanzare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vanzare produs";
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIdVal;
        private System.Windows.Forms.Label lblDenumireVal;
        private System.Windows.Forms.Label lblDescriereVal;
        private System.Windows.Forms.Label lblExpirareVal;
        private System.Windows.Forms.Label lblDisponibilVal;
        private System.Windows.Forms.NumericUpDown numCantitate;
        private System.Windows.Forms.Button btnVinde;
        private System.Windows.Forms.Button btnAnulare;
    }
}
