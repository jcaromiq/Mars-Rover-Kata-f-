namespace MarsRover.Core

open MarsRover.Core.Compass
open MarsRover.Core.Gps

module Rover =
    open Compass
    
    type Rover(Gps : Gps) =
        member this.Position = Gps.position
        member private this.Gps = Gps
        
        member this.SendCommand(command : string) =
            match command with
            | "F" -> new Rover(this.Gps.Forward)
            | "B" -> new Rover(this.Gps.Backward)
            | "L" -> Rover.CreateRoverAt this.Position this.Gps.TurnLeft
            | "R" -> Rover.CreateRoverAt this.Position this.Gps.TurnRight
            | _ -> this
        
        static member CreateRoverAt position compass = 
            create (position, compass) 
            |> (fun gps -> new Rover(gps))
