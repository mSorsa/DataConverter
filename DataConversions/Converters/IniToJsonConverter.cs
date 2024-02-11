using System.Text.Json;

namespace DataConversions.Converters;

public sealed class IniToJsonConverter : DataConverter<string, string>
{
    public override async Task<string> Convert(string input,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dict = new Dictionary<string, Dictionary<string, string>>();
        using (var reader = new StringReader(input))
        {
            Dictionary<string, string> currentSection = null;

            while (await reader.ReadLineAsync(cancellationToken) is { } line)
            {
                line = line.Trim();
                if (line.StartsWith('[') && line.EndsWith(']'))
                {
                    currentSection = new Dictionary<string, string>();
                    dict[line[1..^1]] = currentSection;
                }
                else if (currentSection is not null)
                {
                    var pair = line.Split('=', 2);
                    if (pair.First() is "")
                        continue;
                    
                    currentSection[pair.First()] = pair.Last();
                }
            }
        }

        using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, dict, new JsonSerializerOptions { WriteIndented = true },
            cancellationToken);
        stream.Position = 0;

        using var jsonReader = new StreamReader(stream);
        return await jsonReader.ReadToEndAsync(cancellationToken);
    }
}