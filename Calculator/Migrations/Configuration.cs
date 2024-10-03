namespace Calculator.Migrations
{
    // Importuje základní knihovnu pro práci s daty a časy
    using System;
    // Importuje Entity Framework knihovnu pro práci s databázemi
    using System.Data.Entity;
    // Importuje knihovnu pro práci s migracemi v Entity Framework
    using System.Data.Entity.Migrations;
    // Importuje knihovnu LINQ pro práci s dotazy do databáze
    using System.Linq;

    // Třída Configuration je zodpovědná za konfiguraci migrací databáze
    internal sealed class Configuration : DbMigrationsConfiguration<CalculatorDbContext>
    {
        // Konstruktor třídy Configuration
        public Configuration()
        {
            // Povolení nebo zakázání automatických migrací
            AutomaticMigrationsEnabled = false; // Automatické migrace jsou zakázány
        }

        // Metoda Seed je volána po aplikaci migrací, aby se inicializovala databáze
        protected override void Seed(CalculatorDbContext context)
        {
            // Tato metoda bude volána po migraci databáze na nejnovější verzi

            // Pomocí metody DbSet<T>.AddOrUpdate() můžete přidat nebo aktualizovat data v databázi
            // Zamezí se tím vytvoření duplicitních záznamů v databázi
        }
    }
}
