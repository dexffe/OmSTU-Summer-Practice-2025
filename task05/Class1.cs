namespace task05;

using System;
using System.Reflection;
using System.Collections.Generic;

public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;
    }

    public IEnumerable<string> GetPublicMethods()
    {
        var metods = _type.GetMethods();
        var publicMetods = metods.Where(m => m.IsPublic);
        var namesPublicMetods = publicMetods.Select(m => m.Name);

        return namesPublicMetods;
    }

    public IEnumerable<string> GetMethodParams(string methodname)
    {
        var ourMetod = _type.GetMethod(methodname);
        var parametersOurMetod = ourMetod?.GetParameters();
        var namesParametersOurMetod = parametersOurMetod?.Select(p => p.Name);

        return namesParametersOurMetod!;
        

    }

    public IEnumerable<string> GetAllFields()
    {
        var allFields = _type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        var namesAllFields = allFields.Select(f => f.Name);

        return namesAllFields;
    }

    public IEnumerable<string> GetProperties()
    {
        var allPriorety = _type.GetProperties();
        var namesAllProperties = allPriorety.Select(p => p.Name);    

        return namesAllProperties;
    }

    public bool HasAttribute<T>() where T : Attribute
    {
        var attributes = _type.GetCustomAttributes(typeof(T), false);
        var IsNotNull = attributes.Length > 0;
        return IsNotNull;
    }
    
}
