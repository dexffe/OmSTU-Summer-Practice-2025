namespace PluginA;

using PluginContracts;

[PluginLoad]
public class PluginA : IPlugin
{
    public void Execute()
    {
        Console.WriteLine("PluginA");
    }
}
