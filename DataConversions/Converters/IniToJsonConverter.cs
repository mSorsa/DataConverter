using System.Text.Json;

namespace DataConversions.Converters;

public sealed class IniToJsonConverter : DataConverter<string, string>
{
    public override async Task<string> Convert(string input,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var rootDict = new Dictionary<string, object>();
        var currentSection = rootDict;
        using (var reader = new StringReader(input))
        {
            while (await reader.ReadLineAsync(cancellationToken) is { } line)
            {
                line = line.Trim();
                if (line.StartsWith(';'))   // is comment
                {
                    continue;
                }
                if (line.StartsWith('[') && line.EndsWith(']')) // is section
                {
                    currentSection = CreateOrGetNestedDictionary(rootDict, line[1..^1]);
                }
                else if (currentSection is not null)    // is key-value pair of a section, or in root
                {
                    var pair = line.Split('=', 2);
                    if (pair.First() is "")
                        continue;

                    currentSection[pair.First()] = GetDataType(pair.Last());
                }
            }
        }

        using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, rootDict, new JsonSerializerOptions { WriteIndented = true },
            cancellationToken);
        stream.Position = 0;

        using var jsonReader = new StreamReader(stream);
        return await jsonReader.ReadToEndAsync(cancellationToken);
    }

    private static Dictionary<string, object> CreateOrGetNestedDictionary(Dictionary<string, object> rootDict,
        string sectionPath)
    {
        var parts = sectionPath.Split('.');
        var currentDict = rootDict;

        foreach (var part in parts)
        {
            if (!currentDict.ContainsKey(part))
            {
                currentDict[part] = new Dictionary<string, object>();
            }

            currentDict = currentDict[part] as Dictionary<string, object>;
        }

        return currentDict;
    }

    private static object GetDataType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (bool.TryParse(value, out var bVal))
        {
            return bVal;
        }

        if (int.TryParse(value, out var iVal))
        {
            return iVal;
        }

        if (double.TryParse(value, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out var dVal))
        {
            return dVal;
        }

        if (DateTime.TryParse(value, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out var dtVal))
        {
            return dtVal;
        }

        return value;
    }
}