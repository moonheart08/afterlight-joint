using System;
using Robust.Client;

namespace Content.ALED;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("AWAWA");
        ContentStart.StartLibrary(args, new GameControllerOptions
        {
            Sandboxing = false,
            ConfigFileName = "aled_config.toml",
            UserDataDirectoryName = "AfterlightEditor",
        });
    }
}
