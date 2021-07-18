[TOC]

﻿# MGS.DesignPattern.dll

## Summary

- Design pattern code for C# project develop.

## Environment

- .Net Framework 3.5 or above.

## Dependence

- System.dll

## Demand

- Provide a single instance of the specified type T.
- Generic object pool.

## Implemented

### ObjectPool

```C#
/// <summary>
/// Generic object pool.
/// </summary>
/// <typeparam name="T">Specified type of object.</typeparam>
public abstract class ObjectPool<T>{}

/// <summary>
/// Generic object pool.
/// </summary>
public class GenericPool<T> : ObjectPool<T> where T : IResettable, new()
```

### Singleton

```C#
/// <summary>
/// Provide a single instance of the specified type T;
/// Inheritance class should with the sealed access modifier
/// and a private parameterless constructor to ensure singleton.
/// </summary>
/// <typeparam name="T">Specified type.</typeparam>
public abstract class Singleton<T> where T : class{}

/// <summary>
/// Provide a single instance with a timer to tick update for the specified type T;
/// Inheritance class should with the sealed access modifier
/// and a private parameterless constructor to ensure singleton.
/// </summary>
/// <typeparam name="T">Specified type.</typeparam>
public abstract class SingleTimer<T> : Singleton<T> where T : class{}
```

## Usage

### ObjectPool

```C#
//Implement custom object.
public class CustomObject : IResettable
{
    public void Reset()
    {
        //TODO: Reset the object.
    }

    public void Dispose()
    {
        //TODO: Dispose the object.
    }
}

//Use GenericPool in your class.
public class TestCase
{
    public TestCase()
    {
        //Create pool for CustomObject.
        var pool = new GenericPool<CustomObject>();

        //Take a instance of CustomObject from pool.
        var obj = pool.Take();

        //Recycle object to pool if we do not need it.
        pool.Recycle(obj);
    }
}
```

### Singleton

```C#
//Custom classs with a single instance.
public sealed class TestSingleton : Singleton<TestSingleton>
{
    public string testField = "Test Field";

    //Private parameterless constructor to ensure singleton.
    private TestSingleton() { }
}

//Use Instance to accessing fields, properties and methods. 
var testInfo = TestSingleton.Instance.testField;
```

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com