using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Homework_SysPr_9
{
    class Program
    {
        static async Task Main()
        {
            while (true)
            {
                Console.WriteLine("Введите математическое выражение (или 'exit' для выхода): ");
                string input = Console.ReadLine();

                if (input == null)
                    break;

                try
                {
                    var result = await CalculateExpression(input);
                    Console.WriteLine($"Результат:  {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        static async Task<double> CalculateExpression(string expression)
        {
            var options = ScriptOptions.Default
                .AddReferences(typeof(Math).Assembly)
                .AddImports("System", "System.Math");

            return await CSharpScript.EvaluateAsync<double>(expression, options); 
        }
    }
}
