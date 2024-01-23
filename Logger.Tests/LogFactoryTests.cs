using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{


    [TestMethod]//Method_Condition_Pass/Fail()

    public void CreateLogger_ClassNameFileLogger_Pass()
    {
        LogFactory factory = new ();
        factory.ConfigureFileLogger("test.text");

        Assert.AreEqual("FileLogger", factory.CreateLogger("FileLogger")!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_ClassNameNotFileLogger_ReturnsNull()
    {
        LogFactory factory = new();
        factory.ConfigureFileLogger("test.text");

        Assert.IsNull(factory.CreateLogger("NotFileLogger"));
    }

    [TestMethod]
    public void ConfigureFileLogger_ValidPath_Pass()
    {
        LogFactory factory = new ();
        
        Assert.AreEqual("test.text", factory.ConfigureFileLogger("test.text"));
    }

    [TestMethod]
    public void ConfigureFileLogger_MisMatchPath_Fail()
    {
        LogFactory factory = new();

        Assert.AreNotEqual("test.text", factory.ConfigureFileLogger("notTest.text"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ConfigureFileLogger_NullPath_ThrowsException()
    {
        string? nullPath = null;
        LogFactory factory = new ();
        factory.ConfigureFileLogger(nullPath!);
    }

}
