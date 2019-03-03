module UnionTypes

type User = {
    ClientId : string
    MachineId : string
}

type Product = {
    Url : string
    ProductId : int
}

type Guest = {
    MachineId : string
}

type Node = 
    | User of User
    | Product of Product
    | Guest of Guest

type Identity =
    | User of User
    | Guest of Guest

let processIdentity identity =
    match identity with
    | Identity.User u -> printfn "Identity is user with client id %s" u.ClientId
    | Identity.Guest g -> printfn "Identity is guest with machine id %s" g.MachineId

let processNode node =
    match node with
    | Node.User u -> printfn "Processing user"
    | Node.Product g -> printfn "Processing product"
    | Node.Guest g -> printfn "Processing guest"
    //delete last line