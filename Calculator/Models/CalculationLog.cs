// Importuje základní knihovnu pro práci s datovým typem DateTime
using System;

namespace Calculator.Models
{
    // Definice třídy CalculationLog, která reprezentuje záznam výpočtu (logování)
    public class CalculationLog
    {
        // Unikátní identifikátor (primární klíč)
        public int Id { get; set; }

        // První operand, použitý ve výpočtu, desetinné číslo (např. 12.5)
        public decimal Operand1 { get; set; }

        // Druhý operand, použitý ve výpočtu, desetinné číslo (např. 8.3)
        public decimal Operand2 { get; set; }

        // Operace provedená na operandech (např. +, -, *, /)
        public string Operation { get; set; }

        // Výsledek výpočtu, uložený jako celé číslo (po zaokrouhlení)
        public int Result { get; set; }

        // Datum a čas, kdy byl výpočet proveden
        public DateTime Timestamp { get; set; }
    }
}
