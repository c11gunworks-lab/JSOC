using JetBrains.Annotations;
using SPTarkov.Server.Core.Models.Spt.Mod;
using Range = SemanticVersioning.Range;
using Version = SemanticVersioning.Version;


namespace JSOC;
[UsedImplicitly]

public record ModMetadata : IModMetadata
{
    public string ModGuid { get; init; } = "com.c11.jsoc";
    public string Name { get; init; } = "JSOC";
    public string Author { get; init; } = "Bobinstien";
    public List<string>? Contributors { get; init; } = ["Spy"];
    public Version Version { get; init; } = new(typeof(ModMetadata).Assembly.GetName().Version!.ToString(3));
    public Range SptVersion { get; init; } = new("~4.1.6");
    public bool HasPrepatcher { get; init; } = false;
    public List<string>? Incompatibilities { get; init; } = [];
    public Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~3.0.6") }
    };
    public string? Url { get; init; } = "https://github.com/c11gunworks-lab/JSOC";
    public string License { get; init; } = "MIT";
}
