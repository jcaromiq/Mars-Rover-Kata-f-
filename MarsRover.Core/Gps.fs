namespace MarsRover.Core

open Compass
open System

module Gps =
    
    type Position = { X : int; Y : int }
    
    let private incrementX position : Position = {position with X=position.X+1}
    let private decrementX position : Position = {position with X=position.X-1}
    let private incrementY position : Position = {position with Y=position.Y+1}
    let private decrementY position : Position = {position with Y=position.Y-1}
      
    type Gps = {position : Position; compass : Compass} with 
        member this.TurnLeft = {this with compass=(this.compass.RotateLeft)}
        member this.TurnRight = {this with compass=(this.compass.RotateRight)}
        member this.Forward =
            match this.compass.orientation with
            | Orientation.EAST -> {this with position=(incrementX this.position)}
            | Orientation.WEST -> {this with position=(decrementX this.position)}
            | Orientation.NORTH -> {this with position=(incrementY this.position)}
            | Orientation.SOUTH -> {this with position=(decrementY this.position)}
        
        member this.Backward =
            match this.compass.orientation with
            | Orientation.EAST -> {this with position=(decrementX this.position)}
            | Orientation.WEST -> {this with position=(incrementX this.position)}
            | Orientation.NORTH -> {this with position=(decrementY this.position)}
            | Orientation.SOUTH -> {this with position=(incrementY this.position)}
        
        override this.ToString() = this.compass.ToString() + "{" + this.position.ToString() + "}"
        
    
    let create (position, compass) = {position=position; compass=compass}
