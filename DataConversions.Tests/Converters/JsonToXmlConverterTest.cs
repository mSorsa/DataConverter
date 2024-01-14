using System.Threading.Tasks;
using DataConversions.Converters;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataConversions.Tests.Converters;

[TestClass]
[TestSubject(typeof(JsonToXmlConverter))]
public class JsonToXmlConverterTest
{
    private const string TestFileType = "Json";
    
    [TestMethod]
    public async Task Convert_JsonToXml_Basic_Books_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "books.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Basic_Person_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "persons.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Nested_Company_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "company.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Array_Products_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "products.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_DifferentDataTypes_Device_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "device.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_ComplexNested_School_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "school.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_UniCodeAndSpecialCharacters_Restaurant_Success()
    {
        var file = await TestHelpers.GetFileContent(TestFileType, "restaurant.json");
        var sut = new JsonToXmlConverter();

        var result = await sut.Convert(file);
        
        Assert.IsNotNull(result);
    }
}