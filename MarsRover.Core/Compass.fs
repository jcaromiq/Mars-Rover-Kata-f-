namespace MarsRover.Core

module Compass =

    type Orientation =
        | NORTH
        | EAST
        | SOUTH
        | WEST
    
    let private cardinalPoints = [ Orientation.NORTH; Orientation.EAST; Orientation.SOUTH; Orientation.WEST ]
    
    type Compass = {orientation : Orientation} with
        
        static member North = {orientation=NORTH}
        static member West = {orientation=WEST}
        static member East =  {orientation=EAST}
        static member South = {orientation=SOUTH}
        
        member this.RotateLeft =
            cardinalPoints
            |> List.rev
            |> this.Rotate
        
        member this.RotateRight = cardinalPoints |> this.Rotate
        
        member private this.Rotate(list) =
            list
            |> List.findIndex (fun i -> i = this.orientation)
            |> (fun i -> (i + 1) % list.Length)
            |> (fun i -> list.Item(i))
            |> (fun o -> {orientation=o})
        
        override this.ToString() = this.orientation.ToString()