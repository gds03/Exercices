using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercices.BankRequests
{
    /**
    * Bank Requests
    *
    * You've been asked to program a bot for a popular bank that will automate the management of incoming requests. There are three types of requests the bank can receive:
    * 
    *  - transfer i j sum: request to transfer sum amount of money from the ith account to the jth one;
    *  - deposit i sum: request to deposit sum amount of money in the ith account;
    *  - withdraw i sum: request to withdraw sum amount of money from the ith account.
    *
    * Your bot should also be able to process invalid requests. There are two types of invalid requests:
    *      - invalid account number in the requests;
    *      - deposit / withdrawal of a larger amount of money than is currently available.
    *
    * For the given list of accounts and requests, return the state of accounts after all requests have been processed, or an array of a single element [-<request_id>]
    * (please note the minus sign), where <request_id> is the 1-based index of the first invalid request.
    *
    * Example
    *  For accounts = [10, 100, 20, 50, 30] and requests = ["withdraw 2 10", "transfer 5 1 20", "deposit 5 20", "transfer 3 4 15"],
    *  the output should be bankRequests(accounts, requests) = [30, 90, 5, 65, 30].
    *
    *  Here are the states of accounts after each request:
    *      "withdraw 2 10": [10, 90, 20, 50, 30];
    *      "transfer 5 1 20": [30, 90, 20, 50, 10];
    *      "deposit 5 20": [30, 90, 20, 50, 30];
    *      "transfer 3 4 15": [30, 90, 5, 65, 30], which is the answer.
    *
    *  For accounts = [20, 1000, 500, 40, 90] and requests = ["deposit 3 400", "transfer 1 2 30", "withdraw 4 50"],
    *  the output should be bankRequests(accounts, requests) = [-2].
    *
    *  After the first request, accounts becomes equal to [20, 1000, 900, 40, 90], but the second one turns it into [-10, 1030, 900, 40, 90], which is invalid.
    *  Thus, the second request is invalid, and the answer is [-2]. Note that the last request is also invalid, but it shouldn't be included in the answer.
    */
    public class BankRequestProcessor
    {
        public int[] Execute(int[] accounts, string[] requests)
        {
            int[] accountsTemp = new List<int>(accounts).ToArray();

            for (int requestIdx = 0; requestIdx < requests.Length; requestIdx++)
            {
                string req = requests[requestIdx];

                string[] split = req.Split(' ');
                string commandName = split[0];
                int[] parameters = split.Skip(1).Select(int.Parse).ToArray();
                bool validRequest = true;

                switch (commandName)
                {
                    case "withdraw":
                        validRequest = WithdrawFromAccount(accountsTemp, parameters);
                        break;

                    case "deposit":
                        validRequest = DepositToAccount(accountsTemp, parameters);
                        break;

                    case "transfer":
                        validRequest = TransferFromAccountToAccount(accountsTemp, parameters);
                        break;

                    default: throw new NotSupportedException("command not supported");
                }

                if(!validRequest)
                    return new int[] { (requestIdx + 1) * (- 1)};
            }

            return accountsTemp;
        }


        private bool WithdrawFromAccount(int[] accounts, int[] parameters)
        {
            if (parameters.Length != 2) throw new InvalidOperationException();

            int accountToWithdraw = parameters[0] - 1;
            int amount = parameters[1];

            if (accounts[accountToWithdraw] - amount < 0) return false;
            accounts[accountToWithdraw] -= amount;
            return true;
        }

        private bool DepositToAccount(int[] accounts, int[] parameters)
        {
            if (parameters.Length != 2) throw new InvalidOperationException();

            int accountToDeposit = parameters[0] - 1;
            int amount = parameters[1];

            if (accounts[accountToDeposit] + amount > int.MaxValue) return false;
            accounts[accountToDeposit] += amount;
            return true;
        }

        private bool TransferFromAccountToAccount(int[] accounts, int[] parameters)
        {
            if (parameters.Length != 3) throw new InvalidOperationException();

            int accountToWithdraw = parameters[0] - 1;
            int accountToDeposit = parameters[1] - 1;
            int amount = parameters[2];

            if (accounts[accountToWithdraw] - amount < 0) return false;
            if (accounts[accountToDeposit] + amount > int.MaxValue) return false;

            accounts[accountToWithdraw] -= amount;
            accounts[accountToDeposit] += amount;
            return true;
        }
    }
}
