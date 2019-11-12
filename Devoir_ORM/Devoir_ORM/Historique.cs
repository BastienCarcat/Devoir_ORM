using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir_ORM.ORM
{
    public class Historique
    {
        [Key]
        public int HistoriqueId { get; set; }
        [Required]
        [StringLength(50)]
        public string NomIntervention { get; set; }
        public DateTime Ouverture { get; set; }
        public DateTime Cloture { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public Historique()
        {
            Interventions = new List<Intervention>();           
        }
    }
}
