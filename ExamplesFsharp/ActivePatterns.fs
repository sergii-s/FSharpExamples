module ActivePatterns

type User = {
    Name : string
    Age : int
    AuthenticationInfo : string option
}

// ------------ active pattern

let (|Infant|Adolescent|Young|Old|) user = 
    if user.Age < 6 then
        Infant
    else if user.Age < 18 then
        Adolescent
    else if user.Age < 31 then
        Young
    else
        Old

// ----------- usage

let printUser user = 
    match user with
    | Infant -> printfn "Infant"
    | Adolescent -> printfn "Adolescent"
    | Young -> printfn "Young"
    | Old -> printfn "Old"

let doSomethingElse user = 
    match user with
    | Infant -> printfn "Infant" // ....
    | Adolescent -> printfn "Adolescent" // ....
    | Young -> printfn "Young" // ....
    | Old -> printfn "Old" // ....


// -----------------------

let (|NotAuthenticated|SshAuthenticated|PasswordAuthenticated|) user = 
    match user.AuthenticationInfo with
    | None -> NotAuthenticated
    | Some x when x.StartsWith("ssh:") -> SshAuthenticated (x.Substring(4))
    | Some x -> PasswordAuthenticated x

// -----------------------

let checkAuthentication user =
    match user with
    | NotAuthenticated -> printfn "User %s is not authenticated" user.Name
    | SshAuthenticated key -> printfn "User %s is ssh-authenticated with key %s" user.Name key
    | PasswordAuthenticated password -> printfn "User %s is authenticated with password %s" user.Name password

let u1 = {Name="Koko"; Age=10; AuthenticationInfo=None}
let u2 = {Name="Toto"; Age=20; AuthenticationInfo=Some "ssh:JFUSGCJFKS"}
let u3 = {Name="Tata"; Age=30; AuthenticationInfo=Some "adminPassword"}

u1 |> checkAuthentication
u2 |> checkAuthentication
u3 |> checkAuthentication