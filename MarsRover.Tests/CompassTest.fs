module CompassTest

open Expecto
open MarsRover.Core.Compass

[<Tests>]
let tests =
  testList "About Rotate Compass" [
    testCase "given a compass pointing to North when rotate to left orientation will be West" <| fun () ->
        let compass = Compass.North
        Expect.equal compass.RotateLeft Compass.West "From North to left = West"
     
    testCase "given a compass pointing to North when rotate to right orientation will be Est" <| fun () ->
        let compass = Compass.North
        Expect.equal compass.RotateRight Compass.East "From North to Rigth = East"

    testCase "given a compass pointing to East when rotate to right orientation will be SOUTH" <| fun () ->
        let compass = Compass.East
        Expect.equal compass.RotateRight Compass.South "From East to Right = South"
    
  
  ]
