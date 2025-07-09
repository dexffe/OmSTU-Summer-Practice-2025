namespace task13tests;

using task13;
using ConsoleAppJSON;
using Xunit;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;

public class StudentJsonTest
{
    private const string TestFileName = "studentTest.json";
    private readonly Student studentTest = new Student
    {
        FirstName = "Артём",
        LastName = null,
        BirthDate = new DateTime(2006, 9, 23),
        Grades = new List<Subject>
        {
            new Subject { Name = "Математика", Grade = 5 },
            new Subject { Name = "Физика", Grade = 4 },
            new Subject { Name = "Английский язык", Grade = 3 },
            new Subject { Name = "Китайский язык", Grade = 2 }
        }
    };


    [Fact]
    public void Serialize_Test()
    {
        var json = WorkJSON.Serialize(studentTest);

        Assert.Contains("Артём", json);
        Assert.DoesNotContain("Мартын", json);
        Assert.Contains("23.09.2006", json);
        Assert.Contains("Математика", json);
        Assert.Contains("Физика", json);
        Assert.Contains("Английский язык", json);
        Assert.Contains("Китайский язык", json);
    }

    [Fact]
    public void Deserialize_Test()
    {
        var json = WorkJSON.Serialize(studentTest);
        var student = WorkJSON.Deserialize(json);

        Assert.Equal("Артём", student.FirstName);
        Assert.Null(student.LastName);
        Assert.Equal(new DateTime(2006, 9, 23), student.BirthDate);

    }

    [Fact]
    public void toFile_Test()
    {
        if (File.Exists("studentTest.json")) File.Delete("studentTest.json");

        WorkJSON.toFile(WorkJSON.Serialize(studentTest), "studentTest.json");

        Assert.True(File.Exists("studentTest.json"));
    }
    
    [Fact]
    public void fromFile_Test()
    {
        var json = WorkJSON.Serialize(studentTest);
        WorkJSON.toFile(json, "studentTest.json");

        var student = WorkJSON.Deserialize(WorkJSON.fromFile("studentTest.json"));
        
        Assert.Equal("Артём", student.FirstName);
        Assert.Null(student.LastName);
        Assert.Equal(new DateTime(2006, 9, 23), student.BirthDate);
    }
}
