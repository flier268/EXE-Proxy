// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;
using System.Text.Json;
using EXE_Proxy;

string configFilePath = Path.ChangeExtension(Environment.GetCommandLineArgs()[0], "json");

if (!File.Exists(configFilePath))
{
    File.WriteAllText(configFilePath, JsonSerializer.Serialize(Config.Default, SourceGenerationContext.Default.Config));
    Console.WriteLine($"Created a new configuration file at {configFilePath} with default values");
    Console.WriteLine("Press Enter to exit.");
    Console.ReadLine();
    Environment.Exit(-1);
    return;
}

try
{
    string jsonString = File.ReadAllText(configFilePath);
    var config = JsonSerializer.Deserialize(jsonString, SourceGenerationContext.Default.Config);

    if (config is null)
    {
        File.Move(configFilePath, $"{configFilePath}.bak");
        File.WriteAllText(configFilePath, JsonSerializer.Serialize(Config.Default, SourceGenerationContext.Default.Config));
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
        Environment.Exit(-1);
        return;
    }

    SecureString? securePassword = null;
    if (!string.IsNullOrEmpty(config.Password))
    {
        securePassword = new();
        foreach (char c in config.Password)
            securePassword.AppendChar(c);
    }

    var startInfo = new ProcessStartInfo
    {
        Arguments = config.Arguments,
        CreateNoWindow = config.CreateNoWindow,
        Domain = config.Domain,
        ErrorDialog = config.ErrorDialog,
        ErrorDialogParentHandle = config.ErrorDialogParentHandle,
        FileName = config.FileName,
        LoadUserProfile = config.LoadUserProfile,
        UseCredentialsForNetworkingOnly = config.UseCredentialsForNetworkingOnly,
        Password = securePassword,
        StandardErrorEncoding = config.StandardErrorEncoding is null ? null : Encoding.GetEncoding(config.StandardErrorEncoding),
        StandardInputEncoding = config.StandardInputEncoding is null ? null : Encoding.GetEncoding(config.StandardInputEncoding),
        StandardOutputEncoding = config.StandardOutputEncoding is null ? null : Encoding.GetEncoding(config.StandardOutputEncoding),
        UserName = config.UserName,
        UseShellExecute = config.UseShellExecute,
        Verb = config.Verb,
        WindowStyle = config.WindowStyle,
        WorkingDirectory = config.WorkingDirectory,
        RedirectStandardError = true,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
    };
    foreach (var env in config.Environment)
    {
        startInfo.Environment.Add(env);
    }

    var p = new Process
    {
        StartInfo = startInfo,
    };

    p.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
    p.ErrorDataReceived += (sender, args) => Console.Error.WriteLine(args.Data);

    p.Start();

    p.BeginOutputReadLine();
    p.BeginErrorReadLine();

    while (Console.ReadLine() is { } line)
    {
        p.StandardInput.WriteLine(line);
    }

    p.WaitForExit();
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
}