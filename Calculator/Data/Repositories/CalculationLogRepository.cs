using Calculator.Models;  // Для использования модели CalculationLog
using System;             // Для работы с исключениями и базовыми типами

namespace Calculator.Data.Repositories
{
    // Реализация интерфейса ICalculationLogRepository
    public class CalculationLogRepository : ICalculationLogRepository
    {
        // Метод для сохранения лога вычислений в базу данных
        public void LogCalculation(decimal operand1, decimal operand2, string operation, int result)
        {
            try
            {
                // Использование контекста базы данных
                using (var db = new CalculatorDbContext())
                {
                    // Создание объекта логирования вычислений
                    var log = new CalculationLog
                    {
                        Operand1 = operand1,
                        Operand2 = operand2,
                        Operation = operation,
                        Result = result,
                        Timestamp = DateTime.Now
                    };

                    // Добавление записи в базу данных
                    db.CalculationLogs.Add(log);

                    // Сохранение изменений в базе данных
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки логируем её в файл
                System.IO.File.AppendAllText("errors.log", $"{DateTime.Now}: {ex.Message}\n");
            }
        }
    }
}
