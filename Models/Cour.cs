using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_college.Models
{
    public class Cour
    {
        public int CourId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Course is required.")]
        [DisplayName("matière")]
        [StringLength(20, MinimumLength = 3)]
        public string name { get; set; }
        public int EnseignantId  { get; set; }
        public  virtual Enseignant Enseignant { get; set; }
        public int SalleId { get; set; }
        [DisplayName("Salle")]
        [ForeignKey("SalleId")]
        public virtual Salle Salle { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }

    }
}
