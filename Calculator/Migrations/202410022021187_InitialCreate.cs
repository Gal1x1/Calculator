namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    // Třída pro vytvoření migrace databáze
    public partial class InitialCreate : DbMigration
    {
        // Metoda pro provedení změn v databázi (přidání tabulky)
        public override void Up()
        {
            // Vytvoření nové tabulky "CalculationLogs" v databázi
            CreateTable(
                "dbo.CalculationLogs",  // Název tabulky
                c => new                // Definice sloupců v tabulce
                {
                    // Sloupec "Id", který je primárním klíčem a automaticky se inkrementuje
                    Id = c.Int(nullable: false, identity: true),

                    // Sloupec "Operand1" pro uložení prvního operandu typu decimal
                    Operand1 = c.Decimal(nullable: false, precision: 18, scale: 2),

                    // Sloupec "Operand2" pro uložení druhého operandu typu decimal
                    Operand2 = c.Decimal(nullable: false, precision: 18, scale: 2),

                    // Sloupec "Operation" pro uložení operace (např. +, -, *, /)
                    Operation = c.String(),

                    // Sloupec "Result" pro uložení výsledku výpočtu typu int
                    Result = c.Int(nullable: false),

                    // Sloupec "Timestamp" pro uložení času provedení výpočtu typu DateTime
                    Timestamp = c.DateTime(nullable: false),
                })
                // Definice primárního klíče na sloupci "Id"
                .PrimaryKey(t => t.Id);
        }

        // Metoda pro odstranění změn v databázi (odstranění tabulky)
        public override void Down()
        {
            // Odstranění tabulky "CalculationLogs" z databáze
            DropTable("dbo.CalculationLogs");
        }
    }
}
