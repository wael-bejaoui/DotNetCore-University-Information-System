using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_college.Models
{
    public class Classe
    {  
        public int ClasseId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Numero is required.")]
        [Range(3, 6, ErrorMessage = "Can only be between 3 and 6")]
        [DisplayName("Niveau")]
        public int niveau { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "nbrEtudiant is required.")]
        [Range(15, 30, ErrorMessage = "Can only be between 15 and 30")]
        [DisplayName("nbrEtudiant")]
        public int nbrEtudiant { get; set; }
        public virtual ICollection<Enseigne> Enseignes { get; set; }



    }
}
