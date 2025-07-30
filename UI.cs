// UI helper class for displaying menus and input prompts
public static class UI
{
    // Displays a message with a newline
    public static void Display(string message) => Console.WriteLine(message);

    // Prompts for a string
    public static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    // Prompts for a decimal input with validation
    public static decimal PromptDecimal(string message, decimal min, decimal max)
    {
        decimal value;
        do
        {
            Console.Write(message);
        } while (!decimal.TryParse(Console.ReadLine(), out value) || value < min || value > max);
        return value;
    }

    // Prompts for an int input with validation
    public static int PromptInt(string message, int min, int max)
    {
        int value;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);
        return value;
    }

    // Prompts for a boolean input (true/false)
    public static bool PromptBool(string message)
    {
        Console.Write(message + " (true/false): ");
        return bool.Parse(Console.ReadLine());
    }
}
