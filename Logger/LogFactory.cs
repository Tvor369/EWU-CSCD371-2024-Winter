using System;
using System.IO;

namespace Logger;

public class LogFactory
{
    private string? _filePath;
    public BaseLogger? CreateLogger(string className)
    {
        //if(className == "FileLogger" || className == "fileLogger")//have config bool check to see if null?
        if(className == nameof(FileLogger))
        {
            FileLogger fileLogger = new FileLogger(_filePath!);
            fileLogger.className = className;

            //FileLogger fileLogger = new FileLogger(_filePath);
            //fileLogger.className = className;
            //fileLogger.SetFilePath(_filePath);
            //fileLogger.Log(LogLevel.Warning, "");
            
            return fileLogger;
        }

        return null;
    }

    private void ConfigureFileLogger(string newFilePath)
    {
        if (newFilePath != null && newFilePath != "")
        {
            _filePath = newFilePath;
        }
        else
        {
            _filePath = null;//throw an exception?
        }
    }//or make it return a bool to determine success
}
