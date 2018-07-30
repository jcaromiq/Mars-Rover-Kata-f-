module CompassTest

open Expecto
open MarsRover.Core.Compass

[<Tests>]
let tests =
  testList "About Rotate Compass" [
    testCase "given a compass pointing to North when rotate to left orientation will be West" <| fun () ->
        let compass = Compass.North
        Expect.equal compass.rotateLeft Compass.West "2+2 = 4"
     
    testCase "given a compass pointing to North when rotate to right orientation will be Est" <| fun () ->
        let compass = Compass.North
        Expect.equal compass.rotateRight Compass.East "2+2 = 4"

    testCase "given a compass pointing to East when rotate to right orientation will be SOUTH" <| fun () ->
        let compass = Compass.East
        Expect.equal compass.rotateRight Compass.South "2+2 = 4"
    
  
  ]
