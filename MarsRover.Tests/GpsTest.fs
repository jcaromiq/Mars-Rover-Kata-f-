module GpsTest

open Expecto
open MarsRover.Core.Gps
open MarsRover.Core.Compass

[<Tests>]
let moveOverXTest =
  testList "Given a orientation in X axis" [
    testCase "when is oriented to EAST and go forward" <| fun () ->
        let gps = create(0,0,Compass.East)
        let movement = create(1,0,Compass.East)

        Expect.equal gps.Forward movement "should increment x in one"
    ]