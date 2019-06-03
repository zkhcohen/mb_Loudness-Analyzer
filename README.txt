DESCRIPTION:

This plugin tags files with their associated EBU R128 loudness metrics. You can use the Settings to select which stats to collect and which Custom Tags to use for tagging.


INSTALLATION:

1. Copy the plugins folder into your MusicBee directory, merging it with your default Plugins folder (or copy the .dll to that location).
2. Copy the Dependencies folder to your MusicBee AppData directory. Copy the ENTIRE folder, not just its contents.
3. Right-click a file to access the Context Menu and go to EBU R128 > Settings, or open the Plugins options in MusicBee Preferences, and then click on the "Configure" button
next to the entry for mb_Loudness_Analyzer.
4. Select which Custom Tags to use. If you don't want a specific stat to appear, select "None".
5. Optionally, configure the names for your Custom Tags and displayed columns.


USAGE:

1. Select 1+ files that you'd like to tag (I don't recommend more than 10 at a time on a low-powered machine with this current alpha build, but up to 100 on a high-powered machine).
2. Right-click and then click EBU R128 > Tag from the Context Menu.
3. Accept the prompt to begin the tagging process. Wait for a couple of seconds (up to 5 for the first file) and then the file tags should quickly begin populating. A prompt will 
appear to notify you once the tagging process is complete.
4. Now that you've tagged files, you can select a group of them (ex. an Album) and then go to EBU R128 > Average, to average the Dynamic Range for the album.