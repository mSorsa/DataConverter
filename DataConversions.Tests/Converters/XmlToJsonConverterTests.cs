using System.Threading.Tasks;
using DataConversions.Converters;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataConversions.Tests.Converters;

[TestClass]
[TestSubject(typeof(XmlToJsonConverter))]
public class XmlToJsonConverterTests
{
    [TestMethod]
    public async Task Convert_XmlToJson_Basic_Books_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("books.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Basic_Person_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("person.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Nested_Company_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("company.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Array_Products_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("products.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_DifferentDataTypes_Device_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("device.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_ComplexNested_School_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("school.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_UniCodeAndSpecialCharacters_Restaurant_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("restaurant.xml");
        var converter = new XmlToJsonConverter();

        // Act
        var jsonResult = await converter.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
}