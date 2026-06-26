using System.Diagnostics;

namespace local.Utils;

public class ToMp3Converter
{
    public static string ToMp3(string midiFile = "rickRoll.mid", string soundFontPath = "./FluidR3_GM.sf2")
    {
        string filename = midiFile[..midiFile.IndexOf(".mid")];

        var psi = new ProcessStartInfo
        {
            FileName = "fluidsynth",
            Arguments = $"-l -T wav -F {filename}.wav {soundFontPath} {midiFile}"
        };

        var process = Process.Start(psi)
            ?? throw new Exception("no process resource is started");
        process.WaitForExit();

        return $"{filename}.wav";
    }
}