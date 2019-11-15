module GildedRose.Fsharp.Domain

//module Quality =
//    let create q =
//        if q < 0 then
//            Error "Quality can't drop below zero"
//        else if q < 50 then
//            Error "Quality can't be above 50"
//        else
//            Ok (q)
            
type Name = Name of string
type SellIn = SellIn of int
type Quality = Quality of int

type Item = {
    Name: Name
    SellIn: SellIn
    Quality: Quality
}

let decreaseSellInByOneDay previous =
    let (SellIn x) = previous
    SellIn (x - 1)

let decreaseQuality previous amount =
    let (Quality x) = previous
    if x < 0 then
        Quality (0)
    else
        Quality (x - amount)

let decreaseQualityByOne previous =
    1 |> decreaseQuality previous  

let isSellInPassed sellIn =
    let (SellIn x) = sellIn
    x < 0
    
let hasSellByDatePassed item =
    item.SellIn |> isSellInPassed

type AgeByOneDay = Item -> Item
let ageByOneDay : AgeByOneDay =
    fun item ->
        {
            Name = item.Name
            SellIn = item.SellIn |> decreaseSellInByOneDay
            Quality = item.Quality |> decreaseQualityByOne
        }


