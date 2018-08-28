module MarsRoverTest

open Expecto
open MarsRover.Core.Gps
open MarsRover.Core.Compass
open MarsRover.Core.Rover

[<Tests>]
let moveOverXTest =
  testList "Given a Rover" [
    let rover = Rover.CreateRoverAt {X=0;Y=0}  Compass.East
    
    testCase "when send F command" <| fun () ->
        let a = rover.SendCommand("F")
        Expect.equal a.Position {X=1; Y=0} "should increment x in one"
         
    
    testCase "when send LF command" <| fun () ->
        let a = rover.SendCommand("L").SendCommand("F")
        Expect.equal a.Position {X=0; Y=1} "should increment Y in one"
    
    testCase "when send LFF command" <| fun () ->
        let a = rover.SendCommand("L").SendCommand("F").SendCommand("F")
        Expect.equal a.Position {X=0; Y=2} "should increment Y in one"
    
    ] 