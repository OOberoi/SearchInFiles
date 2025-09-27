Console.WriteLine("Enter a ClientId to search for!");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("ClientId cannot be null or empty.");
    return;
}
string clientId = input;
string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.log", SearchOption.AllDirectories);

// Simplified collection initialization (IDE0028) and 'new' expression (IDE0090)
var matchingLines = new List<string>();

foreach (string file in files)
{
    string[] lines = File.ReadAllLines(file);
    foreach (string line in lines)
    {
        if (line.Contains(clientId))
        {
            matchingLines.Add($"File: {file}, Line: {line}");
        }
    }
}