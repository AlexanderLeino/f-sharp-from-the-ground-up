open System

[<EntryPoint>]
let main argv = 

    let isEven x = 
        x % 2 = 0

    let numbers = 
        [|
            for i in 1..1000 do 
                let x = i * i 
                x
        |]
        |> Array.sum
    
    let InitNumber = Array.init 1000 (fun i -> i * i)
                    |> Array.sum

    printfn "%A %A" numbers InitNumber
    0
