module GildedRose.Fsharp.DomainTests

open GildedRose.Fsharp

open FsUnit
open GildedRose.Fsharp.Domain
open Xunit
open Swensen.Unquote

[<Fact>]
let ``decreaseQualityByOne`` () =
    let input = Quality 1
    let expected = Quality 0
    let actual = Domain.decreaseQualityByOne input
    test <@ actual = expected @>


