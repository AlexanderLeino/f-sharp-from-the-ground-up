// For more information see https://aka.ms/fsharp-console-apps
open System
open System.IO
open StudentScores
open Student
open Summary

[<EntryPoint>]
    let main argv = 
        if argv.Length = 1 then
            let filePath = argv.[0]

            if  File.Exists filePath then
                printfn "Processing %s" filePath
                Summary.summarize filePath
                0
            else 
                printfn "File Not Found: %s" filePath
                2
        else 
            printfn "Please specify a file"
            1

