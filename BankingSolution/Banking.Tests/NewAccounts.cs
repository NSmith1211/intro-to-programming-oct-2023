using Banking.Domain;

namespace Banking.Tests;
public class NewAccounts
{

    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        //Write the code I wish I had.
        Account account = new Account();

        //When I ask it for it's balance
        decimal openingBalance = account.GetBalance();

        //then it is 5000 bucks. (decimal)
        Assert.Equal(5000M, openingBalance);
    }
}
