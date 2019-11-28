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
let ``aging a product by 1 day reduces SellIn and Quality by 1 (happy case)`` () =
    let input =
        Normal {
            Name = Name "foo"
            SellIn = SellIn 10
            Quality = Quality 5
        }
        
    let actual =
        input
        |> ageByOneDay
    
    let expected =
        Normal {
            Name = Name "foo"
            SellIn = SellIn 9
            Quality = Quality 4
        }
        
    test <@ actual = expected @>
    
[<Fact>]
let ``Quality decreases twice as fast once the SellIn date has passed`` () =
    let input =
        Normal {
            Name = Name "foo"
            SellIn = SellIn -1
            Quality = Quality 6
        }
        
    let actual =
        input
        |> ageByOneDay
    
    let expected =
        Normal {
            Name = Name "foo"
            SellIn = SellIn -2
            Quality = Quality 4
        }
        
    test <@ actual = expected @>
    
[<Fact>]
let ``Quality decreases twice as fast once the SellIn date has passed except for 'Aged Brie' then it increases`` () =
    let input =
        AgedBrie {
            Name = Name "Aged Brie 1900"
            SellIn = SellIn -1
            Quality = Quality 6
        }
        
    let actual =
        input
        |> ageByOneDay
    
    let expected =
        AgedBrie {
            Name = Name "Aged Brie 1900"
            SellIn = SellIn -2
            Quality = Quality 7
        }
        
    test <@ actual = expected @>
    
[<Theory>]
[<InlineData(0, 80)>]
[<InlineData(-1, 80)>]
let ``Sulfuras never changes SellIn date nor Quality`` (sellIn, quality) =
    let input =
        Sulfuras {
            Name = Name "Sulfuras, Hand of Ragnaros"
            SellIn = SellIn sellIn
            Quality = Quality quality
        }
        
    let actual =
        input
        |> ageByOneDay
        
    let expected = input
    
    test <@ actual = expected @>
    
[<Theory>]
[<InlineData(15, 20, 14, 21)>]
[<InlineData(10, 49, 9, 50)>]
[<InlineData(5, 49, 4, 50)>]
let ``Backstage passes increases as SellIn day approaches`` (sellIn, quality, expectedSellIn, expectedQuality) =
    let input =
        BackstagePass {
            Name = Name "Backstage passes to a TAFKAL80ETC concert"
            SellIn = SellIn sellIn
            Quality = Quality quality
        }
        
    let actual =
        input
        |> ageByOneDay
        
    let expected =
        BackstagePass {
            Name = Name "Backstage passes to a TAFKAL80ETC concert"
            SellIn = SellIn expectedSellIn
            Quality = Quality expectedQuality
        }
    
    test <@ actual = expected @>    