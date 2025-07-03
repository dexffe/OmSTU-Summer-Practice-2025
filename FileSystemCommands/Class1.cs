namespace FileSystemCommands;

using CommandLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DirectorySizeCommand : ICommand
{
    private string dirPath;
    public long dirSize = 0;
    public DirectorySizeCommand(string directoryPath)
    {
        this.dirPath = directoryPath;
    }
    public void Execute()
    {
        if (!Directory.Exists(this.dirPath)) return;

        dirSize = Directory.EnumerateFiles(this.dirPath, "*", SearchOption.AllDirectories)
            .Sum(file => new FileInfo(file).Length);
    }
}

public class FindFilesCommand : ICommand
{
    private string dirPath;
    private string pattern;
    public List<string> patternFiles = new();

    public FindFilesCommand(string directoryPath, string searchPattern)
    {
        this.dirPath = directoryPath;
        this.pattern = searchPattern;
    }

    public void Execute()
    {
        if (!Directory.Exists(this.dirPath)) return;

        patternFiles = Directory.EnumerateFiles(this.dirPath, this.pattern, SearchOption.AllDirectories).ToList();
    }
}
