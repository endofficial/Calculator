using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        WriteLine("Console Calculator in C#\r"); 
        WriteLine("------------------------\n");

        Calculator calculator = new Calculator();

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Write("Type a number, and then press Enter: ");
            numInput1 = ReadLine();

            Write("Type another number, and then press Enter: ");
            numInput2 = ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Write("This is not valid input. Please enter an integer value: ");
                numInput1 = ReadLine();
            }

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Write("This is not valid input. Please enter an integer value: ");
                numInput2 = ReadLine();
            }

            WriteLine("Choose an operator from the following list:");
            WriteLine("\ta - Add");
            WriteLine("\ts - Subtract");
            WriteLine("\tm - Multiply");
            WriteLine("\td - Divide");
            WriteLine("Your option? ");

            string? op = ReadLine();
            if (op is null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                WriteLine("Invalid option. Please select a valid operator.");
            }
            else
            {
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else
                    {
                        WriteLine("Your result: {0:0.##}\n", result); // Format to 2 decimal places
                    }
                }
                catch (Exception e)
                {
                    WriteLine("Oh no! An exception occurred trying to do the math.\\n - Details: " + e.Message);
                }
            }
            WriteLine("------------------------\n");

            Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (ReadLine() is "n")
            {
                endApp = true;
            }
        }
        calculator.Finish();
        return;
    }
}