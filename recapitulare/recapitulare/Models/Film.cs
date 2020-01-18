using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recapitulare.Models
{
    public class Film
    {
        [Key]
        public int IDFilm { get; set; }
        [Required]
        public string Denumire { get; set; }

        public virtual ICollection<Recenzie> Recenzie { get; set; }

    }
}