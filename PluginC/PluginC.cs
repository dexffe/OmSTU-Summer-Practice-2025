namespace PluginC;

using PluginContracts;

[PluginLoad("PluginB")]
public class PluginC : IPlugin
{
    public void Execute()
    {
        Console.WriteLine("PluginC executed PluginB");
    }
}
