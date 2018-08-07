namespace MarsRover.Core

open Compass
open System

module Gps =
    [<StructuralEquality; StructuralComparison>]
    type Position = { X : int; Y : int }
    
    let private incrementX position : Position =
        { X = position.X + 1
          Y = position.Y }
    
    let private decrementX position : Position =
        { X = position.X - 1
          Y = position.Y }
    
    let private incrementY position : Position =
        { X = position.X
          Y = position.Y + 1 }
    
    let private decrementY position : Position =
        { X = position.X
          Y = position.Y - 1 }
    
    type Gps = {position : Position; compass : Compass} 
        with 
        
        member this.Forward =
            match this.compass.Orientation with
            | Orientation.EAST -> {this with position=(incrementX this.position)}
            | Orientation.WEST -> {this with position=(decrementX this.position)}
            | Orientation.NORTH -> {this with position=(incrementY this.position)}
            | Orientation.SOUTH -> {this with position=(decrementY this.position)}
        
        member this.Backward =
            match this.compass.Orientation with
            | Orientation.EAST -> {this with position=(decrementX this.position)}
            | Orientation.WEST -> {this with position=(incrementX this.position)}
            | Orientation.NORTH -> {this with position=(decrementY this.position)}
            | Orientation.SOUTH -> {this with position=(incrementY this.position)}
        
        override this.ToString() = this.compass.ToString() + "{" + this.position.ToString() + "}"
        
    
    let create (position, compass) = {position=position; compass=compass}
