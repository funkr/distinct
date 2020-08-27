module MainModule

open System
open Argu

open Pipefilter
open Filefilter


type CLIArguments =
    | File of name: string
    | Trim
    | Version


    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | File _ -> "path and filename of the file which should be processed."
            | Trim _ -> "trim leading or trailing whitespaces of the lines."
            | Version _ -> "prints out the version and exits."


[<EntryPoint>]
let main argv =
    let errorHandler =
        ProcessExiter
            (colorizer =
                function
                | ErrorCode.HelpText -> None
                | _ -> Some ConsoleColor.Red)

    let programName =
        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split "\\"

    let pn = programName.[programName.Length - 1]

    let parser =
        ArgumentParser.Create<CLIArguments>(programName = pn, errorHandler = errorHandler)

    let results = parser.ParseCommandLine argv
    let inputFile = results.GetResults File
    let version = results.Contains Version
    let trim = results.Contains Trim

    if version then
        printfn "This is distinct V0.1a"
    elif inputFile.IsEmpty then
        pFilter trim
    else
        for f in inputFile do
            fFilter f trim

    0 // return an integer exit code
