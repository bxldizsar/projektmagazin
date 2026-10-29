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
    // cerinta 3 - administrarea categoriilor: adaugare, redenumire, stergere
    public partial class FormCategorii : Form
    {
        public FormCategorii()
        {
            InitializeComponent();
        }

        private void FormCategorii_Load(object sender, EventArgs e)
        {
            IncarcaCategorii();
        }

        private void IncarcaCategorii()
        {
            Task.Run(() =>
            {
                List<CategorieProdus> lista;
                using (MagazinDbContext db = new MagazinDbContext())
                {
                    lista = db.Categorii.OrderBy(c => c.Denumire).ToList();
                }

                this.Invoke(new Action(() =>
                {
                    lstCategorii.DisplayMember = "Denumire";
                    lstCategorii.DataSource = lista;
                    PornesteButoane(true);
                }));
            });
        }

        private void PornesteButoane(bool da)
        {
            btnAdauga.Enabled = da;
            btnRedenumeste.Enabled = da;
            btnSterge.Enabled = da;
        }

        // when you click a category its name goes into the textbox (for rename)
        private void lstCategorii_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategorieProdus c = lstCategorii.SelectedItem as CategorieProdus;
            if (c != null)
                txtDenumire.Text = c.Denumire;
        }

        // cerinta 2 - operatiile pe thread pool + Invoke
        // runs a db operation on the thread pool and reloads the list at the end
        private void RuleazaOperatie(Action<MagazinDbContext> operatie)
        {
            PornesteButoane(false);

            Task.Run(() =>
            {
                try
                {
                    using (MagazinDbContext db = new MagazinDbContext())
                    {
                        operatie(db);
                        db.SaveChanges();
                    }
                    this.Invoke(new Action(() => IncarcaCategorii()));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PornesteButoane(true);
                    }));
                }
            });
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            string nume = txtDenumire.Text.Trim();
            if (nume == "")
            {
                MessageBox.Show("Introduceti denumirea categoriei!");
                return;
            }

            RuleazaOperatie(db =>
            {
                // linq: no two categories with the same name
                if (db.Categorii.ToList().Any(c => c.Denumire.ToLower() == nume.ToLower()))
                    throw new Exception("Categoria \"" + nume + "\" exista deja!");

                CategorieProdus cat = new CategorieProdus();
                cat.Denumire = nume;
                db.Categorii.Add(cat);
            });
        }

        private void btnRedenumeste_Click(object sender, EventArgs e)
        {
            CategorieProdus selectata = lstCategorii.SelectedItem as CategorieProdus;
            string nume = txtDenumire.Text.Trim();
            if (selectata == null || nume == "")
            {
                MessageBox.Show("Selectati o categorie si scrieti noul nume!");
                return;
            }

            int id = selectata.Id;
            RuleazaOperatie(db =>
            {
                CategorieProdus cat = db.Categorii.Find(id);
                if (cat != null)
                    cat.Denumire = nume;
            });
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            CategorieProdus selectata = lstCategorii.SelectedItem as CategorieProdus;
            if (selectata == null) return;

            if (MessageBox.Show("Stergeti categoria \"" + selectata.Denumire + "\"?", "Confirmare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int id = selectata.Id;
            RuleazaOperatie(db =>
            {
                // cerinta 4 - nu stergem categoria daca are produse
                // cant delete a category that still has products in it
                int nrProduse = db.Produse.Count(p => p.IdCategorie == id);
                if (nrProduse > 0)
                    throw new Exception("Categoria are inca " + nrProduse + " produse, nu poate fi stearsa!");

                CategorieProdus cat = db.Categorii.Find(id);
                if (cat != null)
                    db.Categorii.Remove(cat);
            });
        }
    }
}
