using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using DocumentLibrary.ATM.Attributes;
using DocumentLibrary.ATM.Data;

namespace DocumentLibrary.ATM.BLL.implementation
{
    [Document(Description = "This is for Transfer")]
    public class Transfer
    {
        [Document(Description = "This initializes the Transfer with an amount and reciever's name", Input = "It takes in amount as double and receiver name as string")]
        public Transfer(double amount, string recieverName) {
            Amount = amount;
            RecieverName = recieverName;
        }

        [Document(Description = "This gets and sets the transfer amount")]
        public double Amount { get; set; }

        [Document(Description = "This gets and sets the transfer receiver name")]
        public string RecieverName { get; set; }

        [Document(Description = "This displays that the Transfer is successful", Input = "It takes in double as an amount and string as receiver name")]
        public void getTransfer(double amount, string recieverName)
        {
            RecieverName = "Chinenye";
            Console.WriteLine("Transfer Successful!");
        }
    }
}
