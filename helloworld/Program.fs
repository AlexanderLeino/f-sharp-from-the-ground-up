// For more information see https://aka.ms/fsharp-console-apps
open System

let sayHello person = 
    printfn "Hello %s from my F# program!" person

let isValid person =
    String.IsNullOrWhiteSpace person |> not

let isAllowed person = 
    person <> "Eve"

[<EntryPoint>]
// let main argv =
//     let validNames = argv |> Array.filter isValid
//     validNames |> Array.iter sayHello
//     printfn "Nice to meet you"
//     0

let main argv = 
    argv 
    |> Array.filter isValid 
    |> Array.filter isAllowed
    |> Array.iter sayHello
    printfn "Nice To meet you" 
    0




