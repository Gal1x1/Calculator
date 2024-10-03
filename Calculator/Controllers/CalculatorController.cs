// Importuje základní knihovnu pro práci s daty a časy
using System;
// Importuje knihovnu pro práci s kolekcemi (List)
using System.Collections.Generic;
// Importuje knihovnu MVC pro práci s controllery a požadavky
using System.Web.Mvc;
// Importuje modely pro práci s výpočty
using Calculator.Models;
// Importuje služby výpočtů
using Calculator.Services;

public class CalculatorController : Controller
{
    // Odkaz na službu výpočtů, která je injektována pomocí dependency injection
    private readonly ICalculationService _calculationService;
    // Statická proměnná pro uchování historie výpočtů (posledních 10 operací)
    private static List<CalculationModel> _calculationHistory = new List<CalculationModel>();

    // Konstruktor, který přijímá službu výpočtů a umožňuje její použití v controlleru
    public CalculatorController(ICalculationService calculationService)
    {
        _calculationService = calculationService;  // Injektování služby
    }

    // Metoda pro výpočet (volána při HTTP POST požadavku)
    [HttpPost]
    public JsonResult Calculate(decimal Operand1, decimal Operand2, string Operation)
    {
        // Výpočet výsledku pomocí služby
        int result = _calculationService.Calculate(Operand1, Operand2, Operation);

        // Vytvoření nového objektu CalculationModel pro uchování výsledku
        var calculation = new CalculationModel
        {
            Operand1 = Operand1,    // První operand
            Operand2 = Operand2,    // Druhý operand
            Operation = Operation,  // Operace
            Result = result,        // Výsledek výpočtu
            Time = DateTime.Now     // Čas provedení operace
        };

        // Přidání výpočtu do historie
        _calculationHistory.Add(calculation);

        // Pokud historie obsahuje více než 10 záznamů, odstraní nejstarší záznam
        if (_calculationHistory.Count > 10)
        {
            _calculationHistory.RemoveAt(0); // Uchováváme pouze posledních 10 operací
        }

        // Vrací výsledek výpočtu a celou historii jako JSON odpověď
        return Json(new { result, history = _calculationHistory });
    }

    // Metoda pro zobrazení úvodní stránky kalkulačky (volána při HTTP GET požadavku)
    [HttpGet]
    public ActionResult Index()
    {
        return View(); // Toto akce vrací pohled /Views/Calculator/Index.cshtml
    }

    // Metoda pro získání historie výpočtů (volána při HTTP GET požadavku)
    public JsonResult GetHistory()
    {
        // Vrací historii výpočtů jako JSON odpověď (pro AJAX nebo jiné požadavky)
        return Json(_calculationHistory, JsonRequestBehavior.AllowGet);
    }
}
