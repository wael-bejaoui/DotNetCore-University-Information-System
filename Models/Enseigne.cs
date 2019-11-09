using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_college.Models
{
    public class Enseigne
    {

        public int EnseigneId { get; set; }
        [DisplayName("Classe")]
        [ForeignKey("ClasseId")]
        public int ClasseId { get; set; }
        public virtual Classe Classe { get; set; }
        [DisplayName("Enseignant")]
        [ForeignKey("EnseignantId")]
        public int EnseignantId { get; set; }
        public virtual Enseignant Enseignant { get; set; }

    }
}
