module marsRover_tests

open NUnit.Framework
open Swensen.Unquote.Assertions
open marsRover

[<Test>]
let ``given a compass pointing to North when rotate to left orientation will be West`` () = 
    let compass = Compass.North
    test <@ compass.rotateLeft = Compass.West @>

[<Test>]
let ``given a compass pointing to North when rotate to right orientation will be Est`` () = 
    let compass = Compass.North
    test <@ compass.rotateRight = Compass.East @>


[<Test>]
let ``given a compass pointing to East when rotate to right orientation will be SOUTH`` () = 
    let compass = Compass.East
    test <@ compass.rotateRight = Compass.South @>
