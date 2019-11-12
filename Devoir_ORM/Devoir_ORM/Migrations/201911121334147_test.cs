namespace Devoir_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Historiques",
                c => new
                    {
                        HistoriqueId = c.Int(nullable: false, identity: true),
                        NomIntervention = c.String(nullable: false, maxLength: 50),
                        Ouverture = c.DateTime(nullable: false),
                        Cloture = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HistoriqueId);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        InterventionId = c.Int(nullable: false, identity: true),
                        Historique_HistoriqueId = c.Int(),
                        Intervenant_Matricule = c.Int(),
                        Véhicule_Immatriculation = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.InterventionId)
                .ForeignKey("dbo.Historiques", t => t.Historique_HistoriqueId)
                .ForeignKey("dbo.Intervenants", t => t.Intervenant_Matricule)
                .ForeignKey("dbo.Véhicule", t => t.Véhicule_Immatriculation)
                .Index(t => t.Historique_HistoriqueId)
                .Index(t => t.Intervenant_Matricule)
                .Index(t => t.Véhicule_Immatriculation);
            
            CreateTable(
                "dbo.Intervenants",
                c => new
                    {
                        Matricule = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Prenom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Matricule);
            
            CreateTable(
                "dbo.Véhicule",
                c => new
                    {
                        Immatriculation = c.String(nullable: false, maxLength: 30),
                        Marque = c.String(nullable: false, maxLength: 20),
                        Modèle = c.String(nullable: false, maxLength: 100),
                        Volume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Immatriculation);
            
            CreateTable(
                "dbo.Matériel",
                c => new
                    {
                        Référence = c.Int(nullable: false, identity: true),
                        Désignation = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        dateAchat = c.DateTime(nullable: false),
                        Disponible = c.Boolean(nullable: false),
                        Intervention_InterventionId = c.Int(),
                    })
                .PrimaryKey(t => t.Référence)
                .ForeignKey("dbo.Interventions", t => t.Intervention_InterventionId)
                .Index(t => t.Intervention_InterventionId);
            
            CreateTable(
                "dbo.VéhiculeIntervenant",
                c => new
                    {
                        Véhicule_Immatriculation = c.String(nullable: false, maxLength: 30),
                        Intervenant_Matricule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Véhicule_Immatriculation, t.Intervenant_Matricule })
                .ForeignKey("dbo.Véhicule", t => t.Véhicule_Immatriculation, cascadeDelete: true)
                .ForeignKey("dbo.Intervenants", t => t.Intervenant_Matricule, cascadeDelete: true)
                .Index(t => t.Véhicule_Immatriculation)
                .Index(t => t.Intervenant_Matricule);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matériel", "Intervention_InterventionId", "dbo.Interventions");
            DropForeignKey("dbo.Interventions", "Véhicule_Immatriculation", "dbo.Véhicule");
            DropForeignKey("dbo.VéhiculeIntervenant", "Intervenant_Matricule", "dbo.Intervenants");
            DropForeignKey("dbo.VéhiculeIntervenant", "Véhicule_Immatriculation", "dbo.Véhicule");
            DropForeignKey("dbo.Interventions", "Intervenant_Matricule", "dbo.Intervenants");
            DropForeignKey("dbo.Interventions", "Historique_HistoriqueId", "dbo.Historiques");
            DropIndex("dbo.VéhiculeIntervenant", new[] { "Intervenant_Matricule" });
            DropIndex("dbo.VéhiculeIntervenant", new[] { "Véhicule_Immatriculation" });
            DropIndex("dbo.Matériel", new[] { "Intervention_InterventionId" });
            DropIndex("dbo.Interventions", new[] { "Véhicule_Immatriculation" });
            DropIndex("dbo.Interventions", new[] { "Intervenant_Matricule" });
            DropIndex("dbo.Interventions", new[] { "Historique_HistoriqueId" });
            DropTable("dbo.VéhiculeIntervenant");
            DropTable("dbo.Matériel");
            DropTable("dbo.Véhicule");
            DropTable("dbo.Intervenants");
            DropTable("dbo.Interventions");
            DropTable("dbo.Historiques");
        }
    }
}
