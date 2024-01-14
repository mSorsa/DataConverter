using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataConversions.Tests;

internal static class TestHelpers
{
    
    internal static async Task<string> GetFileContent(string fileType, string fileName)
    {
        var filePath = Path.Combine("Converters", "TestFiles", fileType, fileName);
        var file = File.Open(filePath, FileMode.Open);
        
        using var reader = new StreamReader(file);

        return await reader.ReadToEndAsync();
    }
    
    internal static async Task<XDocument> ReadXmlDocument(string filename)
    {
        var content = await GetFileContent("xml", filename);
        
        return XDocument.Parse(content);
    }
}