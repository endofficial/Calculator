public class RegToCalculations
{
    public static List<string> registerCalc = new List<string>();

    public double RegOperations(double n1, double n2, string op, double result)
    {
        double number1 = n1;
        double number2 = n2;
        string Operation = op;
        double Result = result;

        string calcDetails = $"{n1} {op} {n2} = {result}";
        registerCalc.Add(calcDetails);

        return result;
    }
}
