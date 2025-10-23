// Program.cs

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

Console.WriteLine($"Sha: {GitVersionInfo.Sha}");
Console.WriteLine($"InformationalVersion: {GitVersionInfo.InformationalVersion}");
Console.WriteLine($"MajorMinorPatch: {GitVersionInfo.MajorMinorPatch}");

public static class GitVersionInfo
{
    public static int Major => GetJsonProperty<int>("Major");
    public static int Minor => GetJsonProperty<int>("Minor");
    public static int Patch => GetJsonProperty<int>("Patch");
    public static string PreReleaseTag => GetJsonProperty<string>("PreReleaseTag");
    public static string PreReleaseTagWithDash => GetJsonProperty<string>("PreReleaseTagWithDash");
    public static string PreReleaseLabel => GetJsonProperty<string>("PreReleaseLabel");
    public static string PreReleaseLabelWithDash => GetJsonProperty<string>("PreReleaseLabelWithDash");
    public static int? PreReleaseNumber => GetJsonProperty<int?>("PreReleaseNumber");
    public static int BuildMetaData => GetJsonProperty<int>("BuildMetaData");
    public static string BuildMetaDataPadded => GetJsonProperty<string>("BuildMetaDataPadded");
    public static string FullBuildMetaData => GetJsonProperty<string>("FullBuildMetaData");
    public static string MajorMinorPatch => GetJsonProperty<string>("MajorMinorPatch");
    public static string SemVer => GetJsonProperty<string>("SemVer");
    public static string LegacySemVer => GetJsonProperty<string>("LegacySemVer");
    public static string LegacySemVerPadded => GetJsonProperty<string>("LegacySemVerPadded");
    public static string AssemblySemVer => GetJsonProperty<string>("AssemblySemVer");
    public static string AssemblySemFileVer => GetJsonProperty<string>("AssemblySemFileVer");
    public static string FullSemVer => GetJsonProperty<string>("FullSemVer");
    public static string InformationalVersion => GetJsonProperty<string>("InformationalVersion");
    public static string BranchName => GetJsonProperty<string>("BranchName");
    public static string EscapedBranchName => GetJsonProperty<string>("EscapedBranchName");
    public static string Sha => GetJsonProperty<string>("Sha");
    public static string ShortSha => GetJsonProperty<string>("ShortSha");
    public static string NuGetVersionV2 => GetJsonProperty<string>("NuGetVersionV2");
    public static string NuGetVersion => GetJsonProperty<string>("NuGetVersion");
    public static string NuGetPreReleaseTagV2 => GetJsonProperty<string>("NuGetPreReleaseTagV2");
    public static string NuGetPreReleaseTag => GetJsonProperty<string>("NuGetPreReleaseTag");
    public static string VersionSourceSha => GetJsonProperty<string>("VersionSourceSha");
    public static int CommitsSinceVersionSource => GetJsonProperty<int>("CommitsSinceVersionSource");
    public static string CommitsSinceVersionSourcePadded => GetJsonProperty<string>("CommitsSinceVersionSourcePadded");
    public static int UncommittedChanges => GetJsonProperty<int>("UncommittedChanges");
    public static string CommitDate => GetJsonProperty<string>("CommitDate");
    public static JsonNode? Json { get; } =
        JsonSerializer.Deserialize<JsonNode>((Assembly.GetExecutingAssembly()
            .GetCustomAttributes(typeof(AssemblyMetadataAttribute), false)
            .Select(a => a as AssemblyMetadataAttribute)
            .Where(ma => ma is not null && ma.Key.StartsWith("GitVersionInformation"))
            .FirstOrDefault()
            ?.Value ?? "")
            .Replace(";", ""));
    public static T GetJsonProperty<T>(string key, T defaultValue = default(T))
        => Json is JsonObject obj
            && obj.TryGetPropertyValue(key, out var value)
            && value.GetValue<T>() is T v
            ? v
            : defaultValue;
}
