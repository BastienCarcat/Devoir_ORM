using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir_ORM.ORM
{
    public class Véhicule
    {
        [Key]
        [Required]
        [StringLength(30)]
        public string Immatriculation { get; set; }
        [Required]
        [StringLength(20)]
        public string Marque { get; set; }
        [Required]
        [StringLength(100)]
        public string Modèle { get; set; }
        public decimal Volume { get; set; }
        public bool Disponible { get; set; }

        public virtual ICollection<Intervenant> Intervenants { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public Véhicule()
        {
            Intervenants = new List<Intervenant>();
            Interventions = new List<Intervention>();
        }
    }
}
