using TtsApp.Engine;

namespace TtsApp.Console; 

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 2) 
        {
            System.Console.Error.WriteLine($"usage: ttsapp <inputFilePath> <outputFilePath>");
            Environment.Exit(1);
        }

        if (!File.Exists(args[0]))
        {
            System.Console.Error.WriteLine($"{args[0]} is not a file.");
            Environment.Exit(1);
        }

        var engine = new TtsEngine();

        engine.ConvertFile(args[0], args[1]);
    }
}