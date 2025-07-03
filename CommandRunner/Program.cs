namespace CommandRunner;

using CommandLib;
using System.Reflection;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom("FileSystemCommands.dll");

        var typeDirSize = assembly.GetType("FileSystemCommands.DirectorySizeCommand");
        if (typeDirSize != null)
        {
            var commandDirSize = (ICommand?)Activator.CreateInstance(typeDirSize, args[0]);
            commandDirSize?.Execute();
        }
        

        var typeFindFiles = assembly.GetType("FileSystemCommands.FindFilesCommand");
        if (typeFindFiles != null)
        {
            var commandFindFiles = (ICommand?)Activator.CreateInstance(typeFindFiles, args[0], args[1]);
            commandFindFiles?.Execute();
        }
        
    }
}
