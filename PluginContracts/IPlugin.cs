namespace PluginContracts;

public interface IPlugin
{
    void Execute();
}

[AttributeUsage(AttributeTargets.Class)]
public class PluginLoad : Attribute
{
    public string[] Dependencies { get; set; }

    public PluginLoad(params string[] dependencies)
    {
        Dependencies = dependencies;
    }
}
