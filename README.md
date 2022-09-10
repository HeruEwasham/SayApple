# SayApple
A small wrapper around the built-in say-command in Mac terminal

## How To use

### Main commands
All the main commands is in the static class Say. It is 5 main commands that have some overloads:
- SayAsync(..) - Reads the given text aloud out through the speakers.
- ReadToFileAsync(..) - Reads the given text into an audio file in a supported format (like .aiff).
- SayFromFileAsync(..) - Reads text from a given file aloud out through the speakers.
- ReadFromFileToFileAsync(..) - Reads the text from a given file and outputs it into an audio file in a supported format (like .aiff).
- GetInstalledSpeechesAsync() - Returns a list of voices/speeches that is installed on the system.

To understand more of the possibillities the Say-command can do, you can for instance read this blog-post from Medium: https://maithegeek.medium.com/having-fun-in-macos-with-say-command-d4a0d3319668

### The Speech class
The Speech-class is used to show/define different voices. It has the properties Name, CountryCode and Quote, which is all given from what Apple returns.

A list of speeches (List<Speech>) have also some extensions:
- GetByCountryCode(..) - Gets all speeches with the given country-code in the source-list.
- GetCountryCodes() - Gets all country-codes the list of speeches contains.