using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Project_college.Models
{
    public class SalleType
    {
        public int SalleTypeId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Salle> Salles { get; set; }
    }
}
