namespace Student
open StudentScores

type Student = 
    {
        Surname : string
        GivenName : string
        Id : string
        MeanScore: float
        MinScore: float
        MaxScore: float
    }

module Student = 

    let nameParts (s: string) = 
        let elements = s.Split(',')
        match elements with 
        | [|surname; givenName|] ->
            {|  
                Surname = surname.Trim() 
                GivenName = givenName.Trim()
            |}

        | [|surname|] ->        
            {|  
                Surname = surname.Trim()
                GivenName = "(None)"
            |}
        | _ -> 
            raise (System.FormatException(sprintf "Invalid Name Format: \"%s\""s))

    let fromString (s : string) =
        let elements = s.Split('\t')
        let name = elements |> Array.tryHead |> Option.map nameParts
        let id = Array.item 1 elements
        let scores = 
            elements
            |> Array.skip 2
            |> Array.map TestResult.fromString
            |> Array.choose TestResult.tryEffectiveScore
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        match name with
        | None -> failwith "An error has occured"
        | Some name' -> 
        
            {
                Surname = name'.Surname
                GivenName = name'.GivenName
                Id = id
                MeanScore = meanScore
                MinScore = minScore
                MaxScore = maxScore
            }

    let printSummary (student: Student) =
        let fullName = sprintf "%s, %s" student.GivenName student.Surname 
        printfn "%20s\t%s\t%0.1f\t%.01f\t%0.1f" fullName student.Id student.MeanScore student.MinScore student.MaxScore
