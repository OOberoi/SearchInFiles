using System.Configuration;

Console.WriteLine("Enter a ClientId to search for:");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("ClientId cannot be null or empty.");
    return;
}
string clientId = input;

string? dataFolder = ConfigurationManager.AppSettings["DataFolder"];
if (string.IsNullOrWhiteSpace(dataFolder))
{
    Console.WriteLine("DataFolder configuration is missing or empty.");
    return;
}
string[] files = Directory.GetFiles(dataFolder, "*.log", SearchOption.AllDirectories);

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
    Console.WriteLine($"The files are: {file}");
}
