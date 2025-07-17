// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run -- <command>");
            Console.WriteLine("Available commands: greet <name>, add <a> <b>");
            return;
        }

        string command = args[0].ToLower();

        switch (command)
        {
            case "greet":
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: greet <name>");
                }
                else
                {
                    Console.WriteLine($"Hello, {args[1]}!");
                }
                break;

            case "add":
                if (args.Length < 3 ||
                    !int.TryParse(args[1], out int a) ||
                    !int.TryParse(args[2], out int b))
                {
                    Console.WriteLine("Usage: add <number1> <number2>");
                }
                else
                {
                    Console.WriteLine($"{a} + {b} = {a + b}");
                }
                break;

            default:
                Console.WriteLine($"Unknown command: {command}");
                break;
        }
