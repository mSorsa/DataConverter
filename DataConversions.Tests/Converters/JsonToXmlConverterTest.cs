﻿using System.Threading.Tasks;
using DataConversions.Converters;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataConversions.Tests.Converters;

[TestClass]
[TestSubject(typeof(JsonToXmlConverter))]
public class JsonToXmlConverterTest
{
    private const string TestFileType = "Json";
    private JsonToXmlConverter Sut { get; set; }

    [TestInitialize]
    public void Init()
    {
        Sut = new JsonToXmlConverter();
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Basic_Books_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "books");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Basic_Person_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "persons");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Nested_Company_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "company");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_Array_Products_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "products");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_DifferentDataTypes_Device_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "device");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_ComplexNested_School_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "school");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task Convert_JsonToXml_UniCodeAndSpecialCharacters_Restaurant_Success()
    {
        // Arrange
        var file = await TestHelpers.GetFileContent(TestFileType, "restaurant");

        // Act
        var result = await Sut.Convert(file);
        
        // Assert
        Assert.IsNotNull(result);
    }
}