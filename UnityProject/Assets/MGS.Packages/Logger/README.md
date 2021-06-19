# MGS.Logger

## Summary
- Logger for C# project develop.
- Logger for Unity project.

## Environment

- Unity 5.0 or above.

- .Net Framework 3.5 or above.

## Platform
- Windows

## Demand
- Output log to local file.
- Implement custom logger to output the log that print by LogUtility from other module.

## Implemented

### MGS.Logger.dll

- ILogger: Interface of logger.

- LogUtility: provide unified entrance of log output.
- FileLogger: provide a default logger that you can use to log to local file.

### MGS.ULogger.dll

- LogUtilityInitializer: Register a FileLogger to LogUtility.

### MGS.ULoggerEditor.dll

- UnityDebugger: Implemente ILogger base Unity Debug.
- LogUtilityEditor: Register a UnityDebuggerto LogUtility.

## Usage
- Use LogUtility to output log content.

```C#
//The log output at Unity console in editor mode;
//and write to local file at the path:
//string.Format("{0}/Log/", Application.persistentDataPath)

LogUtility.Log("Log info is {0}", info);
LogUtility.LogError("Log error is {0}", error);
LogUtility.LogWarning("Log warning is {0}", warning);
```

- Override log path.

```c#
//Delete MGS.ULogger.dll
//new a FileLogger with custom log file path;
//Register the FileLogger to LogUtility.

var logDir = string.Format("{0}/Log/", Environment.CurrentDirectory);
LogUtility.Register(new FileLogger(logDir));
```

- Override the Logger of LogUtility.

```C#
//Delete MGS.ULogger.dll
//Implemente a CustomLogger;
//Register the CustomLogger to LogUtility.

public class CustomLogger : ILogger
{
  public void Log(string format, params object[] args)
  {
    //Implemente the logic.
  }

  public void LogError(string format, params object[] args)
  {
    //Implemente the logic.
  }

  public void LogWarning(string format, params object[] args)
  {
    //Implemente the logic.
  }
}

LogUtility.Register(new CustomLogger());
```


## Demo

- Demos in the path "MGS.Logger/Scenes" provide reference to you.

## Source

- https://github.com/mogoson/MGS.Logger.
------

Copyright © 2021 Mogoson.	mogoson@outlook.com