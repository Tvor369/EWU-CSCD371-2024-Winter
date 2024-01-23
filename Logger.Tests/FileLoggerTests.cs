using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private readonly string _filePath = "test.txt";
    private FileLogger? _logger;

    [TestInitialize]
    public void Constructor()
    {
        _logger = new(_filePath);
    }

    [TestMethod]
    public void FileLogger_CheckGetFilePath_Pass()
    {
        Assert.AreEqual(_filePath, _logger!.GetFilePath());
    }

    [TestMethod]
    public void FileLogger_CheckGetFilePath_Fail()
    {
        Assert.AreNotEqual("notTest.txt", _logger!.GetFilePath());
    }

}
