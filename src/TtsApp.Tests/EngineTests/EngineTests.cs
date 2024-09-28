using TtsApp.Engine;

namespace TtsApp.Tests.EngineTests;

[TestClass]
public class EngineTests
{
    [TestMethod]
    public void TestEngine()
    {
        var inputPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "EngineTests", "sample.txt");
        var outputPath = inputPath + ".wav";

        new TtsEngine().ConvertFile(inputPath, outputPath);
    }
}