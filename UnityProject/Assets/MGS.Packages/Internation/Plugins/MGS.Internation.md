[TOC]

﻿# MGS.Internation.dll

## Summary

- International utility for project develop.

## Environment

- .Net Framework 3.5 or above.

## Dependence

- System.dll
- MGS.Logger.dll
- MGS.DesignPattern.dll

## Demand

- Local text file store multi language paragraph text.
- Utility to get paragraph text in language by key.

## Implemented

- Internationalizer: Load language paragraph text from local text file and get a paragraph text in language by key.

## Usage
- Create local text file for language with the separator '='.

```tex
KEY=Value
INT_HW=Hello World
```

- Deserialize language files to Internationalizer, and get GetParagraph to show.

```C#
//Deserialize language files to Internationalizer.
foreach (var filePath in languageFiles)
{
    Internationalizer.Instance.Deserialize(languageName, languageFile, Encoding.Default);
}

//Get paragraph by key, language name is CultureInfo.CurrentCulture.Name.
var paragraph = Internationalizer.Instance.GetParagraph(key);

//Set current language name, get paragraph by key.
Internationalizer.Instance.Current = languageName;
var paragraph = Internationalizer.Instance.GetParagraph(key);

//Get paragraph by language name and key.
var paragraph = Internationalizer.Instance.GetParagraph(languageName, key);
```

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com