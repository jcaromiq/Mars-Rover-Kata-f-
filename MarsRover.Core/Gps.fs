namespace MarsRover.Core
          
    open Compass
    open System

    module Gps =
        
        [<StructuralEquality; StructuralComparison>]
        type Position = {X:int; Y:int}

        let private incrementX position:Position = {X=position.X+1; Y=position.Y}

                
        type Gps (position:Position, compass:Compass) =
            member this.Position = position

            member this.Compass = compass

            member this.Forward = new Gps(incrementX this.Position, compass=Compass.East)
           
            override this.ToString() = this.Compass.ToString() + "{" + this.Position.ToString()  + "}"
        
            override this.GetHashCode() = hash (this.ToString())

            override this.Equals(b) =
                match b with
                | :? Gps as c -> (this.ToString()) = (c.ToString())
                | _ -> false
        
        let create (X, Y, compass)= 
             new Gps( {X=X; Y=Y}, compass=compass)