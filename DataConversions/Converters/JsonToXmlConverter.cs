using System.Text.Json;
using System.Xml.Linq;

namespace DataConversions.Converters;

public sealed class JsonToXmlConverter : DataConverter<string, XDocument>
{
    public override async Task<XDocument> Convert(string jsonInput, CancellationToken cancellationToken = new())
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        using var doc = JsonDocument.Parse(jsonInput);
        
        var root = new XElement("Root");
        await ConvertToXml(doc.RootElement, root, cancellationToken);
        
        return new XDocument(root);
    }
    
    private static async Task ConvertToXml(JsonElement element, XElement parent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                {
                    var childElement = new XElement(property.Name);
                    parent.Add(childElement);
                    
                    // Recursive traversal
                    await ConvertToXml(property.Value, childElement, cancellationToken);
                }
                break;

            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    var childElement = new XElement("Item");
                    parent.Add(childElement);
                    
                    // Recursive traversal
                    await ConvertToXml(item, childElement, cancellationToken);
                }
                break;

            case JsonValueKind.String:
                parent.Value = element.GetString();
                break;

            case JsonValueKind.Number:
                parent.Value = element.GetRawText();
                break;

            case JsonValueKind.True:
            case JsonValueKind.False:
                parent.Value = element.GetBoolean().ToString();
                break;

            case JsonValueKind.Null:
                break;
            case JsonValueKind.Undefined:
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}