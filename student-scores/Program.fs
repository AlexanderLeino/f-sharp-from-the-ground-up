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
                try
                Summary.summarize filePath
                0
                with
                | :? FormatException as e ->
                    printfn "Error: %s" e.Message
                    printfn "The file was not in the expected format"
                    1
                | :? IOException as e ->
                printfn "Error: %s" e.Message
                printfn "The file is open in another program, please close it"
                3
                | _ as e -> printfn "Unexpected error: %s" e.Message
                4
            else 
                printfn "File Not Found: %s" filePath
                2
        else 
            printfn "Please specify a file"
            5

