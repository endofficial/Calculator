using System.Diagnostics;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile)); // ottieni la raccolta di listener che esegue il monitoraggio dell'output di traccia
            Trace.AutoFlush = true; // indica se chiamare il metodo flush() sulla proprietà listeners dopo ogni operazione di scrittura
            Trace.WriteLine("Starting Calculator Log");

            Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
            Trace.WriteLine("Started {0}", System.DateTime.Now.ToString());
        }

        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number"

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
