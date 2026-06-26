# Personal Midi Tinkering repo

A simple repo that uses fluidsynth and ffplay to play midi files, also WetDryMIDI library from nuget to modify MIDI files

## Requirements

ffplay  
fluidsynth  
Melanchall.DryWetMidi nuget package  
dotnet runtime 8+  
sound font for fluidsynth (FluidR3_GM.sf2 is recommended)  

## NOTES

For nixos users, theres a shell.nix file that installs ffmpeg (ffplay included) and fluidsynth and runs vscode   
note: dotnet environment only works for vscode-fhs with extraPackages listing dotnet runtime/sdk and its dependencies  
I used nix channel 25.11 and dotnet sdk 9.0  
Have fun ^_^;
