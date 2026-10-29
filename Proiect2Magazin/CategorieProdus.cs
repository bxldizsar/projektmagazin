using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect2Magazin
{
    [Table("Categorii")]
    // cerinta 3 - CategorieProdus: id, denumire
    public class CategorieProdus
    {
        public int Id { get; set; }

        [Required]
        public string Denumire { get; set; }
    }
}
