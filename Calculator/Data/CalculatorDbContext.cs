// Importuje knihovnu Entity Framework pro práci s databázemi
using System.Data.Entity;
// Importuje model CalculationLog, který budeme používat pro logování výpočtů
using Calculator.Models;

public class CalculatorDbContext : DbContext
{
    // Konstruktor pro konfiguraci připojení k databázi
    // Používá název řetězce připojení "CalculatorDbConnectionString", který je definován v konfiguračním souboru
    public CalculatorDbContext() : base("name=CalculatorDbConnectionString")
    {
    }

    // DbSet představuje tabulku v databázi, kde se budou ukládat záznamy výpočtů (CalculationLog)
    public DbSet<CalculationLog> CalculationLogs { get; set; }
}
