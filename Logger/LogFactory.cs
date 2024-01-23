﻿using System;
using System.IO;

namespace Logger;

public class LogFactory
{
    private string? _filePath;
    public BaseLogger? CreateLogger(string className)
    {
        //have config bool check to see if null?
        if(className == nameof(FileLogger))
        {
            FileLogger fileLogger = new(_filePath!) { className = className };
            //fileLogger.className = className;
            //ConfigureFileLogger(fileLogger.GetFilePath()!);
            return fileLogger;
        }

        return null;
    }

    public string ConfigureFileLogger(string newFilePath)
    {
        if (newFilePath != null && newFilePath != "")
        {
            _filePath = newFilePath;
            return _filePath;
        }
        else
        {
            _filePath = null;//throw an exception?
            throw new ArgumentNullException("File Path not set.");
        }
    }//or make it return a bool to determine success
}
