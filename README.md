# distinct
A simple commandline tool to remove duplicate lines in a test file. Its a further development of the `uniq` command, 
Because `uniq` just removes consecutive lines. `distint` remove every double enttry.

This is my first try in F#. Do please be graceful with me. Any comments are welcome.

If you wonder what the usecase is for this. I am a Java backend developer and I work a lot with on the commandline and 
I simply cannot note down any useful command I ever used, so I look up in the history but I found the relevant 
commands often enough buried under a load of trivial commands like `ls` and finally they drop out due to the size of the historyfile.

## Examples
    cat .\testdata\duplicates.txt | .\bin\release\netcoreapp3.1\win-x64\distinct.exe

    .\bin\release\netcoreapp3.1\win-x64\distinct.exe --file .\testdata\duplicates.txt
