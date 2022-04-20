// handle arguments
try { HandleArgs(); } catch (Exception e) { Console.WriteLine(e.Message); Environment.Exit(-1); }

// output the generated string
var password = RandomString(Config.length, Config.characters);
Console.WriteLine(Config.copy ? $"Copied {password}" : password);
// if (Config.copy) ;

static string RandomString(int length, string chars)
{
    Random random = new Random();
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
}

static void HandleArgs() {
    var args = Environment.GetCommandLineArgs();
    if (args.Contains("help") || args.Contains("-h") || args.Contains("--help") || args.Contains("-?") || args.Contains("?"))
        WriteHelp();
    if (args.Contains("-l")) {
        bool parseSuccessful = int.TryParse(GetArgValue(args, "-l"), out int length);
        if (!parseSuccessful) throw new InvalidCastException("Failed to convert -l argument value to a number");
        Config.length = length;
    }
    if (args.Contains("-e")) {
        char[]? excludeChars = GetArgValue(args, "-e").ToCharArray();
        Config.characters = ReplaceAll(Config.characters, excludeChars, "");
    }
    //if (args.Contains("--copy")) Config.copy = true;
    if (args.Contains("-c")) Config.characters = GetArgValue(args, "-c");
    if (args.Contains("-o")) {
        string path = GetArgValue(args, "-o");
        if (string.IsNullOrEmpty(path.Trim())) throw new InvalidDataException("File path cannot be null or empty");
        var password = RandomString(Config.length, Config.characters);
        File.AppendAllText(path, password + "\n");
        Console.WriteLine($"Password saved in {path}");
        Environment.Exit(0);
    }
}

static string GetArgValue(string[] argArray, string arg) {
    var argPosition = Array.IndexOf(argArray, arg);
    string? argValue = null;
    try { argValue = argArray.GetValue(argPosition + 1)!.ToString(); } catch {}
    if (argValue == null) throw new Exception($"Parameter {arg} has to be followed by a valid value");
    return argValue;
}

static string ReplaceAll(string seed, char[] chars, string replacementCharacter)
{
    return chars.Aggregate(seed, (str, cItem) => str.Replace(cItem.ToString(), replacementCharacter));
}

static void WriteHelp() {
    Console.WriteLine(
      "-l       Length of the password\n" +
      "-e       List of characters to exclude\n" +
      "-c       List of characters to include\n" +
      "-o       File path to output the password to\n" +
      // "--copy   Copies the generated password to the clipboard\n" +
      "\n" +
      "Example usage:\n" +
      "genpass -e \\!\\&\\(\\)\\$\\?\\;\\*\\\\\\*\\'\\\"\\`\\<\\> -l 50"  
    );
    Environment.Exit(0);
}

public static class Config {
    public static bool copy { get; set; } = false;
    public static string characters { get; set; } = 
    "qwertyuiopasdfghjklzxcvbnm" 
    + "QWERTYUIOPASDFGHJKLZXCVBNM" 
    + "1234567890" 
    + "`~!@#$%^&*()_+-=[];'{}:\"\\,.<>/?";
    public static int length { get; set; } = 100;
}
