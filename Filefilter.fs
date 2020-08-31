module Filefilter

let fFilter fileName trim =
    System.IO.File.Copy(fileName, fileName + ".in")

    let bashHistory =
        System.IO.File.ReadAllLines fileName
        |> Array.toList
        |> List.map (fun x -> if trim then x.Trim() else x)
        |> List.distinct

    System.IO.File.WriteAllLines(fileName, bashHistory)
    System.IO.File.Delete(fileName + ".in")
