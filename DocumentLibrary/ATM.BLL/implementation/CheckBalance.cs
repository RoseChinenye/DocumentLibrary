using DocumentLibrary.ATM.Attributes;

namespace DocumentLibrary.ATM.BLL.implementation
{
    [Document(Description = "This is for Checking Balance")]
    public class CheckBalance
    {
        [Document(Description = "This initializes the Check Balance with a balance", Input = "It takes in balance as double")]
        public CheckBalance(double balance) {

            Balance = balance;
        
        }

        [Document(Description = "This gets the Account Balance")]
        public double Balance { get;}


        [Document(Description = "This displays the Account Balance when called", Output = "It returns the balance")]
        public double getCheckBalance()
        {
            return Balance;
        }
    }
}
