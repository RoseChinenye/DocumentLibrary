using DocumentLibrary.Attributes;

namespace DocumentLibrary.Data
{
    [Document(Description = "These includes the amount and the balance of an account")]
    public enum numbers
    {
        Amount = 10_000,
        Balance = 100_000

    };
}
