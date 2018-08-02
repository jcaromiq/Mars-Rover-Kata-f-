namespace MarsRover.Core
          
    open Compass
    open System

    module Gps =
        
        [<StructuralEquality; StructuralComparison>]
        type Position = {X:int; Y:int}

        let private incrementX position:Position = {X=position.X+1; Y=position.Y}
        let private decrementX position:Position = {X=position.X-1; Y=position.Y}

        let private incrementY position:Position = {X=position.X; Y=position.Y+1}

        let private decrementY position:Position = {X=position.X; Y=position.Y-1}

                
        type Gps (position:Position, compass:Compass) =
            member this.Position = position

            member this.Compass = compass

            member this.Forward = 
                match this.Compass.Orientation with
                    | Orientation.EAST -> new Gps(incrementX this.Position, compass=Compass.East)
                    | Orientation.WEST -> new Gps(decrementX this.Position, compass=Compass.West)
                    | Orientation.NORTH -> new Gps(incrementY this.Position, compass=Compass.North)
                    | Orientation.SOUTH -> new Gps(decrementY this.Position, compass=Compass.South)
                      
           
            member this.Backward = 
                match this.Compass.Orientation with
                    | Orientation.EAST -> new Gps(decrementX this.Position, compass=Compass.East)
                    | Orientation.WEST -> new Gps(incrementX this.Position, compass=Compass.West)
                    | Orientation.NORTH -> new Gps(decrementY this.Position, compass=Compass.North)
                    | Orientation.SOUTH -> new Gps(incrementY this.Position, compass=Compass.South)

         
            override this.ToString() = this.Compass.ToString() + "{" + this.Position.ToString()  + "}"
        
            override this.GetHashCode() = hash (this.ToString())

            override this.Equals(b) =
                match b with
                | :? Gps as c -> (this.ToString()) = (c.ToString())
                | _ -> false
        
        let create (X, Y, compass)= 
             new Gps( {X=X; Y=Y}, compass=compass)