namespace ConsoleAppJSON;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using task13;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;

public class CustomDate : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == null) throw new JsonException("Date is null");
            return DateTime.ParseExact(value, "dd.MM.yyyy", null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd.MM.yyyy"));
        }
    }

public class WorkJSON
{

    public static void Main(string[] args)
    {
        var student = new Student
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

        Console.WriteLine("Serialize:");
        var jsonString = Serialize(student);
        Console.WriteLine(jsonString);

        Console.WriteLine("Deserialize:");
        var studentFromJson = Deserialize(jsonString);
        Console.WriteLine(studentFromJson);

        Console.WriteLine("toFile and fromFile:");
        toFile(jsonString, "studentTest.json");
        var jsonFromFile = fromFile("studentTest.json");
        Console.WriteLine(jsonFromFile);
    }
    public static string Serialize(Student student)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        options.Converters.Add(new CustomDate());

        return JsonSerializer.Serialize(student, options);
    }

    public static Student Deserialize(string json)
    {
        if (json.Length == 0) throw new ArgumentNullException(nameof(json));

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        options.Converters.Add(new CustomDate());

        var student = JsonSerializer.Deserialize<Student>(json, options);
        if (student == null) throw new ArgumentNullException(nameof(student));
        return student;
    }

    public static void toFile(string json, string path)
    {
        File.WriteAllText(path, json);
    }

    public static string fromFile(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException();
        return File.ReadAllText(path);
    }
}
