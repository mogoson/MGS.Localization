# MGS.Localization

## Summary
- Localization utility for project develop.

## Environment
- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Platform
- Windows.

## Demand
- Local text file store multi language paragraph text.
- Utility to get paragraph text in language by key.

## Usage
- Create local text file for language with the separator '='.

```tex
KEY=Value
INT_HW=Hello World
```

- Deserialize language files to Localizer, and get GetParagraph to show.

```C#
//Deserialize language files to Localizer.
foreach (var filePath in languageFiles)
{
    LocalizationAPI.Handler.Deserialize(languageName, languageFile, Encoding.Default);
}

//Get paragraph by key, language name is CultureInfo.CurrentCulture.Name.
var paragraph = LocalizationAPI.Handler.GetParagraph(key);

//Set current language name, get paragraph by key.
LocalizationAPI.Handler.Current = languageName;
var paragraph = LocalizationAPI.Handler.GetParagraph(key);

//Get paragraph by language name and key.
var paragraph = LocalizationAPI.Handler.GetParagraph(languageName, key);
```

## Demo
- Demos in the path "MGS.Packages/Localization/Demo/" provide reference to you.

## Preview

- Hello Word

  ![Hello Word](./Attachment/images/TestInternationalizer.gif)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com