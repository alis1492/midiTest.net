using System.Diagnostics;

namespace local.Utils;

public class Player
{
    public static void PlayMidi(string midiFile = "rickRoll.mid", string soundFontPath = "./FluidR3_GM.sf2")
    {
        string processArgs = soundFontPath + " " + midiFile;
        using var process = Process.Start("fluidsynth", processArgs);
        process.WaitForExit();
    }
    public static void PlayWav(string filename)
    {
        string processArgs = $"-autoexit {filename}";
        using var process = Process.Start("ffplay", processArgs);
        process.WaitForExit();
    }
}