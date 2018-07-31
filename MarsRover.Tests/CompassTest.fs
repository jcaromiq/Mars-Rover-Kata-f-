module CompassTest

open Expecto
open MarsRover.Core.Compass

[<Tests>]
let rotateLeftTests =
  testList "Rotate to left from" [
    testCase "North should orientate to West" <| fun () ->
        let compass = Compass.North
        Expect.equal compass.RotateLeft Compass.West "From North to left = West"
    
    testCase "South should orientate to East" <| fun () ->
        let compass = Compass.South
        Expect.equal compass.RotateLeft Compass.East "From South to left = East"

    testCase "East should orientate to North" <| fun () ->
        let compass = Compass.East
        Expect.equal compass.RotateLeft Compass.North "From East to left = North"

    testCase "West should orientate to South" <| fun () ->
        let compass = Compass.West
        Expect.equal compass.RotateLeft Compass.South "From West to left = South"
    ]

[<Tests>]
let rotateRigthTests =
  testList "Rotate to rigth from" [
    testCase "North should orientate to East" <| fun () ->
        let compass = Compass.North
        Expect.equal compass.RotateRight Compass.East "From North to Rigth = East"

    testCase "East should orientate to South" <| fun () ->
        let compass = Compass.East
        Expect.equal compass.RotateRight Compass.South "From East to Right = South"
    
    testCase "South should orientate to West" <| fun () ->
        let compass = Compass.South
        Expect.equal compass.RotateRight Compass.West "From South to Right = West"
    
    testCase "West should orientate to North" <| fun () ->
        let compass = Compass.West
        Expect.equal compass.RotateRight Compass.North "From West to Right = North"
  
  ]
