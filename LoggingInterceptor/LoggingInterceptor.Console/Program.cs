namespace LoggingInterceptor.Console
{
    using System;
    using Console = System.Console;

    class Program
    {
        private static ICalculator calculator = LoggingInterceptor<ICalculator>.Decorate(new Calculator());

        static void Main(string[] args)
        {
            WriteInstructions();
            ReceiveInput();
        }

        private static void WriteInstructions()
        {
            Console.WriteLine("Usage instructions:");
            Console.WriteLine("\t<command or shortcut> <number>");
            Console.WriteLine("List of commands:");
            Console.WriteLine("\tCommand\t\tShortcut");
            Console.WriteLine("\tadd\t\t+");
            Console.WriteLine("\tsubtract\t-");
            Console.WriteLine("\tmultiply\t*");
            Console.WriteLine("\tdivide\t\t/");
            Console.WriteLine("\tclear\t\tcls");
            Console.WriteLine("\texit");
        }

        private static void ReceiveInput()
        {
            var exit = false;
            while(!exit)
            {
                try
                {
                    var input = GetInput();
                    switch (input.Command?.ToLower())
                    {
                        case "add":
                        case "+":
                            calculator.Add(GetNumber(input.Parameter));
                            WriteResult();
                            break;
                        case "subtract":
                        case "-":
                            calculator.Subtract(GetNumber(input.Parameter));
                            WriteResult();
                            break;
                        case "multiply":
                        case "*":
                            calculator.Multiply(GetNumber(input.Parameter));
                            WriteResult();
                            break;
                        case "divide":
                        case "/":
                            calculator.Divide(GetNumber(input.Parameter));
                            WriteResult();
                            break;
                        case "clear":
                        case "cls":
                            calculator.Clear();
                            WriteResult();
                            break;
                        case "exit":
                            exit = true;
                            break;
                        default:
                            throw new CommandException("Command is unknown.");
                    }
                }
                catch(CommandException ex)
                {
                    Console.WriteLine($"Invalid command. {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Unknown error. {ex.Message}");
                }
            }
        }

        private static void WriteResult()
        {
            Console.WriteLine($"Result: {calculator.GetValue()}");
        }

        private static double GetNumber(string parameter)
        {
            var number = default(double);
            if (!double.TryParse(parameter, out number))
                throw new CommandException($"'{parameter}' is not a valid number.");

            return number;
        }

        private static (string Command, string Parameter) GetInput()
        {
            var line = Console.ReadLine();
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = default(string);
            if(split.Length > 0)
                command = split[0];
            var parameter = default(string);
            if (split.Length > 1)
                parameter = split[1];

            return (command, parameter);
        }
    }
}