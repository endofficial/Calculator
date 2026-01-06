using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        RegToCalculations chronology = new RegToCalculations();
        JsonWriter writer;

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented; // indica come deve essere formattato l'output di testo JSON
            writer.WriteStartObject(); // scrive l'inzio di un oggetto JSON
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();

            /*StreamWriter logFile = File.CreateText("calculator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile)); // ottieni la raccolta di listener che esegue il monitoraggio dell'output di traccia
            Trace.AutoFlush = true; // indica se chiamare il metodo flush() sulla proprietà listeners dopo ogni operazione di scrittura
            Trace.WriteLine("Starting Calculator Log");
            Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));*/
        }

        public void LogHistoryViewed()
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Event");
            writer.WriteValue("Chronology Viewed");
            writer.WritePropertyName("Time");
            writer.WriteValue(DateTime.Now.ToString());
            writer.WriteEndObject();
        }

        public void LogHistoryCleared()
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Event");
            writer.WriteValue("Chronology Cleared");
            writer.WritePropertyName("Time");
            writer.WriteValue(DateTime.Now.ToString());
            writer.WriteEndObject();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number"
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            double rad = num1 * (Math.PI / 180.0);

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    //Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, result));
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    //Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, result));
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    //Trace.WriteLine(String.Format("{0} * {1} = {2}", num1, num2, result));
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        writer.WriteValue("Divide");
                        //Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, result));
                    }
                    break;
                case "r":
                    result = Math.Sqrt(num1);
                    writer.WriteValue("Square Root");
                    break;
                case "p":
                    result = Math.Pow(num1, num2);
                    writer.WriteValue("Raising");
                    break;
                case "sn":
                    // Convert degrees to radians
                    result = Math.Sin(rad); 
                    writer.WriteValue("Sine");
                    break;
                case "cs":
                    result = Math.Cos(rad);
                    writer.WriteValue("Cosine");
                    break;
                case "tn":
                    if (Math.Abs(Math.Cos(rad)) < 0.0001) // Math.Abs because of floating point precision issues
                    {
                        WriteLine("UNDEFINED VALUE\n");
                        result = double.NaN;
                    }
                    else
                    {
                        result = Math.Tan(rad);
                    }
                    writer.WriteValue("Tangent");
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            chronology.RegOperations(num1, num2, op, result);

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
