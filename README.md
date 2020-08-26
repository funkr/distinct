# distinct
A simple commandline tool to remove duplicate lines in a text file. Its a further development of the `uniq` command, 
`uniq` just removes consecutive lines but `distint` remove every double enttry.

This is my first try in F#. Any comments are welcome. 

If you wonder what the use case is for this. I am a Java backend developer and I work a lot with the command line and the bash history is kind of brain extention to me.
Because I simply cannot write down any useful command I ever used, so I look up in the history. But over the time I found my relevant 
commands often buried under a load of trivial commands like `ls`, and finally they drop out, due to the size of the historyfile. Of course has the bash a function to optimize the history but it is not very powerful eg.:
    ls -l
    history
    ls- l
    history
    
Bash is not optimizing this sequence and pattern like this occures quite often. I put this command into my starting batch file which I user every morning.

## Examples
    cat .\testdata\duplicates.txt | .\bin\release\netcoreapp3.1\win-x64\distinct.exe

    .\bin\release\netcoreapp3.1\win-x64\distinct.exe --file .\testdata\duplicates.txt
