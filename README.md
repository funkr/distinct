# distinct
A simple commandline tool to remove duplicate lines in a text file. Its a further development of the `uniq` command, 
`uniq` just removes consecutive lines but `distinct` remove every double entry.

This is my first try in F#. Any comments are welcome. 

If you wonder what the use case is for this. I am a Java backend developer and I work a lot with the command line. The bash history is a kind of brain extention to me,
because I simply cannot write down any useful command I ever used. So I look them up in the history. But over the time I found my relevant 
commands often buried under a load of trivial commands like `ls`, and finally they drop out, due to the size of the historyfile. Of course has the bash also function to optimize the history, but it is not very powerful eg.:
    
    ls -l
    history
    ls- l
    history
    
Bash does not optimize a sequence like this, and this pattern occures quite often. I put this command into my starting batch file which I user every morning. I start with a declutterd brain.

## Examples
    cat .\testdata\duplicates.txt | .\bin\release\netcoreapp3.1\win-x64\distinct.exe

    .\bin\release\netcoreapp3.1\win-x64\distinct.exe --file .\testdata\duplicates.txt
    
## Usage
    
    USAGE: distinct.exe [--help] [--file <name>] [--version]

    OPTIONS:

        --file <name>         Path and filename of the file which should be processed.
        --version             Prints out the version and exits.
        --help                display this list of options.
