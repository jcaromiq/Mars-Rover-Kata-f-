namespace MarsRover.Core
module Compass =

    [<StructuralEquality;StructuralComparison>]
    type orientation =  
        | NORTH
        | EAST
        | SOUTH 
        | WEST

    let private cardinalPoints = [orientation.NORTH; 
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
            cardinalPoints 
            |> List.rev
            |> this.rotate

        member this.rotateRight = 
            cardinalPoints
            |> this.rotate

        member private this.rotate(list) = 
            list 
            |> List.findIndex(fun i -> i = orientation) 
            |> (fun n -> n + 1) 
            |> (fun n -> n % list.Length)
            |> (fun n -> list.Item(n))
            |> (fun n -> Compass(n))



        override x.ToString() = orientation.ToString()
        override x.GetHashCode() =
           hash (orientation)

        override x.Equals(b) = 
            match b with
               | :? Compass as c -> (orientation) = (c.orientation)
               | _ -> false
