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
    // cerintele proiect 2:
    //  cerinta 1 - optiunile din lab 5 (adaugare, vanzare, cumparare) dar cu baza de date sqlite
    //  cerinta 2 - AsyncTask (Task.Run + Invoke) pt toate operatiile cu baza de date
    //  cerinta 3 - obiectul CategorieProdus (id, denumire) administrat de ef
    //  cerinta 4 - campul idCategorie la Produs, produsele se administreaza tinand cont de categorie
    //  cerinta 5 - obiectul IstoricVanzari (id, idProdus, cantitate), la afisare apare si categoria
    public partial class Form1 : Form
    {
        // categories are kept here, the add form gets them from here
        private List<CategorieProdus> categorii = new List<CategorieProdus>();

        public Form1()
        {
            InitializeComponent();
        }

        // cerinta 1 - la pornire se creeaza tabelele sqlite (pe Task, cerinta 2)
        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Se deschide baza de date...";

            Task.Run(() =>
            {
                try
                {
                    MagazinDbContext.CreeazaTabele();
                    this.Invoke(new Action(() => IncarcaTot()));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Eroare";
                        MessageBox.Show("Nu s-a putut deschide baza de date:\n" + ex.Message, "Eroare",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        // categories first, the products get loaded after them (see AfiseazaCategorii)
        private void IncarcaTot()
        {
            IncarcaCategorii();
        }

        // cerinta 3 - incarcarea categoriilor (pt filtru si pt form-ul de adaugare)
        // ---------------- categorii ----------------

        private void IncarcaCategorii()
        {
            Task.Run(() =>
            {
                try
                {
                    List<CategorieProdus> lista;
                    using (MagazinDbContext db = new MagazinDbContext())
                    {
                        lista = db.Categorii.OrderBy(c => c.Denumire).ToList();
                    }
                    this.Invoke(new Action(() => AfiseazaCategorii(lista)));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => MessageBox.Show("Eroare la categorii:\n" + ex.Message)));
                }
            });
        }

        private void AfiseazaCategorii(List<CategorieProdus> lista)
        {
            categorii = lista;

            // filter combo: first item is "all"
            List<CategorieProdus> pentruFiltru = new List<CategorieProdus>();
            CategorieProdus toate = new CategorieProdus();
            toate.Id = 0;
            toate.Denumire = "(toate)";
            pentruFiltru.Add(toate);
            pentruFiltru.AddRange(lista);

            cmbFiltruCategorie.SelectedIndexChanged -= cmbFiltruCategorie_SelectedIndexChanged;
            cmbFiltruCategorie.DisplayMember = "Denumire";
            cmbFiltruCategorie.ValueMember = "Id";
            cmbFiltruCategorie.DataSource = pentruFiltru;
            cmbFiltruCategorie.SelectedIndex = 0;
            cmbFiltruCategorie.SelectedIndexChanged += cmbFiltruCategorie_SelectedIndexChanged;

            IncarcaProduse();
        }

        // ---------------- produse ----------------

        // cerinta 2 - citirea produselor pe thread pool, rezultatul la gui prin Invoke
        // loads the products on the thread pool, then gives the list back to the gui with Invoke
        private void IncarcaProduse()
        {
            string filtru = txtCautare.Text.Trim().ToLower();
            int idCategorie = 0;
            if (cmbFiltruCategorie.SelectedValue != null)
                idCategorie = (int)cmbFiltruCategorie.SelectedValue;

            lblStatus.Text = "Se incarca datele...";
            btnRefresh.Enabled = false;

            Task.Run(() =>
            {
                try
                {
                    List<Produs> lista = new List<Produs>();
                    using (MagazinDbContext db = new MagazinDbContext())
                    {
                        // cerinta 4 - fiecare produs se afiseaza cu numele categoriei
                        // join so every product gets its category name
                        var rez = (from p in db.Produse
                                   join c in db.Categorii on p.IdCategorie equals c.Id
                                   orderby p.Id
                                   select new { Produs = p, NumeCategorie = c.Denumire }).ToList();

                        foreach (var r in rez)
                        {
                            r.Produs.Categorie = r.NumeCategorie;
                            lista.Add(r.Produs);
                        }
                    }

                    // filtering with linq on the list (search text + category)
                    if (filtru != "")
                        lista = lista.Where(p => p.Denumire.ToLower().Contains(filtru) ||
                                                 (p.Descriere != null && p.Descriere.ToLower().Contains(filtru))).ToList();
                    if (idCategorie != 0)
                        lista = lista.Where(p => p.IdCategorie == idCategorie).ToList();

                    this.Invoke(new Action(() => AfiseazaProduse(lista)));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Eroare";
                        btnRefresh.Enabled = true;
                        MessageBox.Show("Eroare la citirea datelor:\n" + ex.Message, "Eroare",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        private void AfiseazaProduse(List<Produs> lista)
        {
            dataGridView1.DataSource = lista;

            dataGridView1.Columns["IdCategorie"].Visible = false;
            dataGridView1.Columns["Categorie"].DisplayIndex = 2;
            dataGridView1.Columns["DataIntrare"].HeaderText = "Data intrarii";
            dataGridView1.Columns["DataExpirare"].HeaderText = "Data expirarii";
            dataGridView1.Columns["DataIntrare"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dataGridView1.Columns["DataExpirare"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dataGridView1.Columns["Descriere"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // expired products in red
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Produs p = (Produs)row.DataBoundItem;
                if (p.DataExpirare.Date < DateTime.Today)
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }

            lblStatus.Text = lista.Count + " produse  |  dublu click pe un produs pentru vanzare";
            btnRefresh.Enabled = true;
        }

        private Produs ProdusSelectat()
        {
            if (dataGridView1.CurrentRow == null)
                return null;
            return (Produs)dataGridView1.CurrentRow.DataBoundItem;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCautare.Clear();
            IncarcaTot();
        }

        // cerinta 1 - cautare (filtrare in datagridview) + cerinta 4 - filtrare dupa categorie
        // ---------------- cautare ----------------

        private void btnCauta_Click(object sender, EventArgs e)
        {
            IncarcaProduse();
        }

        private void txtCautare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IncarcaProduse();
            }
        }

        private void cmbFiltruCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncarcaProduse();
        }

        private void cautareProduseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCautare.Focus();
            txtCautare.SelectAll();
        }

        // cerinta 1 - adaugare produs nou / cumparare (cantitate la produs existent)
        // ---------------- adaugare ----------------

        private void produsNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdaugare f = new FormAdaugare(categorii);
            if (f.ShowDialog() == DialogResult.OK)
                IncarcaProduse();
        }

        private void produsExistentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // the id comes from the main form (selected row), it can be changed in the form
            Produs p = ProdusSelectat();
            int id = 0;
            if (p != null)
                id = p.Id;

            FormAdaugare f = new FormAdaugare(id);
            if (f.ShowDialog() == DialogResult.OK)
                IncarcaProduse();
        }

        // cerinta 1 - vanzare la dublu click pe datagridview
        // ---------------- vanzare ----------------

        private void DeschideVanzare(Produs p)
        {
            FormVanzare f = new FormVanzare(p);
            if (f.ShowDialog() == DialogResult.OK)
                IncarcaProduse();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // header

            Produs p = (Produs)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            DeschideVanzare(p);
        }

        private void vanzareProduseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produs p = ProdusSelectat();
            if (p == null)
            {
                MessageBox.Show("Selectati un produs din tabel (sau dublu click pe el)!");
                return;
            }
            DeschideVanzare(p);
        }

        // ---------------- categorii + istoric ----------------

        // cerinta 3 - administrarea categoriilor
        private void categoriiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategorii f = new FormCategorii();
            f.ShowDialog();

            // names could have changed, reload everything
            IncarcaTot();
        }

        // cerinta 5 - afisarea vanzarilor
        private void istoricVanzariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIstoric f = new FormIstoric();
            f.ShowDialog();
        }
    }
}
