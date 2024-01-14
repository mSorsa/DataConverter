using System.Text.Json;
using System.Xml.Linq;

namespace DataConversions.Converters;

public sealed class XmlToJsonConverter : DataConverter<XDocument, string>
{
    public override async Task<string> Convert(XDocument xmlDocument, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var rootElement = xmlDocument.Root;
        if (rootElement == null)
        {
            throw new ArgumentException("XML document must have a root element.");
        }
        
        return await Task.Run(() =>
        {
            var jsonObject = ConvertElementToJson(rootElement, cancellationToken);
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            
            return JsonSerializer.Serialize(jsonObject, jsonOptions);
        }, cancellationToken);
    }
    
    private static async Task<object> ConvertElementToJson(XElement element, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        // If the element has no sub-elements, return its value
        if (!element.HasElements)
        {
            if (!element.HasAttributes) 
                return element.Value.Trim();
            
            var dictionary = new Dictionary<string, object>();
            foreach (var attribute in element.Attributes())
            {
                dictionary[attribute.Name.LocalName] = attribute.Value;
            }
            
            dictionary["value"] = element.Value.Trim();
            
            return dictionary;
        }

        // If the element has sub-elements, create a new dictionary
        var result = new Dictionary<string, object>();
        foreach (var subElement in element.Elements())
        {
            var key = subElement.Name.LocalName;
            
            // Recursive traversal
            var value = await ConvertElementToJson(subElement, cancellationToken);

            // Handle multiple sub-elements with the same name
            if (result.ContainsKey(key))
            {
                if (result[key] is List<object> list)
                {
                    list.Add(value);
                }
                else
                {
                    result[key] = new List<object> { result[key], value };
                }
            }
            else
            {
                result[key] = value;
            }
        }

        foreach (var attribute in element.Attributes())
        {
            result["@" + attribute.Name.LocalName] = attribute.Value;
        }

        return result;
    }
}