using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EXE_Proxy;

public class Config
{
    public static Config Default => new Config()
    {
        FileName = "cmd.exe",
        Arguments = "-c echo hello world",
    };

    public string FileName { get; set; } = string.Empty;
    public string Arguments { get; set; } = string.Empty;
    public bool CreateNoWindow { get; set; }


    public Dictionary<string, string?> Environment = new();


    public string? StandardInputEncoding { get; set; }

    public string? StandardErrorEncoding { get; set; }

    public string? StandardOutputEncoding { get; set; }


    public string WorkingDirectory { get; set; } = string.Empty;

    public bool ErrorDialog { get; set; }
    public int ErrorDialogParentHandle { get; set; }

    public string? UserName { get; set; }

    public string Verb { get; set; } = string.Empty;

    public ProcessWindowStyle WindowStyle { get; set; } = ProcessWindowStyle.Normal;
    public string Domain { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool LoadUserProfile { get; set; }
    public bool UseCredentialsForNetworkingOnly { get; set; }
    public bool UseShellExecute { get; set; }
}