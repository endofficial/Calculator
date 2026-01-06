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

        int nCalc = 0; // nCalc will count the number of calculations performed

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            nCalc++;
            WriteLine($"Calculation #{nCalc}\n");

            if (nCalc > 1) // After the first calculation, to show chronology
            {
                Write("If you see chronology calculations enter 'O', enter 'C' to continue, enter 'E' to exit program: ");
                string? input = (ReadLine() ?? "").ToUpper();

                while (input is null || !Regex.IsMatch(input, "[O|C|E]"))
                {
                    Write("Invalid option. Please select a valid option: ");
                    input = (ReadLine() ?? "").ToUpper();
                }

                if (input is "O") 
                {
                    calculator.LogHistoryViewed(); // To log that history was viewed

                    WriteLine("\n--- Chronology of Calculations ---\n");

                    for (int i = 0; i < RegToCalculations.registerCalc.Count; i++)
                    {
                        WriteLine($"[{i}] {RegToCalculations.registerCalc[i]}\n");
                    }
                    WriteLine("--- End of Chronology ---\n");

                    // to clear the chronology
                    Write("If you want to remove the cronology, enter 'K' or press 'C' to continue: \n");
                    string? deleteInput = (ReadLine() ?? "").ToUpper();

                    while (deleteInput is null || !Regex.IsMatch(deleteInput, "[K|C]"))
                    {
                        WriteLine("\nInvalid option. Please selecet a valid option.\n");
                        deleteInput = (ReadLine() ?? "").ToUpper();
                    }
                    if (deleteInput is "K")
                    {
                        calculator.LogHistoryCleared(); // To log that history was cleared

                        RegToCalculations.registerCalc.Clear();
                        RegToCalculations.registerResult.Clear();
                        WriteLine("Chronology cleared.\n");
                    }

                    else if (deleteInput is "C")
                    {
                        Write("\nIf you want to use a calculation of the chronology, press and enter a number or press 'C' to continue: ");
                        string? input2 = (ReadLine() ?? "").ToUpper();

                        while (input2 is null || input2 != "C" && !int.TryParse(input2, out _))
                        {
                            Write("\nInvalid option. Please select a valid option: ");
                            input2 = (ReadLine() ?? "").ToUpper();
                        }

                        if (int.TryParse(input2, out int reuseInput))
                        {
                            if (reuseInput >= 0 && reuseInput < RegToCalculations.registerResult.Count)
                            {
                                string reuseCalc = RegToCalculations.registerResult[reuseInput];
                                WriteLine($"\nReusing calculation: {reuseCalc}\n");
                                numInput1 = reuseCalc;
                            }
                        }
                    }

                }
                else if (input is "E")
                {
                    break;
                }
            }

            // check numInput1 value because it could be assigned from chronology reuse
            if (string.IsNullOrEmpty(numInput1))
            {
                Write("Type a number, and then press Enter: ");
                numInput1 = ReadLine();
            }

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

            OutputEncoding = System.Text.Encoding.UTF8;

            WriteLine("Choose an operator from the following list:\n");
            WriteLine("\ta - Add");
            WriteLine("\ts - Subtract");
            WriteLine("\tm - Multiply");
            WriteLine("\td - Divide");
            WriteLine("\tr - Square root");
            WriteLine("\tp - Raising");
            WriteLine("\tsn - Sine");
            WriteLine("\tcs - Cosine");
            WriteLine("\ttn - Tangent");
            WriteLine("\nYour option? ");

            string? op = ReadLine();
            while (op is null || !Regex.IsMatch(op, "[a|s|m|d|r|p|sn|cs|tn]")) 
            {
                WriteLine("Invalid option. Please select a valid operator.");
                op = ReadLine();
            }
            if (op is not null)
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