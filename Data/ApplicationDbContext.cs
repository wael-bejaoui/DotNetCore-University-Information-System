using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_college.Models;


namespace Project_college.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Cour> Cours { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Enseigne> Enseignes { get; set; }
        public object Enseigne { get; internal set; }

       
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
