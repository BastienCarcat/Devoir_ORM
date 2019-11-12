using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir_ORM.ORM
{
    public class ContexteBDD : DbContext
    {
        public ContexteBDD()
            : base("chaineDeConnexion")
        {

        }
        public virtual DbSet<Intervenant> Intervenants { get; set; }
        public virtual DbSet<Matériel> Matériels { get; set; }
        public virtual DbSet<Véhicule> Véhicules { get; set; }
        public virtual DbSet<Historique> Historiques { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
    }
}
