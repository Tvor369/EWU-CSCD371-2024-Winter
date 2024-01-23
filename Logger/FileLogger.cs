namespace Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

public class FileLogger : BaseLogger
{

    private string? _filePath;

    public FileLogger(string? fileName)
    {
        _filePath = fileName;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        DateTime now = DateTime.Now;
        string textToAppend = now + " " + base.className + " " + logLevel + ": " + message;
        File.AppendAllText(_filePath, textToAppend + Environment.NewLine);

        //The format may vary, but an example might look like this:
        //"10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"

        //Console.WriteLine(now + " " + base.className + " " + logLevel + ": " + message + Environment.NewLine);
    }

    public string? GetFilePath()
    {
        return _filePath;
    }

    public void SetFilePath(string? newFilePath)
    {
        if (newFilePath != null && newFilePath != "")
        {
            _filePath = newFilePath;
        }
        else
        {
            _filePath = null;
        }
    }

}



