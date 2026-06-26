{ pkgs ? import <nixpkgs> {} }:
pkgs.mkShell {
  allowUnfree = true;

  packages = with pkgs; [
	fluidsynth
    ffmpeg
  ];

  #packages = [
  #  pkgs.omnisharp-roslyn
  #  pkgs.netcoredbg
  #];

  shellHook = ''
    code .
  '';
}
