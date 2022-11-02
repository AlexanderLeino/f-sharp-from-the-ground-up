namespace StudentScores

type Optional<'T> = 
    | Something of 'T
    | Nothing

module Demo = 

    let defaultValue(d: 'T)(optional: Optional<'T>) = 
        match optional with 
        | Something v -> v
        | Nothing -> d