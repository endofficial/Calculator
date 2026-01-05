using System.Diagnostics;
using CalculatorLibrary;
using Newtonsoft.Json;

public class RegToCalculations
{
    public static List<string> registerCalc = new List<string>(); // To register the calculations
    public static List<string> registerResult = new List<string>(); // To register the results

    public double RegOperations(double n1, double n2, string op, double result)
    {
        switch (op)
        {
            case "a":
                op = "+";
                break;
            case "s":
                op = "-";
                break;
            case "m":
                op = "*";
                break;
            case "d":
                op = "/";
                break;
            default:
                op = "?";
                break;
        }

        string calcDetails = $"{n1} {op} {n2} = {result.ToString("0.##")}";
        registerCalc.Add(calcDetails);

        string resultDetails = $"{result.ToString("0.##")}";
        registerResult.Add(resultDetails);

        return result;
    }
}
