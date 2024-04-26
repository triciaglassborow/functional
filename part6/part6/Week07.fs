module Week07
open System

module Assignment =
    // -------------------------------------------------------------------------------------- //
    //                                         TASK 1                                         //
    // -------------------------------------------------------------------------------------- //

    //defining a type named account with an accountNumber (string) and balance (float) field.
    type Account = 
        {
            Name: string 
            mutable Balance: float
        }

        //Print member
        member this.Print =
            Console.WriteLine($"Account Name: {this.Name} Account Balance: {this.Balance}")
        //update account balance method
        member this.UpdateBalance newAccountBalance =
            {this with Balance = newAccountBalance}
        //withdraw member
        member this.Withdraw  =
            let newBalance = this.Balance// - amount
            if (newBalance < 0.0) then printf "Not enough funds"
            else this.Balance <- newBalance
            this.Print

            printfn "Balance: " 
        //deposit memeber
        member this.Deposit amount = 
            this.Balance <- this.Balance + amount 
    //withdraw method
    let Withdraw (account :Account) = 
        Console.Clear()
        Console.WriteLine("-------------------- WITHDRAW --------------------")
        account.Print
        //user enter the amount to be withdrawn
        Console.Write("Enter amount to be withdrawn: ")
        let amount = float(Console.ReadLine())
        
        let newBalance = account.Balance - amount
        if (amount > 0) then
            //checking the account has the funds, before withdrawing
            if (newBalance < 0.0) then printfn "Not enough funds"
            else account.Balance <- newBalance
        else printfn "INVALID"
        

        Console.WriteLine("---------------- CLOSING DETAILS ---------------- ")
        account.Print

    //let Deposit 
    let Deposit (account :Account) = 
        Console.Clear()
        Console.WriteLine("-------------------- DEPOSIT -------------------- ")
        account.Print

        //user enter the amount to be deposited
        Console.WriteLine("Enter amount to be deposited: ")
        let amount = float(Console.ReadLine())
        if (amount > 0) then
            //new balance
            account.Balance <- account.Balance + amount
        else printfn "INVALID"

        Console.WriteLine("---------------- CLOSING DETAILS ---------------- ")
        account.Print

    // -------------------------------------------------------------------------------------- //
    //                                         TASK 2                                         //
    // -------------------------------------------------------------------------------------- //
    //compairing the balance passed to see if the balance is high, okay or low
    let CheckAccount balance =
        (*match balance with
        | 100.00 -> printfn "Balance is high"
        | 10.00 -> printfn "Balance is low"
        | _ -> printfn "Invalid"*)
        
        if (balance > 100.00) then printfn "Balance is high"
        elif (balance >= 10.00) then printfn "Blanace is okay"
        elif (balance < 10) then printfn "Balance is low"
        else printfn "ERROR: Balance invalid"

    

    // -------------------------------------------------------------------------------------- //
    //                                         RUN METHOD                                     //
    // -------------------------------------------------------------------------------------- //
    let run() =
        //creating the accounts
        let Account0 = {Name = "0000"; Balance = 25.0}
        let Account1 = {Name = "0001"; Balance = 0.0}
        let Account2 = {Name = "0002"; Balance = 51.0}
        let Account3 = {Name = "0003"; Balance = 5.0}
        let Account4 = {Name = "0004"; Balance = 100.0}
        let Account5 = {Name = "0005"; Balance = 110.0}
        let Account6 = {Name = "0006"; Balance = 10.0}

        // -------------------------------------------------------------------------------------- //
        //                                         TASK 3                                         //
        // -------------------------------------------------------------------------------------- //

        //defining a list of all accounts
        let accounts = [Account0; Account1; Account2; Account3; Account4; Account5; Account6]

        //List partition. taking accounts and if the balance is 50 or greater it is added to a list, 
        // if it is not it is added to a different list.
        let partitionAccounts = List.partition (fun i -> i.Balance <= 50 ) accounts
        let lowAccountBalance = fst partitionAccounts
        let highAccountBalance = snd partitionAccounts

        

        Console.WriteLine ("--- LIST ALL ACCOUNTS PLUS QUICK CHECK BALANCE ---")
        for i in accounts do 
            i.Print
            CheckAccount i.Balance
        
        Console.WriteLine ("-------------------- WITHDRAW --------------------")
        Console.Write("Which account would you like to withdraw from (0-9): ")
        let withdrawAccSelect = "000" + Console.ReadLine()
        
        if (Account0.Name = withdrawAccSelect) then Withdraw Account0
        elif (Account1.Name = withdrawAccSelect) then Withdraw Account1
        elif (Account2.Name = withdrawAccSelect) then Withdraw Account2

        (*match withdrawAccSelect with
        | Account0.Name -> Withdraw Account0
        | 
        | _ -> printfn "Invalid"*)

        Console.WriteLine ("-------------------- DEPOSIT --------------------")
        Console.Write("Which account would you like to deposit to (0-9): ")
        let depositAccSelect = "000" + Console.ReadLine()

        if (Account0.Name = depositAccSelect) then Deposit Account0
        elif (Account1.Name = depositAccSelect) then Deposit Account1
        elif (Account2.Name = depositAccSelect) then Deposit Account2
        
        Console.WriteLine ("-------------- ACCOUNTS WITH <= 50 --------------")
        for i in lowAccountBalance do
            i.Print

        Console.WriteLine ("-------------- ACCOUNTS WITH > 50 ---------------")
        for i in highAccountBalance do
            i.Print


