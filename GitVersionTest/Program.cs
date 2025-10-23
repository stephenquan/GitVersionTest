// Program.cs

using System.Dynamic;
using System.Reflection;

dynamic? gitVersionInfo = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>((Assembly.GetExecutingAssembly()
    .GetCustomAttributes(typeof(AssemblyMetadataAttribute), false)
    .Select(a => a as AssemblyMetadataAttribute)
    .Where(ma => ma is not null && ma.Key.StartsWith("GitVersionInformation"))
    .FirstOrDefault()
    ?.Value ?? "")
    .Replace(";", ""));

Console.WriteLine($"Sha: {gitVersionInfo?.Sha}");
Console.WriteLine($"{System.Text.Json.JsonSerializer.Serialize(gitVersionInfo)}");
