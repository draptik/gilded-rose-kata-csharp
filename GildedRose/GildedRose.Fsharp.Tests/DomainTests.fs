module GildedRose.Fsharp.DomainTests

open GildedRose.Fsharp

open FsUnit
open GildedRose.Fsharp.Domain
open Xunit
open Swensen.Unquote

[<Fact>]
let ``decreaseQualityByOne`` () =
    let input = UncheckedQuality 1
    let expected = UncheckedQuality 0
    let actual = Domain.decreaseQualityByOne input
    test <@ actual = expected @>


