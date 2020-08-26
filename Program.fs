module MainModule

open System
open Argu

open Pipefilter
open Filefilter

type CLIArguments = 
    | File of name:string
    | Version 
    | EndOfLine

    
    interface IArgParserTemplate with 
        member s.Usage =
            match s with
                | File  _ -> "Path and filename of the file which should be processed."
                | EndOfLine _ -> "Put an EOL Character at the end of the file. An option to stay POSIX conform, but unwanted in pipe mode."
                | Version _ -> "Prints out the version and exits."


[<EntryPoint>]
let main argv =
    let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some ConsoleColor.Red)
    let programName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split "\\" 
    let pn = programName.[programName.Length-1]
    let parser = ArgumentParser.Create<CLIArguments>(programName = pn, errorHandler=errorHandler)
    let results = parser.ParseCommandLine argv
    let inputFile = results.GetResults File
    let endOfLine = results.Contains EndOfLine
    let version = results.Contains Version

    if version 
    then
        printfn "This is distinct V0.1a"
    elif inputFile.IsEmpty 
    then
        printfn "Goto pipe mode End of Line:%b" endOfLine
        pipe endOfLine
    else
        for f in inputFile do
            printfn "Goto file mode %s End of Line:%b" f endOfLine 
            pFilter f endOfLine

        
    0    // return an integer exit code