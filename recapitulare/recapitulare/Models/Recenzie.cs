using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace recapitulare.Models
{
    public class Recenzie
    {
        [Key]
        public int IDRecenzie { get; set; }
        [Required]
        public string Titlu { get; set; }
        [Required]
        public string Descriere { get; set; }
        [Required]
        public int Nota { get; set; }
        [Required]
        public string NumeUtilizator { get; set; }
        [Required]
        public int IDFilm { get; set; }

        public virtual Film Film { get; set; }
    }

    public class RecenzieDBContext : DbContext
    {
        public RecenzieDBContext() : base("DBConnectionString") { }
        public DbSet<Film> Filme { get; set; }
        public DbSet<Recenzie> Recenzii { get; set; }
    }
}