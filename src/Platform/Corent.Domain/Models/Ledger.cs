namespace Corent.Domain.Models
{
    /// <summary>
    /// The total collection of <see cref="Transaction"/> <see cref="Block">Blocks</see>.
    /// </summary>
    public class Ledger
    {
        /// <summary>
        /// The latest <see cref="Block"/> in the chain.
        /// </summary>
        public Block? LatestBlock { get; set; }

        public override string ToString()
        {
            var transactionsDisplay = new Dictionary<string, string>
            {
                ["Sender"] = string.Join("\n", LatestBlock.Transactions.Select(x => x.Sender.Address.ToString())),
                ["Recipient"] = string.Join("\n", LatestBlock.Transactions.Select(x => x.Recipient.Address.ToString())),
                ["Amount"] = string.Join("\n", LatestBlock.Transactions.Select(x => x.Amount.ToString())),
                ["Created"] = string.Join("\n", LatestBlock.Transactions.Select(x => x.CreatedTime.ToString())),
                ["Fulfilled"] = string.Join("\n", LatestBlock.Transactions.Select(x => x.FulfilledTime.ToString())),
            };
            return $"\nLatest Block\n============\n\nHash:\t\t{string.Join("", LatestBlock.Hash.Select(x => x.ToString()))}\n\nTransactions:\t{LatestBlock.Transactions.Count}\n{string.Join("\t\t", transactionsDisplay.Keys)}{string.Join("\n", transactionsDisplay.Values)}";
        }
    }
}
