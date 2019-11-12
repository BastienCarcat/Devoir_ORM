using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devoir_ORM.ORM;

namespace Devoir_ORM.console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContexteBDD())
            {
               // var Véhicule = db.Véhicules.First(c => c.Immatriculation == "AC-456-BD");

                var Véhicule = new Véhicule()
                {
                    Immatriculation = "AC-456-BD",
                    Marque = "Renault",
                    Modèle = "Clio 2",
                    Volume = 45,
                    Disponible = true
                };
                var Intervenant = new Intervenant()
                {
                    Matricule = 1,
                    Nom = "Dupont",
                    Prenom = "Jean"                    
                };
                var Intervention = new Intervention()
                {
                    Id = 1
                };
                var Materiel = new Matériel()
                {
                    Référence = 1,
                    Désignation ="pioche",
                    Description = "Description",
                    dateAchat = 11-11-2019,
                    Disponible = true
                };

                db.Véhicules.Add(Véhicule);
                db.Intervenants.Add(Intervenant);
                db.Interventions.Add(Intervention);
                db.SaveChanges();
            }
        }
    }
}
