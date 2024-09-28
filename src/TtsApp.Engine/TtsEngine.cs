using System.Speech.Synthesis;

namespace TtsApp.Engine;

public class TtsEngine
{
    /// <summary>
    ///     Speech rate. 0 is "normal". 
    /// </summary>
    public int SpeechRate { get; set; }

    /// <summary>
    ///     Volume, 0-100
    /// </summary>
    public int Volume { get; set; } = 100;

    /// <summary>
    ///     Voice gender
    /// </summary>
    public VoiceGender VoiceGender { get; set; }

    /// <summary>
    ///     Voice age
    /// </summary>
    public VoiceAge VoiceAge { get; set; }

    public void ConvertFile(string inputFilePath, string outputFilePath)
    {
        if (!File.Exists(inputFilePath)) throw new FileNotFoundException();

        using SpeechSynthesizer synth = new SpeechSynthesizer
        {
            Rate = SpeechRate,
            Volume = Volume,
        };

        synth.SelectVoiceByHints(VoiceGender, VoiceAge);
        synth.SetOutputToWaveFile(outputFilePath);

        string content = File.ReadAllText(inputFilePath);

        synth.Speak(content);
    }

    public async Task ConvertFileAsync(string inputFilePath, string outputFilePath)
    {
        if (!File.Exists(inputFilePath)) throw new FileNotFoundException();

        using SpeechSynthesizer synth = new SpeechSynthesizer
        {
            Rate = SpeechRate,
            Volume = Volume,
        };

        synth.SelectVoiceByHints(VoiceGender, VoiceAge);
        synth.SetOutputToWaveFile(outputFilePath);

        string content = await File.ReadAllTextAsync(inputFilePath);

        synth.Speak(content);
    }
}
