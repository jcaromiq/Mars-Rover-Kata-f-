namespace MarsRover.Core
module Compass =

    [<StructuralEquality;StructuralComparison>]
    type Orientation =  
        | NORTH
        | EAST
        | SOUTH 
        | WEST

    let private cardinalPoints = [Orientation.NORTH; 
        Orientation.EAST;
        Orientation.SOUTH;
        Orientation.WEST]

    type Compass(orientation : Orientation) =
        member this.Orientation = orientation
        static member North = Compass(NORTH)
        static member West = Compass(WEST)
        static member East = Compass(EAST)
        static member South = Compass(SOUTH)

        member this.RotateLeft = 
            cardinalPoints 
            |> List.rev
            |> this.Rotate

        member this.RotateRight = 
            cardinalPoints
            |> this.Rotate

        member private this.Rotate(list) = 
            list 
            |> List.findIndex(fun i -> i = orientation) 
            |> (fun i -> (i + 1) % list.Length) 
            |> (fun i -> list.Item(i))
            |> (fun o -> Compass(o))

        override x.ToString() = orientation.ToString()
        override x.GetHashCode() =
           hash (orientation)

        override x.Equals(b) = 
            match b with
               | :? Compass as c -> (orientation) = (c.Orientation)
               | _ -> false
