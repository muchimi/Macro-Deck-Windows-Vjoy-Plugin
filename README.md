# Macro-Deck-Windows-Vjoy-Plugin

This is a MacroDeck plugin that adds VJOY and keyboard output specifically for gaming.
This is a pre-release version and may include bugs or is missing intended features.

I wrote this plugin because I needed to be able to send input via a touch screen to a VJOY device, and I also needed more granular control over keyboard output than what is included with Macro-Deck.
Specifically the abilityt to have a key down event separate from a key up event.

## Requirements

You need VJOY and Macro-Deck installed.  The release is compiled for AnyCPU but is meant to work with 64 bit Windows.
The current version is compiled against .NET CORE 3.1

## Installation

Place the muchimi.vjoy folder in the zip file to %appdata%\macro deck\plugin folder.

## VJOY consideration

The plugin needs a pair of DLLs to function correctly that match the version of VJOY you have installed.  On Windows 10/Windows 11 this should be the x64 version.
The particular version I use is 2.2.1.0 at the time of compilation, but you can replace the vJoyInterface.dll and vJoyInterfaceWrap.dll with the version you have installed on your machine.
The location of the default VJOY installation is usually C:\Program Files\Vjoy

## Project references

MacroDeck: https://github.com/Macro-Deck-org/Macro-Deck
VJoy: https://github.com/njz3/vjoy
