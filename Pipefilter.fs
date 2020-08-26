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

let pFilter =
    let filterIndenticalLines = distinct

    let inputSeq =
        Seq.initInfinite (fun _ -> System.Console.ReadLine())

    try
        for line in inputSeq do
            if isNull line then raise (EndOfSequenceException)

            let uniqueLine = filterIndenticalLines line

            if uniqueLine.IsSome then printfn "%s" uniqueLine.Value
    with EndOfSequenceException -> stdout.Flush()
