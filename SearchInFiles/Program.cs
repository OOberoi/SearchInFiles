Console.WriteLine("Enter a ClientId to search for!");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("ClientId cannot be null or empty.");
    return;
}
string clientId = input;
string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt", SearchOption.AllDirectories);
List<string> matchingLines = new List<string>();
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