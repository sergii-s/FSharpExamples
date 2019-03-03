module ComputationExpressions
open FSharp.Core

// seq
let myEnumerable = seq {
    yield 10
    yield 20
    yield 30
}

// seq mutliple 
let squares = seq {
    for i in 1..3 -> i * i
}

let myEnumerable2 = seq {
    yield 10
    yield 20
    yield! squares
}

// async
let myAsync = async {
    let x = 1;
    do! Async.Sleep(100)  //Bind
    do! Async.Sleep(100)
    do! Async.Sleep(100)
    return x
}


// maybe

let divideBy bottom top =
    if bottom = 0 then 
        None
    else 
        Some(top/bottom)

let add x y =
    x + y

// result = (input/d1 + add1) / d2 + add2 )
let chainDivideV1 input d1 add1 d2 add2 =
    let r1 = input |> divideBy d1
    let r2 = r1 |> Option.map  (fun x -> x |> add add1)
    let r3 = r2 |> Option.bind (fun x -> x |> divideBy d2)
    let r4 = r3 |> Option.map  (fun x -> x |> add add2)
    r4
   
let chainDivideV2 input d1 add1 d2 add2 =
    input 
        |> divideBy d1
        |> Option.map  (fun x -> x |> add add1)
        |> Option.bind (fun x -> x |> divideBy d2)
        |> Option.map  (fun x -> x |> add add2)
        
//partial application :
let fnVersion1 = fun x -> x |> add 10




let fnVersion2 x = x |> add 10 




let fnVersion3 = add 10





let chainDivideV3 input d1 add1 d2 add2 =
    input 
        |> divideBy d1
        |> Option.map  (add add1)
        |> Option.bind (divideBy d2)
        |> Option.map  (add add2)

// -------------- new computation expression
type MaybeBuilder() =
    member this.Bind(m, f) = Option.bind f m
    member this.Return(x) = Some x

let maybe = new MaybeBuilder()

// ---------------- use computation expression

let chainDivideV4 input d1 add1 d2 add2 = maybe {
    let! x1 = input |> divideBy d1
    let  x2 = x1 |> add add1
    let! x3 = x2 |> divideBy d2
    let  x4 = x3 |> add add2
    return x4
}

let usage1 = chainDivideV4 10 2 3 4 5
let usage2 = chainDivideV4 10 0 3 4 5
let usage3 = chainDivideV4 10 2 3 0 5


// railway

let workflowStep1 x = 
    if x % 2 = 0 then
        "Error step 1" |> Error
    else
        x * 13 |> Ok

let workflowStep2 x = 
    if x % 3 = 0 then
        "Error step 2" |> Error
    else
        100.0m * (decimal x) / 123m |> Ok

let workflowStep3 x = 
    sprintf "Result : %f" x

let myWorkflow x = 
    x 
        |> workflowStep1
        |> Result.bind workflowStep2
        |> Result.map workflowStep3 


// -------------------------- new computation expression
type ResultBuilder() =
    member this.Map(m, f) = Result.map f m
    member this.Bind(m, f) = Result.bind f m
    member this.Return(x) = Ok x

let result = new ResultBuilder()
// ---------------------------


let myWorkflowV2 x = result {
    let! step1 = x |> workflowStep1
    let! step2 = step1 |> workflowStep2
    let  step3 = step2 |> workflowStep3 
    return step3
}

let ex1 = myWorkflowV2 4
let ex2 = myWorkflowV2 15
let ex3 = myWorkflowV2 17