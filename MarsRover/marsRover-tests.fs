module marsRover_tests

open NUnit.Framework
open Swensen.Unquote.Assertions
open marsRover

[<Test>]
let ``given a compass pointing to North when rotate to left orientation will be West`` () = 
    let compass = Compass.North
    test <@ compass.rotateLeft = Compass.West @>

