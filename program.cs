using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        var command = args[0].ToLower();

        switch (command)
        {
            case "calc":
                HandleCalc(args);
                break;

            case "time":
                HandleTime(args);
                break;

            case "echo":
                HandleEcho(args);
                break;

            default:
                Console.WriteLine($"Unknown command: {command}");
                ShowHelp();
                break;
        }
    }

    static void HandleCalc(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: calc <add|sub|mul|div> <num1> <num2>");
            return;
        }

        var op = args[1].ToLower();

        if (!double.TryParse(args[2], out double x) || !double.TryParse(args[3], out double y))
        {
            Console.WriteLine("Both operands must be numbers.");
            return;
        }

        switch (op)
        {
            case "add":
                Console.WriteLine($"{x} + {y} = {x + y}");
                break;
            case "sub":
                Console.WriteLine($"{x} - {y} = {x - y}");
                break;
            case "mul":
                Console.WriteLine($"{x} * {y} = {x * y}");
                break;
            case "div":
                if (y == 0)
                {
                    Console.WriteLine("Division by zero is not allowed.");
                }
                else
                {
                    Console.WriteLine($"{x} / {y} = {x / y}");
                }
                break;
            default:
                Console.WriteLine($"Unknown operation: {op}");
                break;
        }
    }

    static void HandleTime(string[] args)
    {
        var format = "HH:mm:ss";
        var useUtc = false;

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i] == "--utc")
                useUtc = true;
            else if (args[i].StartsWith("--format="))
                format = args[i].Substring("--format=".Length);
        }

        var time = useUtc ? DateTime.UtcNow : DateTime.Now;

        try
        {
            Console.WriteLine(time.ToString(format, CultureInfo.InvariantCulture));
        }
        catch
        {
            Console.WriteLine("Invalid time format string.");
        }
    }

    static void HandleEcho(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: echo <text> [--upper]");
            return;
        }

        var text = string.Join(" ", args[1..]);
        var upper = text.EndsWith("--upper");

        if (upper)
            text = text.Replace("--upper", "").Trim();

        Console.WriteLine(upper ? text.ToUpper() : text);
    }

    static void ShowHelp()
    {
        Console.WriteLine("MyCliApp - Command Line Utility");
        Console.WriteLine();
        Console.WriteLine("Available commands:");
        Console.WriteLine("  calc <add|sub|mul|div> <num1> <num2>     Perform basic arithmetic");
        Console.WriteLine("  time [--utc] [--format=FORMAT]           Display current time");
        Console.WriteLine("  echo <text> [--upper]                    Echo input text");
    }
}
