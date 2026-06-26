using System.ComponentModel;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using static local.Utils.Player;
using static local.Utils.Printer;
using static local.Utils.ToMp3Converter;

using NoteNames = Melanchall.DryWetMidi.MusicTheory.NoteName;

// Constants
var zeroTime = new MetricTimeSpan(0);


// Loaded from files data
string filename = "dragonforceBanger.mid";
var file = MidiFile.Read(filename);
var events = file.GetTrackChunks().Select(c => c.Events);
var tempoMap = file.GetTempoMap();


// Main program
string newFilename = "output/slop.mid";

List<int> targetChannels = [0, 2, 5, 13];

foreach(var _event in events)
{
    using var manager = new TimedObjectsManager(_event, ObjectType.Note | ObjectType.TimedEvent | ObjectType.Chord);
    foreach(var _object in manager.Objects)
    {
        if(_object is Note note)
        {
            var timingms = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, tempoMap).TotalMilliseconds;
            if(targetChannels.Contains(note.Channel))
            {
                note.SetNoteNameAndOctave(note.NoteName, note.Octave + 1);
            }
        }
        // if(_object is TimedEvent timedEvent 
        //     && timedEvent.Event is ProgramChangeEvent programChangeEvent)
        // {
        //     var timingms = TimeConverter.ConvertTo<MetricTimeSpan>(timedEvent.Time, tempoMap).TotalMilliseconds;
        // }
    }
    manager.SaveChanges();
}
file.Write(newFilename, true);

string wavname = ToMp3(newFilename);
PlayWav(wavname);
// thats the funniest tinkering project ive ever made xD