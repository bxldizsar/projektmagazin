using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect2Magazin
{
    [Table("Produse")]
    // cerinta 1 - produsul din lab 5
    public class Produs
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Denumire { get; set; }

        [MaxLength(500)]
        public string Descriere { get; set; }

        public DateTime DataIntrare { get; set; }

        public DateTime DataExpirare { get; set; }

        public int Cantitate { get; set; }

        // cerinta 4 - campul idCategorie
        public int IdCategorie { get; set; }

        // not a column in the db, we fill it with the join so the grid can show the name
        [NotMapped]
        public string Categorie { get; set; }
    }
}
