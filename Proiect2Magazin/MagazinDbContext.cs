using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect2Magazin
{
    // cerinta 1 - contextul ef cu baza de date sqlite (+ cerinta 3 si 5: cele doua obiecte noi)
    public class MagazinDbContext : DbContext
    {
        // the db file is next to the exe (bin\Debug\magazin.db)
        public MagazinDbContext()
            : base(new SQLiteConnection("Data Source=magazin.db"), true)
        {
        }

        public DbSet<Produs> Produse { get; set; }
        public DbSet<CategorieProdus> Categorii { get; set; }
        public DbSet<IstoricVanzari> Vanzari { get; set; }

        // the sqlite provider cant create the db by itself (no code first create),
        // so we make the tables by hand if they arent there yet
        public static void CreeazaTabele()
        {
            using (MagazinDbContext db = new MagazinDbContext())
            {
                db.Database.ExecuteSqlCommand(
                    "CREATE TABLE IF NOT EXISTS Categorii (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Denumire TEXT NOT NULL)");

                db.Database.ExecuteSqlCommand(
                    "CREATE TABLE IF NOT EXISTS Produse (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Denumire VARCHAR(30) NOT NULL, " +
                    "Descriere VARCHAR(500), " +
                    "DataIntrare DATETIME NOT NULL, " +
                    "DataExpirare DATETIME NOT NULL, " +
                    "Cantitate INTEGER NOT NULL, " +
                    "IdCategorie INTEGER NOT NULL REFERENCES Categorii(Id))");

                db.Database.ExecuteSqlCommand(
                    "CREATE TABLE IF NOT EXISTS IstoricVanzari (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "IdProdus INTEGER NOT NULL, " +
                    "Cantitate INTEGER NOT NULL, " +
                    "DenumireProdus VARCHAR(30), " +
                    "IdCategorie INTEGER NOT NULL, " +
                    "DataVanzare DATETIME NOT NULL)");

                // at least one category, otherwise you cant add any product
                if (!db.Categorii.Any())
                {
                    CategorieProdus c = new CategorieProdus();
                    c.Denumire = "Diverse";
                    db.Categorii.Add(c);
                    db.SaveChanges();
                }
            }
        }
    }
}
