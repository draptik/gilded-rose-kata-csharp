module GildedRose.Fsharp.SmokeTests

open GildedRose.Fsharp

open FsUnit
open Xunit
open Swensen.Unquote

[<Fact>]
let ``Smoke test (unquote: better error messages)`` () =
    test <@ Dummy.addOne 1 = 2 @>
    
[<Fact>]
let ``Smoke test (FsUnit: Easier to write, more idiomatic?)`` () =
    1 |> Dummy.addOne |> should equal 2
    
    