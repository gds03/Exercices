using Exercices.BankRequests;

using Shouldly;

using Xunit;

namespace Exercices.Tests.BankRequests;

public class BankRequestsTests
{
    [Fact]
    public void BankRequestProcessor_Should_Process_Successfully()
    {
        // Arrange
        BankRequestProcessor processor = new();

        int[] accounts = new int[] { 10, 100, 20, 50, 30 };
        string[] requests = new string[]
        {
            "withdraw 2 10", 
            "transfer 5 1 20",
            "deposit 5 20", 
            "transfer 3 4 15"
        };

        int[] accountsExpected = new int[] { 30, 90, 5, 65, 30 };

        // act

        var result = processor.Execute(accounts, requests);

        // assert
        result.ShouldBe(accountsExpected);
        accounts.ShouldBe(new[] { 10, 100, 20, 50, 30 });
    }

    [Fact]
    public void BankRequestProcessor_Should_Process_Successfully_With_AnInvalidAccount()
    {
      /*
*
*  For accounts = [20, 1000, 500, 40, 90] and requests = ["deposit 3 400", "transfer 1 2 30", "withdraw 4 50"],
*  the output should be bankRequests(accounts, requests) = [-2].
*
*  After the first request, accounts becomes equal to [20, 1000, 900, 40, 90], but the second one turns it into [-10, 1030, 900, 40, 90], which is invalid.
*  Thus, the second request is invalid, and the answer is [-2]. Note that the last request is also invalid, but it shouldn't be included in the answer.*/

        // Arrange
        BankRequestProcessor processor = new();

        int[] accounts = new int[] { 20, 1000, 500, 40, 90 };
        string[] requests = new string[]
        {
             "deposit 3 400",
             "transfer 1 2 30",
             "withdraw 4 50"
        };


        int[] accountsExpected = new int[] { -2 };

        // act

        var result = processor.Execute(accounts, requests);

        // assert
        result.ShouldBe(accountsExpected);
        accounts.ShouldBe(new[] { 20, 1000, 500, 40, 90 });
    }
}