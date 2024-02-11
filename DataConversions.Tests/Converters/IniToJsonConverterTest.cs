using System.Threading.Tasks;
using DataConversions.Converters;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataConversions.Tests.Converters;

[TestClass]
[TestSubject(typeof(IniToJsonConverter))]
public class IniToJsonConverterTest
{
    private const string FileType = "Ini";
    private IniToJsonConverter Converter { get; set; }

    [TestInitialize]
    public void Init()
    {
        Converter = new IniToJsonConverter();
    }

    [TestMethod]
    public async Task ConvertIniToJson_SimpleKeyValuePairs_ReturnsValidJson()
    {
        // Arrange
        const string IniContent = @"
[Section]
Key1=Value1
Key2=Value2
";
        const string ExpectedJson = """
                                    {
                                      "Section": {
                                        "Key1": "Value1",
                                        "Key2": "Value2"
                                      }
                                    }
                                    """;

        // Act
        var jsonResult = await Converter.Convert(IniContent);

        // Assert
        Assert.AreEqual(ExpectedJson, jsonResult);
    }

    [TestMethod]
    public async Task ConvertIniToJson_EmptySections_ReturnsEmptyJsonObject()
    {
        // Arrange
        const string IniContent = @"
[EmptySection]
";
        const string ExpectedJson = """
                                    {
                                      "EmptySection": {}
                                    }
                                    """;

        // Act
        var jsonResult = await Converter.Convert(IniContent);

        // Assert
        Assert.AreEqual(ExpectedJson, jsonResult);
    }

    [TestMethod]
    public async Task ConvertIniToJson_MissingSection_ReturnsValidJson()
    {
        // Arrange
        const string IniContent = "KeyWithoutSection=Value";
        const string ExpectedJson = """
                                    {
                                      "KeyWithoutSection": "Value"
                                    }
                                    """;

        // Act 
        var result = await Converter.Convert(IniContent);

        // Assert
        Assert.AreEqual(ExpectedJson, result);
    }

    [TestMethod]
    public async Task ConvertIniToJson_BasicSection_Success()
    {
        // Arrange
        var input = await TestHelpers.GetFileContent(FileType, "Basic");
        
        // Act
        var result = await Converter.Convert(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Length > 5);
    }

    [TestMethod]
    public async Task ConvertIniToJson_DataTypes_Success()
    {
        // Arrange
        var input = await TestHelpers.GetFileContent(FileType, "DataTypes");
        
        // Act
        var result = await Converter.Convert(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Length > 5);
    }
    
    [TestMethod]
    public async Task ConvertIniToJson_DbSettings_Success()
    {
        // Arrange
        var input = await TestHelpers.GetFileContent(FileType, "DbSettings");
        
        // Act
        var result = await Converter.Convert(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Length > 5);
    }
    
    [TestMethod]
    public async Task ConvertIniToJson_NestedSection_Success()
    {
        // Arrange
        var input = await TestHelpers.GetFileContent(FileType, "NestedSection");
        
        // Act
        var result = await Converter.Convert(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Length > 5);
    }
    
    [TestMethod]
    public async Task ConvertIniToJson_SpecialChars_Success()
    {
        // Arrange
        var input = await TestHelpers.GetFileContent(FileType, "SpecialChars");
        
        // Act
        var result = await Converter.Convert(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Length > 5);
    }
}