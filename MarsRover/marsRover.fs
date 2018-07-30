module marsRover

[<StructuralEquality;StructuralComparison>]
type orientation =  
    | NORTH
    | EAST
    | SOUTH 
    | WEST

let order = [orientation.NORTH; 
    orientation.EAST;
    orientation.SOUTH;
    orientation.WEST]

type Compass(orientation : orientation) =
    member x.orientation = orientation
    static member North = Compass(NORTH)
    static member West = Compass(WEST)
    static member East = Compass(EAST)
    static member South = Compass(SOUTH)

    member this.rotateLeft = 
        let inv = order |> List.rev
        inv
        |> List.findIndex(fun i -> i = orientation) 
        |> (fun n -> n + 1) 
        |> (fun n -> n % order.Length)
        |> (fun n -> inv.Item(n))
        |> (fun n -> Compass(n))

    member this.rotateRight = 
        order 
        |> List.findIndex(fun i -> i = orientation) 
        |> (fun n -> n + 1) 
        |> (fun n -> n % order.Length)
        |> (fun n -> order.Item(n))
        |> (fun n -> Compass(n))

    override x.ToString() = orientation.ToString()
    override x.GetHashCode() =
       hash (orientation)

    override x.Equals(b) = 
        match b with
           | :? Compass as c -> (orientation) = (c.orientation)
           | _ -> false
