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

    testCase "when is oriented to EAST and go back" <| fun () ->
        let gps = create(1,0,Compass.East)
        let movement = create(0,0,Compass.East)

        Expect.equal gps.Backward movement "should decrement x in one"

    testCase "when is oriented to WEST and go forward" <| fun () ->
        let gps = create(1,0,Compass.West)
        let movement = create(0,0,Compass.West)

        Expect.equal gps.Forward movement "should decrement x in one"
    
    testCase "when is oriented to WEST and go back" <| fun () ->
        let gps = create(0,0,Compass.West)
        let movement = create(1,0,Compass.West)

        Expect.equal gps.Backward movement "should increment x in one"

  ]
let moveOverYTest =
  testList "Given a orientation in Y axis" [
    testCase "when is oriented to North and go forward" <| fun () ->
        let gps = create(0,0,Compass.North)
        let movement = create(0,1,Compass.North)

        Expect.equal gps.Forward movement "should increment y in one"

    testCase "when is oriented to NORTH and go back" <| fun () ->
        let gps = create(0,1,Compass.North)
        let movement = create(0,0,Compass.North)

        Expect.equal gps.Backward movement "should decrement y in one"

    testCase "when is oriented to SOUTH and go forward" <| fun () ->
        let gps = create(0,1,Compass.South)
        let movement = create(0,0,Compass.South)

        Expect.equal gps.Forward movement "should decrement y in one"
    
    testCase "when is oriented to SOUTH and go back" <| fun () ->
        let gps = create(0,0,Compass.South)
        let movement = create(0,1,Compass.South)

        Expect.equal gps.Backward movement "should increment y in one"

  ]

  