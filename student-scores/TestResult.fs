namespace StudentScores

type TestResult = 
    | Absent
    | Execused
    | Scored of float

module TestResult = 

    let fromString s =
        if s = "A" then
            Absent
        elif s = "E" then
            Execused
        else 
            let value = s |> float
            Scored value
    let tryEffectiveScore (testResult : TestResult) =
        match testResult with 
        | Absent -> Some 0.0
        | Execused -> None
        | Scored score -> Some score
