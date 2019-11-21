module GildedRose.Fsharp.DomainTests

open FsUnit
open GildedRose.Fsharp.Domain
open Xunit
open Swensen.Unquote

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
    let actual =
        Quality input
        |> decreaseQualityByOne
    
    let expected = Quality expected

    test <@ actual = expected @>

[<Theory>]
[<InlineData(1, 0)>]
[<InlineData(100, 99)>]
[<InlineData(0, -1)>]
[<InlineData(-99, -100)>]
let ``decreasing SellIn by one day`` (input, expected) =
    let actual =
        SellIn input
        |> decreaseSellInByOneDay
    
    let expected = SellIn expected

    test <@ actual = expected @>

[<Fact>]
let ``aging a product by 1 day works`` () =
    let input =
        {
            Name = Name "foo"
            SellIn = SellIn 10
            Quality = Quality 5
        }
        
    let actual =
        input
        |> ageByOneDay
    
    let expected =
        {
            Name = Name "foo"
            SellIn = SellIn 9
            Quality = Quality 4
        }
        
    test <@ actual = expected @>