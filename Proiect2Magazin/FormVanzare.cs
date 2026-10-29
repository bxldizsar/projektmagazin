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
    // cerinta 1 - form pt vanzare (ca in lab 5)
    public partial class FormVanzare : Form
    {
        private int idProdus;

        // gets the record from the main form (the row that was double clicked)
        public FormVanzare(Produs p)
        {
            InitializeComponent();

            idProdus = p.Id;
            lblIdVal.Text = p.Id.ToString();
            lblDenumireVal.Text = p.Denumire + "  (" + p.Categorie + ")";
            lblDescriereVal.Text = p.Descriere;
            lblExpirareVal.Text = p.DataExpirare.ToString("dd.MM.yyyy");
            lblDisponibilVal.Text = p.Cantitate.ToString();

            // cant sell more than what we have
            numCantitate.Minimum = 1;
            numCantitate.Maximum = p.Cantitate;
            numCantitate.Value = 1;
        }

        private void btnVinde_Click(object sender, EventArgs e)
        {
            int cantitate = (int)numCantitate.Value;
            btnVinde.Enabled = false;

            // cerinta 2 - vanzarea pe thread pool + Invoke la final
            Task.Run(() =>
            {
                try
                {
                    bool sters = false;

                    using (MagazinDbContext db = new MagazinDbContext())
                    {
                        // read it again, maybe it changed since the grid was loaded
                        Produs p = db.Produse.Find(idProdus);
                        if (p == null)
                            throw new Exception("Produsul nu mai exista in baza de date!");
                        if (p.Cantitate < cantitate)
                            throw new Exception("Stoc insuficient! Disponibil: " + p.Cantitate);

                        p.Cantitate -= cantitate;

                        // cerinta 5 - fiecare vanzare se salveaza in IstoricVanzari
                        // save the sale in the history (same SaveChanges as the stock change)
                        IstoricVanzari v = new IstoricVanzari();
                        v.IdProdus = p.Id;
                        v.Cantitate = cantitate;
                        v.DenumireProdus = p.Denumire;
                        v.IdCategorie = p.IdCategorie;
                        v.DataVanzare = DateTime.Now;
                        db.Vanzari.Add(v);

                        // cerinta 1 - la cantitate 0 produsul se sterge (ca in lab 5)
                        // nothing left -> delete it from the db
                        if (p.Cantitate == 0)
                        {
                            db.Produse.Remove(p);
                            sters = true;
                        }

                        db.SaveChanges();
                    }

                    this.Invoke(new Action(() =>
                    {
                        if (sters)
                            MessageBox.Show("Vanzare reusita. Produsul s-a terminat si a fost sters.");
                        else
                            MessageBox.Show("Vanzare reusita.");
                        DialogResult = DialogResult.OK;
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnVinde.Enabled = true;
                    }));
                }
            });
        }
    }
}
