namespace StudentScores

module Float = 
    let tryFromString s = 
        if s = "N/A" then
            None
        else 
            Some (float s)

    let fromStringOr50 (d : float) s = 
        s 
        |> tryFromString
        |> Option.defaultValue d
    
    