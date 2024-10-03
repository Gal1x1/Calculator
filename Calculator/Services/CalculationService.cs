// Importuje základní knihovnu pro práci s datem a výjimkami
using System;
// Importuje model CalculationLog pro práci se záznamy výpočtů
using Calculator.Models;

namespace Calculator.Services
{
    // Rozhraní pro službu výpočtů
    public interface ICalculationService
    {
        // Definice metody Calculate pro provedení výpočtu
        int Calculate(decimal operand1, decimal operand2, string operation);
        // Definice metody pro odeslání chybové zprávy
        void SendError(Exception ex);
    }

    // Implementace služby výpočtů
    public class CalculationService : ICalculationService
    {
        // Metoda pro provedení výpočtu
        public int Calculate(decimal operand1, decimal operand2, string operation)
        {
            try
            {
                decimal result;  // Proměnná pro uložení výsledku výpočtu

                // Provedení výpočtu na základě operace
                switch (operation)
                {
                    case "+":
                        result = operand1 + operand2;  // Sčítání
                        break;
                    case "-":
                        result = operand1 - operand2;  // Odečítání
                        break;
                    case "*":
                        result = operand1 * operand2;  // Násobení
                        break;
                    case "/":
                        if (operand2 != 0)
                            result = operand1 / operand2;  // Dělení
                        else
                            throw new DivideByZeroException("Dělení nulou není povoleno");
                        break;
                    default:
                        throw new InvalidOperationException("Neznámá operace");  // Výjimka pro neplatnou operaci
                }

                // Zaokrouhlení výsledku na celé číslo a jeho vrácení
                int roundedResult = (int)Math.Round(result);

                // Logování výsledku do databáze
                LogCalculation(operand1, operand2, operation, roundedResult);

                return roundedResult;  // Vrácení zaokrouhleného výsledku
            }
            catch (Exception ex)
            {
                SendError(ex); // Logování chyby
                throw;  // Vyhození výjimky dále
            }
        }

        // Metoda pro logování výpočtů do databáze
        private void LogCalculation(decimal operand1, decimal operand2, string operation, int result)
        {
            try
            {
                // Vytvoření nového kontextu databáze
                using (var db = new CalculatorDbContext())
                {
                    // Vytvoření záznamu logu výpočtu
                    var log = new CalculationLog
                    {
                        Operand1 = operand1,       // První operand
                        Operand2 = operand2,       // Druhý operand
                        Operation = operation,     // Operace: +, -, *, /
                        Result = result,           // Výsledek výpočtu
                        Timestamp = DateTime.Now   // Čas provedení výpočtu
                    };

                    // Přidání záznamu do tabulky CalculationLogs
                    db.CalculationLogs.Add(log);

                    // Uložení změn do databáze
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Logování chyby při ukládání do databáze
                System.IO.File.AppendAllText("errors.log", $"{DateTime.Now}: {ex.Message}\n");
            }
        }

        // Metoda pro logování chyb
        public void SendError(Exception ex)
        {
            // Zápis chyby do souboru
            System.IO.File.AppendAllText("errors.log", $"{DateTime.Now}: {ex.Message}\n");
        }
    }
}
