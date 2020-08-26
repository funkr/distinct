module Filefilter

let fFilter fileName =
    System.IO.File.Copy(fileName, fileName + ".in")

    let bashHistory =
        System.IO.File.ReadAllLines fileName
        |> Array.toList

    let cleanHistory = List.distinct bashHistory

    System.IO.File.WriteAllLines(fileName, cleanHistory)
    System.IO.File.Delete(fileName + ".in")
