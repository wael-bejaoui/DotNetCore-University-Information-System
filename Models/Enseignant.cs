using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_college.Models
{
    public class Enseignant
    {

        public int EnseignantId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "cin is required.")]
        [DisplayName("cin")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "CIN INVALIDE")]
        public string cin { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Nom is required.")]
        [DisplayName("Nom")]
        [StringLength(20, MinimumLength = 3)]
        public string nom { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Prenom is required.")]
        [DisplayName("Prenom")]
        [StringLength(20, MinimumLength = 3)]
        public string prenom { get; set; }
        public virtual ICollection<Cour> Cours { get; set; }

    }
}
