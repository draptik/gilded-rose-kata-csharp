module GildedRose.Fsharp.DomainTests

open GildedRose.Fsharp

open FsUnit
open GildedRose.Fsharp.Domain
open Xunit
open Swensen.Unquote

open Domain

[<Theory>]
[<InlineData(1, 0)>]
[<InlineData(2, 1)>]
[<InlineData(3, 2)>]
[<InlineData(0, 0)>]
[<InlineData(-1, 0)>]
[<InlineData(100, 50)>]
[<InlineData(51, 50)>]
[<InlineData(50, 49)>]
[<InlineData(49, 48)>]
let ``decreasing Quality including edge cases`` (input, expected) =
    let expected = Quality expected
    let actual =
        Quality input
        |> decreaseQualityByOne
    
    test <@ actual = expected @>

[<Theory>]
[<InlineData(1, 0)>]
[<InlineData(100, 99)>]
[<InlineData(0, -1)>]
[<InlineData(-99, -100)>]
let ``decreasing SellIn by one day`` (input, expected) =
    let expected = SellIn expected
    let actual =
        SellIn input
        |> decreaseSellInByOneDay
    
    test <@ actual = expected @>
