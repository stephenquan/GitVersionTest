// Program.cs

using System.Reflection;

var gitVersionInfo = Assembly.GetExecutingAssembly()
    .GetCustomAttributes(typeof(AssemblyMetadataAttribute), false)
    .Select(a => a as AssemblyMetadataAttribute)
    .Where(ma => ma is not null && ma.Key.StartsWith("GitVersion."))
    .ToDictionary(ma => ma!.Key.Substring(11), ma => ma?.Value);

Console.WriteLine($"Sha: {gitVersionInfo["Sha"]}");
Console.WriteLine($"{System.Text.Json.JsonSerializer.Serialize(gitVersionInfo)}");
