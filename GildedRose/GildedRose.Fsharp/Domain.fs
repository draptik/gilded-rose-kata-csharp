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

type Product =
    | Normal of ValidItem
    | AgeBrie of ValidItem
    

type AgeByOneDay = Product -> Product
let ageByOneDay : AgeByOneDay =
    fun item ->
        match item with
        | Normal item ->
            let quality =
                item.Quality |> decreaseQualityByOne

            Normal
                {
                    Name = item.Name
                    SellIn = item.SellIn |> decreaseSellInByOneDay
                    Quality = quality 
                }

        | AgeBrie item ->
            let quality =
                if hasSellByDatePassed item then
                    item.Quality |> increaseQualityByOne
                else
                    item.Quality |> decreaseQualityByOne
            AgeBrie
                {
                    Name = item.Name
                    SellIn = item.SellIn |> decreaseSellInByOneDay
                    Quality = quality 
                }
            
    
// This is NOT a validation!
type NormalizeItem = UncheckedItem -> ValidItem
let normalizeItem : NormalizeItem =
     
    fun x ->
        let (uncheckedItem: UncheckedItem) = x
        let (uncheckedQuality: UncheckedQuality) = uncheckedItem.Quality
        {
            Name = x.Name
            SellIn = x.SellIn
            Quality = Quality.create (uncheckedQuality)
        }