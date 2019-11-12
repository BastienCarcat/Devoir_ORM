using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir_ORM.ORM
{
    public class Intervention
    {
        [Key]
        public int InterventionId { get; set; }
        public virtual ICollection<Matériel> Matériels { get; set; }

        public virtual Véhicule Véhicule { get; set; }
        public virtual Intervenant Intervenant { get; set; }
        public virtual Historique Historique { get; set; }
        public Intervention()
        {
            Matériels = new List<Matériel>();
        }
    }
}
