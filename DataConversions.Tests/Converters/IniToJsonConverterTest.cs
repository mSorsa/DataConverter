using System;
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
    public async Task ConvertIniToJsonAsync_SimpleKeyValuePairs_ReturnsValidJson()
    {
        // Arrange
        var iniContent = @"
[Section]
Key1=Value1
Key2=Value2
";
        var expectedJson = """
                           {
                             "Section": {
                               "Key1": "Value1",
                               "Key2": "Value2"
                             }
                           }
                           """;

        // Act
        var jsonResult = await Converter.Convert(iniContent);

        // Assert
        Assert.AreEqual(expectedJson, jsonResult);
    }

    [TestMethod]
    public async Task ConvertIniToJsonAsync_EmptySections_ReturnsEmptyJsonObject()
    {
        // Arrange
        var iniContent = @"
[EmptySection]
";
        var expectedJson = """
                           {
                             "EmptySection": {}
                           }
                           """;

        // Act
        var jsonResult = await Converter.Convert(iniContent);

        // Assert
        Assert.AreEqual(expectedJson, jsonResult);
    }

    [TestMethod]
    public async Task ConvertIniToJsonAsync_MissingSection_ReturnsEmptyJson()
    {
        // Arrange
        var iniContent = "KeyWithoutSection=Value";
        var expectedJson = "{}";

        // Act 
        var result = await Converter.Convert(iniContent);

        // Assert
        Assert.AreEqual(expectedJson, result);
    }

    [TestMethod]
    public async Task ConvertIniToJsonAsync_BasicSection_Success()
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
    public async Task ConvertIniToJsonAsync_DataTypes_Success()
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
    public async Task ConvertIniToJsonAsync_DbSettings_Success()
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
    public async Task ConvertIniToJsonAsync_NestedSection_Success()
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
    public async Task ConvertIniToJsonAsync_SpecialChars_Success()
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