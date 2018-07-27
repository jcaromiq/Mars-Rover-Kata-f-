module marsRover_tests

open NUnit.Framework
open Swensen.Unquote.Assertions
open marsRover

[<Test>]
let ``assert true is equals to true`` () = 
    test <@ check = false @>

