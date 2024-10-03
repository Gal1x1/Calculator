// Importuje základní knihovnu pro práci s datovými typy a datem/časem
using System;

namespace Calculator.Models
{
    // Definice třídy CalculationModel, která slouží k uchování informací o jednotlivých výpočtech
    public class CalculationModel
    {
        // První operand pro výpočet (desetinné číslo)
        public decimal Operand1 { get; set; }

        // Druhý operand pro výpočet (desetinné číslo)
        public decimal Operand2 { get; set; }

        // Operace, která se provádí mezi dvěma operandy (např. +, -, *, /)
        public string Operation { get; set; }

        // Výsledek výpočtu (celé číslo)
        public int Result { get; set; }

        // Čas, kdy byl výpočet proveden
        public DateTime Time { get; set; }
    }
}
