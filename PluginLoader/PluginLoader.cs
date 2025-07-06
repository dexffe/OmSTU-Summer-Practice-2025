namespace PluginLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using PluginContracts;

public class PluginLoader
{
    private Dictionary<string, (Type type, string[] dependencies, bool isLoaded)> plugins = new();
    private HashSet<string> loadedPlugins = new();

    public void LoadPlugins()
    {
        var projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../.."));
        var pluginsPath = Path.Combine(projectRoot, "PluginsDll");
        var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");

        foreach (var dll in pluginFiles)
        {
            var assembly = Assembly.LoadFile(dll);

            foreach (var type in assembly.GetTypes())
            {
                var attribute = type.GetCustomAttribute<PluginLoad>();
                if (attribute != null && typeof(IPlugin).IsAssignableFrom(type))
                {
                    plugins[type.Name] = (type, attribute.Dependencies, false);
                }
            }
        }

        foreach (var pluginName in plugins.Keys.ToList())
        {
            LoadPlugin(pluginName);
        }
    }

    private void LoadPlugin(string pluginName)
    {
        if (plugins[pluginName].isLoaded) return;

        if (loadedPlugins.Contains(pluginName)) throw new Exception($"Plugin {pluginName} is already loaded");

        loadedPlugins.Add(pluginName);
        foreach (var dependency in plugins[pluginName].dependencies)
        {
            LoadPlugin(dependency);
        }

        var plugin = Activator.CreateInstance(plugins[pluginName].type) as IPlugin;
        plugin?.Execute();

        plugins[pluginName] = (plugins[pluginName].type, plugins[pluginName].dependencies, true);
        loadedPlugins.Remove(pluginName);
    }

    public int GetPluginCountForTest() => plugins.Count;
}
