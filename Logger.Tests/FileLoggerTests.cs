using System.IO;
using System;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private readonly string _filePath = "test.txt";
    private FileLogger? _logger;

    [TestInitialize]
    public void Initialize()
    {
        _logger = new(_filePath);
    }

    [TestMethod]
    public void GetFilePath_SameFilePath_Pass()
    {
        Assert.AreEqual(_filePath, _logger!.GetFilePath());
    }

    [TestMethod]
    public void GetFilePath_DifferentFilePath_Fail()
    {
        Assert.AreNotEqual("notTest.txt", _logger!.GetFilePath());
    }

    [TestMethod]
    public void SetFilePath_CorrectFilePath_Pass()
    {
        _logger!.SetFilePath(_filePath);
        Assert.AreEqual(_filePath, _logger!.GetFilePath());
    }

    [TestMethod]
    public void SetFilePath_FilePathMisMatch_Fail()
    {
        _logger!.SetFilePath("notFilePath");
        Assert.AreNotEqual(_filePath, _logger!.GetFilePath());
    }

    [TestMethod]
    public void Log_AppendingTextToFile_Pass()
    {
        string text = "This is a test...";

        //Clean-Up the test file
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }

        _logger!.ClassName = "FileLogger";
        _logger!.Log(LogLevel.Debug, text);
        

        StreamReader streamReader = new (_filePath);
        //string appendedText = streamReader.ReadToEnd();
        string appendedText = streamReader.ReadLine() ?? string.Empty;
        streamReader.Close();

        DateTime now = DateTime.Now;
        string expectedText = $"{now} FileLogger Debug: {text}";

        Assert.AreEqual(expectedText, appendedText);
    }

}
