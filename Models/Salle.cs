
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace Project_college.Models
{
    public class Salle
    {
        public int SalleId { get; set; }
        [DisplayName("Type")]
        public int SalleTypeId { get; set; }
        public virtual SalleType Type { get; set; }
        [Required(ErrorMessage = "numero is required.")]
        [DisplayName("Numero")]
        [Range(1, 20, ErrorMessage = "Can only be between 1 and 20")]
        public int numero { get; set; }
        [Required(ErrorMessage = "nbrPlace is required.")]
        [DisplayName("nbrPlace")]
        [Range(20, 45, ErrorMessage = "Can only be between 20 and 45")]
        public int nbrPlace { get; set; }

    }
}
