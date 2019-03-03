namespace ExamplesFsharp

module RecordTypes =

    /// *************************************************************** ///

    type User = {
        Name : string
        Email : string
        Age : int
    }

    let users = [{Name="Adam"; Email="adam@gmail.com"; Age=18}
                 {Name="Koko"; Email="koko@gmail.com"; Age=20}
                 {Name="Adam"; Email="adam@gmail.com"; Age=18}]

    let distinct = users |> List.distinct

    /// *************************************************************** ///

    type MetricQuery = {
        CatalogId : int option
        CampaignId : int option
        UserTypology : string
        Publisher : string option
        // ...
    }

    let defaultQuery = {
        CatalogId = None
        CampaignId = None
        UserTypology = "All"
        Publisher = None
    }

    let parameters = { defaultQuery with Publisher=Some "AntVoice" }

    /// *************************************************************** ///
    
    let isValidQuery q =
        match q with
        | { CatalogId = None; CampaignId = None } -> false
        | { Publisher = Some "Toto" } -> false
        | _ -> true