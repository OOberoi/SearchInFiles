using System.Configuration;

Console.WriteLine("Enter a ClientId to search for:");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Client Id cannot be null or empty.");
    return;
}
string clientId = input;

string? dataFolder = ConfigurationManager.AppSettings["DataFolder"];
if (string.IsNullOrWhiteSpace(dataFolder))
{
    Console.WriteLine($"ERROR: file {dataFolder} does not exist.");
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
            string fullPath = Path.GetFullPath(file);
            string fileName = Path.GetFileName(fullPath);
            Console.WriteLine($"The file(s) are: {fileName}");
        }
   }     
}
Console.WriteLine("File not found!");
return;
