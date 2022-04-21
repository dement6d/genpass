using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Genpass
{
    public class SysInfo {
        public static OSPlatform OS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? OSPlatform.Windows : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) 
            ? OSPlatform.Linux : OSPlatform.OSX;
    }
    public class Clipboard
    {
        public static async Task Copy(string content) {
            switch (SysInfo.OS)
            {
                case {} os when os == OSPlatform.Linux || os == OSPlatform.OSX:
                    await CopyLinux(content);
                    break;
                case {} os when os == OSPlatform.Windows:
                    await CopyWindows(content);
                    break;
                default:
                    Console.WriteLine("Copying to clipboard not supported on this OS");
                    break;
            }
            return;
        }
        protected static async Task CopyWindows(string content) {
            await Process.Start(new ProcessStartInfo{
                FileName = "cmd.exe",
                Arguments = "/C \" " + $"powershell Set-Clipboard \"{content}\"" + " \"",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            })!.WaitForExitAsync();
            return;
        }
        protected static async Task CopyLinux(string content) {
            Console.WriteLine("Password: " + content);
            await Process.Start(new ProcessStartInfo{
                FileName = "/bin/bash",
                Arguments = $"-c \"echo \"{content}\" | xclip -selection clipboard\"",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            })!.WaitForExitAsync();
            return;
        }
    }
}