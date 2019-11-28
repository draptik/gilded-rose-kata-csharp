module GildedRose.Fsharp.Domain

type UncheckedQuality = UncheckedQuality of int

type Quality = Quality of int

module Quality =
    let min = 0
    let max = 50
    
    let create uncheckedQuality =
        let (UncheckedQuality x) = uncheckedQuality
        if x < min then
            Quality min
        else if x > max then
            Quality max
        else
            Quality x
            
type Name = Name of string
type SellIn = SellIn of int

type UncheckedItem = {
    Name: Name
    SellIn: SellIn
    Quality: UncheckedQuality
}

type ValidItem = {
    Name: Name
    SellIn: SellIn
    Quality: Quality
}

let decreaseSellInByOneDay previous =
    let (SellIn x) = previous
    SellIn (x - 1)

let decreaseQuality previous amount =
    let (Quality x) = previous
    (x - amount)
    |> UncheckedQuality
    |> Quality.create

let increaseQuality previous amount =
    let (Quality x) = previous
    (x + amount)
    |> UncheckedQuality
    |> Quality.create

let decreaseQualityByOne previous =
    1 |> decreaseQuality previous  

let increaseQualityByOne previous =
    1 |> increaseQuality previous  

let isSellInPassed sellIn =
    let (SellIn x) = sellIn
    x < 0
    
let hasSellByDatePassed item =
    item.SellIn |> isSellInPassed

let areLessThan5DaysLeft item =
    item.SellIn < SellIn 6

let areLessThan10DaysLeft item =
    item.SellIn < SellIn 11
    
type Product =
    | Normal of ValidItem
    | AgedBrie of ValidItem
    | Sulfuras of ValidItem
    | BackstagePass of ValidItem
    | Conjured of ValidItem
    
type AgeByOneDay = Product -> Product
let ageByOneDay : AgeByOneDay =
    fun item ->
        match item with
        | Normal item ->
            let quality =
                if hasSellByDatePassed item then
                    item.Quality |> decreaseQualityByOne |> decreaseQualityByOne
                else
                    item.Quality |> decreaseQualityByOne

            Normal
                { item with
                      SellIn = item.SellIn |> decreaseSellInByOneDay
                      Quality = quality
                }
                
        | AgedBrie item ->
            let quality =
                if hasSellByDatePassed item then
                    item.Quality |> increaseQualityByOne
                else
                    item.Quality |> decreaseQualityByOne
            AgedBrie
                { item with
                      SellIn = item.SellIn |> decreaseSellInByOneDay
                      Quality = quality
                }
        
        | Sulfuras item ->
            Sulfuras item
            
        | BackstagePass item ->
            let quality =
                if areLessThan5DaysLeft item then
                    item.Quality |> increaseQualityByOne |> increaseQualityByOne |> increaseQualityByOne
                else if areLessThan10DaysLeft item then
                    item.Quality |> increaseQualityByOne |> increaseQualityByOne
                else
                    item.Quality |> increaseQualityByOne
            BackstagePass
                { item with
                    SellIn = item.SellIn |> decreaseSellInByOneDay
                    Quality = quality   
                }
                
        | Conjured item ->
            let quality =
                item.Quality |> decreaseQualityByOne |> decreaseQualityByOne
            Conjured
                { item with
                    SellIn = item.SellIn |> decreaseSellInByOneDay
                    Quality = quality   
                }