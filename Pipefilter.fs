module Pipefilter

let distinct =
    let mutable seen = []
    fun line ->
        if not (List.contains line seen) then
            seen <- line :: seen
            Some(line)
        else
            None

exception EndOfSequenceException

let pFilter trim =
    let filterIndenticalLines = distinct

    let inputSeq =
        Seq.initInfinite (fun _ -> System.Console.ReadLine())

    try
        for line in inputSeq do
            if isNull line then raise (EndOfSequenceException)

            let line =
                match trim with
                | true -> line.Trim()
                | false -> line

            let uniqueLine = filterIndenticalLines line

            match uniqueLine with
            | Some x -> printfn "%s" x
            | None -> printf ""

    with EndOfSequenceException -> stdout.Flush()
