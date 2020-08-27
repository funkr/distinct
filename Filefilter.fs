module Filefilter

let fFilter fileName trim =
    System.IO.File.Copy(fileName, fileName + ".in")

    let bashHistory =
        System.IO.File.ReadAllLines fileName
        |> Array.toList

    let cleanHistory: List<string> = List.distinct bashHistory

    let cleanHistory =
        if trim
        then cleanHistory |> List.map (fun x -> x.Trim())
        else cleanHistory

    System.IO.File.WriteAllLines(fileName, cleanHistory)
    System.IO.File.Delete(fileName + ".in")
