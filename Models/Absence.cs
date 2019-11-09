using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_college.Models
{
    public class Absence
    {   
        public int AbsenceId { get; set; }
        [Required(ErrorMessage = "date is required.")]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int EtudiantId { get; set; }
        public virtual Etudiant Etudiant { get; set; }
        public int CourId { get; set; }
        public virtual Cour Cour { get; set; }
        
    }
}
