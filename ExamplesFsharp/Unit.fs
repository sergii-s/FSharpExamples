module Unit
open FSharp.Core

// CSharp                 :   FSharp
// Func<TKey, TValue>     :   TKey -> TValue
// Func<'a, 'b>           :   'a -> 'b


//----------------------
// CSharp                 :   FSharp
// void                   :   unit

//var x = void
let x = ()

//----------------------

let execute (fn:('a->'b)) (value:('a)) : 'b = 
    let result = fn(value)
    result // return

//---------------------- type inference

//let execute fn value = fn(value)

//---------------------- Exemple usage
let unitReturnFuncton value = 
    printfn "%s" value
    () //~ return void

let valueReturnFuncton value = 
    value //~ return something

let exampleUsage1 = execute unitReturnFuncton "toto"
let exampleUsage2 = execute valueReturnFuncton "toto"

//---------------------- Usage execute task

let executeTask t = async {
    let! result = t
    return result 
}

//---------------------- Exemple usage

let unitReturnTask = async {
    do! Async.Sleep(100)
}

let valueReturnTask = async {
    do! Async.Sleep(100)
    return 100;
}

let usage1 = executeTask unitReturnTask |> Async.RunSynchronously
let usage2 = executeTask valueReturnTask |> Async.RunSynchronously
    