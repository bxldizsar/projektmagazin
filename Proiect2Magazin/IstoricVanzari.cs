using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect2Magazin
{
    [Table("IstoricVanzari")]
    // cerinta 5 - IstoricVanzari: id, idProdus, cantitate
    public class IstoricVanzari
    {
        public int Id { get; set; }

        public int IdProdus { get; set; }

        public int Cantitate { get; set; }

        // extra: when the stock gets to 0 the product is deleted, so without these
        // we couldnt show the name / category of an old sale anymore
        public string DenumireProdus { get; set; }

        public int IdCategorie { get; set; }

        public DateTime DataVanzare { get; set; }
    }
}
