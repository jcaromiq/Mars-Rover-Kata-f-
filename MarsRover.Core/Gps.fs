namespace MarsRover.Core
          
    open Compass
    open System

    module Gps =
    
        type Gps (x:int, y: int, compass:Compass) =
            member this.X = x
            member this.Y = y

            member this.Compass = compass

            member this.Forward = new Gps(x= this.X+1, y=this.Y, compass=Compass.East)
           
            override this.ToString() = this.Compass.ToString() + "{" + this.X.ToString() + ", " + this.Y.ToString() + "}"
        
            override this.GetHashCode() = hash (this.ToString())

            override this.Equals(b) =
                match b with
                | :? Gps as c -> (this.ToString()) = (c.ToString())
                | _ -> false
        
        let create (X, Y, compass)= 
             new Gps(x =X ,y = Y, compass =compass)