namespace PluginB;

using PluginContracts;


[PluginLoad("PluginA")]
public class PluginB : IPlugin
{
    public void Execute()
    {
        Console.WriteLine("PluginB executed PluginA");
    }
}
