module marsRover

[<StructuralEquality;StructuralComparison>]
type orientation =  
    | NORTH
    | EAST
    | SOUTH 
    | WEST


type Compass(orientation : orientation) =
    member x.orientation = orientation
    static member North = Compass(NORTH)
    static member West = Compass(WEST)
    member inline this.rotateLeft = Compass(NORTH)

    override x.ToString() = orientation.ToString()
    override x.GetHashCode() =
       hash (orientation)

    override x.Equals(b) = 
        match b with
           | :? Compass as c -> (orientation) = (c.orientation)
           | _ -> false
