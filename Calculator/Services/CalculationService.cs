// Importuje základní knihovnu pro práci s datem a výjimkami
using System;
// Importuje model CalculationLog pro práci se záznamy výpočtů
using Calculator.Models;
using Calculator.Data.Repositories;
using Calculator.Services;
public class CalculationService : ICalculationService
{
    private readonly ICalculationLogRepository _logRepository;

    public CalculationService(ICalculationLogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public int Calculate(decimal operand1, decimal operand2, string operation)
    {
        try
        {
            decimal result;
            // Логика выполнения операции
            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    if (operand2 != 0)
                        result = operand1 / operand2;
                    else
                        throw new DivideByZeroException("Деление на ноль невозможно");
                    break;
                default:
                    throw new InvalidOperationException("Неизвестная операция");
            }

            // Заокругление результата
            int roundedResult = (int)Math.Round(result);

            // Вызов метода репозитория для логирования
            _logRepository.LogCalculation(operand1, operand2, operation, roundedResult);

            return roundedResult;
        }
        catch (Exception ex)
        {
            SendError(ex);
            throw;
        }
    }

    public void SendError(Exception ex)
    {
        System.IO.File.AppendAllText("errors.log", $"{DateTime.Now}: {ex.Message}\n");
    }
}
