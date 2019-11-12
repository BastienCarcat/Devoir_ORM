using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir_ORM.ORM
{
    public class Intervenant
    {
        [Key]
        public int Matricule { get; set; }
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }
        public virtual ICollection<Véhicule> Véhicules { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public Intervenant()
        {
            Véhicules = new List<Véhicule>();
            Interventions = new List<Intervention>();
        }
    }
}
