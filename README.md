## Project Description

Simple project where the user can add synonyms to a dictionary and also search for synonyms to a specific word.
All settings are made in code and no UI is implemented at this time.


## Use

Project is ready to run as soon as it is opened in your favorite IDE. No installation of nuget-packages or other tools.
In-line comments provide some guidance regarding of data that can be added or changed.


## Known Issues

Currently, synonym groups are not fully cross-linked (transitive synonyms are not included).
For example, if the following lists are added:
- ["huge", "large"]
- ["enormous", "large"]

then searching for "huge" will not return "enourmous". Searching for "Large" on the other hand,
will return both "huge" and "enormous". There are ways to fix this but not in the scope of this project as of right now.
