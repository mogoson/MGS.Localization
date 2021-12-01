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
    Localizer.Instance.Deserialize(languageName, languageFile, Encoding.Default);
}

//Get paragraph by key, language name is CultureInfo.CurrentCulture.Name.
var paragraph = Localizer.Instance.GetParagraph(key);

//Set current language name, get paragraph by key.
Localizer.Instance.Current = languageName;
var paragraph = Localizer.Instance.GetParagraph(key);

//Get paragraph by language name and key.
var paragraph = Localizer.Instance.GetParagraph(languageName, key);
```

## Demo
- Demos in the path "MGS.Packages/Localization/Demo/" provide reference to you.

## Preview

- Hello Word

  ![Hello Word](./Attachment/images/TestInternationalizer.gif)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com