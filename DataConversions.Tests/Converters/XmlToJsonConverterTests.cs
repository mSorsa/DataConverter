using System.Threading.Tasks;
using DataConversions.Converters;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataConversions.Tests.Converters;

[TestClass]
[TestSubject(typeof(XmlToJsonConverter))]
public class XmlToJsonConverterTests
{
    private XmlToJsonConverter Sut { get; set; }

    [TestInitialize]
    public void Init()
    {
        Sut = new XmlToJsonConverter();
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Basic_Books_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("books.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Basic_Person_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("person.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Nested_Company_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("company.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_Array_Products_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("products.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_DifferentDataTypes_Device_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("device.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_ComplexNested_School_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("school.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
    
    [TestMethod]
    public async Task Convert_XmlToJson_UniCodeAndSpecialCharacters_Restaurant_Success()
    {
        // Arrange
        var xmlDocument = await TestHelpers.ReadXmlDocument("restaurant.xml");

        // Act
        var jsonResult = await Sut.Convert(xmlDocument);

        // Assert
        Assert.IsNotNull(jsonResult);
    }
}