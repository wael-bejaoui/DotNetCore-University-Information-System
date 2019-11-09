using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_college.Models
{
    public class Etudiant
    {
        public int EtudiantId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Nom is required.")]
        [DisplayName("Nom")]
        [StringLength(20, MinimumLength = 3)]
        public string Nom { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Prenom is required.")]
        [DisplayName("Prenom")]
        [StringLength(20, MinimumLength = 3)]
        public string Prenom { get; set; }
        [DisplayName("CIN")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "CIN must be with 8 digits")]
        public string cin { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
