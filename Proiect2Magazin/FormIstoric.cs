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
    // cerinta 5 - afisarea vanzarilor impreuna cu categoria produselor
    public partial class FormIstoric : Form
    {
        public FormIstoric()
        {
            InitializeComponent();
        }

        private void FormIstoric_Load(object sender, EventArgs e)
        {
            lblTotal.Text = "Se incarca...";

            // cerinta 2 - citirea pe thread pool + Invoke
            Task.Run(() =>
            {
                try
                {
                    List<IstoricVanzari> vanzari;
                    List<CategorieProdus> categorii;
                    using (MagazinDbContext db = new MagazinDbContext())
                    {
                        vanzari = db.Vanzari.OrderByDescending(v => v.DataVanzare).ToList();
                        categorii = db.Categorii.ToList();
                    }

                    // left join: if the category was deleted meanwhile we still show the sale
                    var lista = (from v in vanzari
                                 join c in categorii on v.IdCategorie equals c.Id into cj
                                 from c in cj.DefaultIfEmpty()
                                 select new
                                 {
                                     v.Id,
                                     v.IdProdus,
                                     Produs = v.DenumireProdus,
                                     Categorie = c != null ? c.Denumire : "-",
                                     v.Cantitate,
                                     Data = v.DataVanzare
                                 }).ToList();

                    // how much was sold from each category
                    var peCategorii = lista.GroupBy(x => x.Categorie)
                                           .Select(g => g.Key + ": " + g.Sum(x => x.Cantitate) + " buc")
                                           .ToList();

                    string total = "Total vandut: " + lista.Sum(x => x.Cantitate) + " buc";
                    if (peCategorii.Count > 0)
                        total += "   |   " + string.Join(",  ", peCategorii);

                    this.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = lista;
                        dataGridView1.Columns["IdProdus"].HeaderText = "Id produs";
                        dataGridView1.Columns["Data"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                        dataGridView1.Columns["Produs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        lblTotal.Text = total;
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblTotal.Text = "Eroare";
                        MessageBox.Show("Eroare la citirea vanzarilor:\n" + ex.Message);
                    }));
                }
            });
        }
    }
}
