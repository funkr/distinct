module Filefilter

let appendEol (eol: bool, lines: List<'string>) =
    if eol then
        let lastelem = List.last lines
        let a = lastelem = "\n"
        printf "add %s %i %b %i " lastelem lastelem.Length a "\n".Length
        let l = lines @ [ "\n" ]
        l
    else
        lines

let appEol (eol: bool, text: string) =
    if eol && not (text.[text.Length - 1].Equals("\n"))
    then text + "\n"
    else text

let pFilter fileName eol =
    System.IO.File.Copy(fileName, fileName + ".in")

    let bashHistory =
        System.IO.File.ReadAllLines fileName
        |> Array.toList

    let cleanHistory = List.distinct bashHistory

    //let cleanHistory =
    //    appendEol (eol, cleanHistory) |> List.toArray

    printf "%i" cleanHistory.Length

    let ch = cleanHistory |> String.concat "\n"
    let ch = appEol (eol, ch)

    System.IO.File.WriteAllText(fileName, ch)
    System.IO.File.Delete(fileName + ".in")
