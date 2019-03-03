module TypeProviders

//#r @"C:\Users\Sergii\.nuget\packages\FSharp.Data\3.0.0\lib\netstandard2.0\FSharp.Data.dll"

open FSharp.Data

type GitHubCommits = JsonProvider<"https://api.github.com/repos/kubernetes/kubernetes/commits">

let commits = GitHubCommits.Load("https://api.github.com/repos/kubernetes/kubernetes/commits")

let commitCount = 
    commits 
    |> Array.groupBy (fun x -> x.Author.Login)
    |> Array.map (fun (login, c) -> (login, c.Length))