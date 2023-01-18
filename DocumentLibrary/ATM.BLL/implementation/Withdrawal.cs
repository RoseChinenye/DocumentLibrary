using DocumentLibrary.ATM.Attributes;
using System;

namespace DocumentLibrary.ATM.BLL.implementation
{
    [Document(Description = "This is for withdrawal")]
    public class withdrawal
    {
        [Document(Description = "This initializes the Withdrawal with an amount", Input = "It takes in amount as double")]
        public withdrawal(double amount)
        {
            Amount = amount;
        }

        [Document(Description = "This gets and sets the withdrawal amount")]
        public double Amount { get; set; }

        [Document(Description = "This displays that the Withdrawal is successful", Input = "It takes in amount as double")]
        public void Withdraw(double amount)
        {
            Console.WriteLine("Withdrawal Successful!");
        }

        }
}
