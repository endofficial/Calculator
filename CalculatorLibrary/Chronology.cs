using System.Diagnostics;

public class RegToCalculations
{
    public static List<string> registerCalc = new List<string>();

    public double RegOperations(double n1, double n2, string op, double result)
    {
        double number1 = n1;
        double number2 = n2;
        string Operator = op;
        double Result = result;

        switch (op)
        {
            case "a":
                Operator = "+";
                break;
            case "s":
                Operator = "-";
                break;
            case "m":
                Operator = "*";
                break;
            case "d":
                Operator = "/";
                break;
            default:
                Operator = "?";
                break;
        }

        string calcDetails = $"{n1} {Operator} {n2} = {result:F2}";
        registerCalc.Add(calcDetails);

        return result;
    }
}
