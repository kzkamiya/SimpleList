namespace SampleListView

open System
open System.Collections.ObjectModel
open Xamarin.Forms
open Xamarin.Forms.Xaml
open FSharp.Data
open Deedle

type Weather = JsonProvider<"https://api.openweathermap.org/data/2.5/weather?units=metric&q=Prague&appid=ce5f59bf8d05a0625143d81eb3117718">

type CurrentTemp(place : string, temp: int) = 
    member x.Place = place
    member x.Temp = temp

type MainPage() =
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<MainPage>)
    let button = base.FindByName<Button>("button")
    let label = base.FindByName<Label>("label")
    let listView = base.FindByName<ListView>("listView")

    //do listView.ItemTapped.AddHandler(
                //new EventHandler<ItemTappedEventArgs>(fun x y -> (x :?> ListView).SelectedItem <- null )) 

    let CurrentTempList = ObservableCollection<CurrentTemp>()
    // OK!!   
    do listView.ItemsSource <- CurrentTempList

    // NG... member listView.ItemsSource = People
    let baseUrl = "https://api.openweathermap.org/data/2.5"
    let forecastUrl = baseUrl + "/weather?units=metric&q="

    let getCurrentTemp place =
      try
//        let w = Weather.Load("https://api.openweathermap.org/data/2.5/weather?units=metric&q=Prague&appid=ce5f59bf8d05a0625143d81eb3117718")
//        w.Main.Temp
          10
      with
        | :? System.Net.WebException -> int(0)

    let place = "Cambridge,UK"
    let temp = getCurrentTemp place
    do CurrentTempList.Add(new CurrentTemp(place, temp))

    member this.OnClicked( sender : Object, args : EventArgs) = 
        let place = "Prague"
        let temp = getCurrentTemp place
        do CurrentTempList.Add(new CurrentTemp(place, temp))

