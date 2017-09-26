# README #

ILMerge-GUI
Graphical interface to the Microsoft ILMerge utility. Makes it merging multiple .NET assemblies easy and hassle-free.

The ILMerge team has no direct relations to this project. So please if you have a question related to ILMerge itself, 
ask them. And if you have a question about this GUI, just post an issue or open a discussion. 

The official [ILMerge](http://research.microsoft.com/en-us/people/mbarnett/ILMerge.aspx).
ILMerge [downloaded](http://www.microsoft.com/en-us/download/details.aspx?id=17630)

### News ###

New ILMerge-GUI version 2.0.9 available!

### Changelog ###

* Added Exit Code.
* Suppress message boxes when /close is detected.
* Changed AppName property (uses Application.ProductName) as after merging the portable version, 'mru' instead of ILMergeGUI is returned. Mru is a assembly merged into the portable version. 
* This might be a bug in ILMerge itself.
* [8754] Added /close.
* [8753] Added fix up for .net 4.6 (like .net 4.5 fix up).
* [8752] False positives seem fixed (rechecked executable at virustotal.com).
* Updated copyright.
* Updated command line help.
* Added current directory as ILMerge location strategy.
* If you like this tool, leave me a note, rate this project or write a review or Donate to ILMergeGui. 
  
If you've encountered problems, leave a (detailed) issue in the Issue Tracker.

### Previous changelog ###
* Added automatic creation of output directory.
* Added default<T> return to GetProperty if invoked value was null.
* Added generated command-line examples.
* Error message when merge tool does not support selected framework.
* Updated the portable version to show a message when the project file specified on the command line is missing.
* Added support for IlRepack (workitem 8746).
* Changed behavior of save menu item.
* Added support for .Net 4.5
* Cleaned code.
* Added menu item for manual check of Click-Once updates.
* Added menu item to visit website.
* Changed frequency and timing of automated Click-Once update checks.
* Added Offline/Portable version.
* Added command line option ( [ /Merge ] [ /? ] <ilproj filename> )
* Added new switches to ilproject file.
* Register file type (and the verbs 'open' and 'merge') for command line usage. For successful registration, ilmergegui has to be run elevated once on systems with UAC enabled.
* Fixed work item 8741.
* Added Internalize support.
* Added support for merging Xml Documentation.
* Added version number to main form (should be 2.0.4 for this release).
* Updated click-once installer.
* Fixed merging assemblies into a dll.
* Rewrote in C#
* Added Drag&Drop Support (files and directories)
* Search for .NET Frameworks
* Search for ILMerge.exe
* x64 support
* .NET 4.0 support
* Save and loading of project settings
* Automatic suggestion of primary assembly
* Bug fixes
* Command line support (filename and /merge switch)
* Relation to the ILMerge tool
