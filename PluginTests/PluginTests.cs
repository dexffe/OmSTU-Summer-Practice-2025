namespace PluginTests;

using Xunit;
using PluginLoader;
using PluginContracts;
using System.IO;

public class PluginTests
{
    [Fact]
    public void Loader_ShouldFindThreePlugins()
    {
        var loader = new PluginLoader();
        loader.LoadPlugins();

        Assert.Equal(3, loader.GetPluginCountForTest());
    }
}
