using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect2Magazin
{
    // cerinta 1 - form pt adaugare produs nou / cumparare (cantitate la produs existent)
    public partial class FormAdaugare : Form
    {
        // false = new product, true = we only add quantity to an existing one
        private bool produsExistent;

        // cerinta 4 - la produs nou se alege si categoria
        // new product, the categories come from the main form
        public FormAdaugare(List<CategorieProdus> categorii)
        {
            InitializeComponent();
            produsExistent = false;

            cmbCategorie.DisplayMember = "Denumire";
            cmbCategorie.ValueMember = "Id";
            cmbCategorie.DataSource = categorii;

            Text = "Adaugare produs nou";
            txtId.Text = "(automat)";
            txtId.Enabled = false;
            dtpIntrare.Value = DateTime.Today;
            dtpExpirare.Value = DateTime.Today.AddDays(30);
        }

        // quantity for an existing product, the id comes from the main form
        public FormAdaugare(int id)
        {
            InitializeComponent();
            produsExistent = true;

            Text = "Adaugare cantitate la produs existent";
            if (id > 0)
                txtId.Text = id.ToString();

            // the other fields dont matter here
            txtDenumire.Enabled = false;
            txtDescriere.Enabled = false;
            dtpIntrare.Enabled = false;
            dtpExpirare.Enabled = false;
            cmbCategorie.Enabled = false;
            lblCantitate.Text = "Cantitate de adaugat:";
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (produsExistent && !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Id-ul trebuie sa fie un numar!");
                return;
            }

            string denumire = txtDenumire.Text.Trim();
            string descriere = txtDescriere.Text.Trim();
            DateTime intrare = dtpIntrare.Value.Date;
            DateTime expirare = dtpExpirare.Value.Date;
            int cantitate = (int)numCantitate.Value;
            int idCategorie = 0;
            if (cmbCategorie.SelectedValue != null)
                idCategorie = (int)cmbCategorie.SelectedValue;

            if (!produsExistent)
            {
                if (denumire == "")
                {
                    MessageBox.Show("Introduceti denumirea produsului!");
                    return;
                }
                if (idCategorie == 0)
                {
                    MessageBox.Show("Alegeti o categorie! (meniul Categorii)");
                    return;
                }
                if (expirare < intrare)
                {
                    MessageBox.Show("Data expirarii nu poate fi inainte de data intrarii!");
                    return;
                }
            }

            btnSalvare.Enabled = false;

            // cerinta 2 - salvarea pe thread pool + Invoke la final
            // db work on the thread pool, the form doesnt freeze
            Task.Run(() =>
            {
                try
                {
                    using (MagazinDbContext db = new MagazinDbContext())
                    {
                        if (produsExistent)
                        {
                            Produs p = db.Produse.Find(id);
                            if (p == null)
                                throw new Exception("Nu exista produs cu Id-ul " + id + "!");

                            p.Cantitate += cantitate;
                        }
                        else
                        {
                            Produs p = new Produs();
                            p.Denumire = denumire;
                            p.Descriere = descriere;
                            p.DataIntrare = intrare;
                            p.DataExpirare = expirare;
                            p.Cantitate = cantitate;
                            p.IdCategorie = idCategorie;
                            db.Produse.Add(p);
                        }

                        db.SaveChanges();
                    }

                    // tell the gui thread that its done
                    this.Invoke(new Action(() =>
                    {
                        DialogResult = DialogResult.OK;
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSalvare.Enabled = true;
                    }));
                }
            });
        }
    }
}
