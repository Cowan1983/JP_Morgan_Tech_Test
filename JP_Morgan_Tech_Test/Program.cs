using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Morgan_Tech_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask the (singleton) Utility class to load up a list<> of transactions
            List<Transaction> myTransactions = Utilities.GetUtilities().LoadTransactions();            

            //Send this list to the function that will output the transactions.
            GenerateReport(myTransactions);
        }

        /// <summary>
        /// Format and output the report to the console
        /// </summary>
        /// <param name="myTransactionList">An unordered list transactions</param>
        private static void GenerateReport(List<Transaction> myTransactionList)
        {
            //Now to order the list
            //First by the date of settlement, then by transaction type and finally by value
            List<Transaction> orderedTransactions = myTransactionList.OrderBy(y => y.ActualSettlementDate).ThenByDescending(y => y.TransactionType).ThenByDescending(y => y.TransactionValue).ToList();

            //Next we want to set up and initialise a few variables we will be using in the report

            //The ranking of a transaction value (highest value to lowest)
            int ranking = 1;

            //The total value of outgoing and incomming transactions for a date
            double settlementValue = 0;

            //Initialise the two flags which will indicate transitions between days and transaction types.
            DateTime currentDate = orderedTransactions[0].ActualSettlementDate;
            string currentType = orderedTransactions[0].TransactionType;

            //Format a header line
            Console.WriteLine("{0, -6}{1, -15}{2, -12}{3, -9}{4, -10}", "Rank", "Entity", "Date", "Type", "Value($)");
            Console.WriteLine("");

            //Iterate through the list of transactions
            foreach (Transaction thisTransaction in orderedTransactions)
            {
                //See if we are transitioning from one date or transaction type to another
                if ((thisTransaction.TransactionType != currentType) || thisTransaction.ActualSettlementDate != currentDate)
                {
                    Console.WriteLine("");
                    //Format and write the line for the total value of the transcations for this date and transaction type
                    Console.WriteLine("{0, 40}{1, 10}", "Total " + (currentType == "B" ? "Outgoing " : "Incomming "), settlementValue.ToString("0.00"));
                    Console.WriteLine("");
                    Console.WriteLine("");

                    //Reset the values for the next set of date and transaction type
                    settlementValue = 0;
                    currentType = thisTransaction.TransactionType;
                    currentDate = thisTransaction.ActualSettlementDate;
                    ranking = 1;
                }

                //Output the actual transaction values                
                Console.WriteLine("{0, -6}{1, -15}{2, -12}{3, -7}{4, 10}", ranking.ToString().PadLeft(2), thisTransaction.Entity, thisTransaction.ActualSettlementDate.ToShortDateString(), thisTransaction.TransactionType, thisTransaction.TransactionValue.ToString("0.00"));

                //Add the transaction value to the running total for the date and transaction gorping
                settlementValue += thisTransaction.TransactionValue;
                //Add one to the ranking for the transaction.
                ranking++;
            }

            Console.WriteLine("");
            //Add in the final line (which will be the final total for the last set of Incomming or Outgoing transactions)
            Console.WriteLine("{0, 40}{1, 10}", "Total " + (currentType == "B" ? "Outgoing " : "Incomming "), settlementValue.ToString("0.00"));
            Console.WriteLine("");
            Console.WriteLine("");
            //Let the user know the report is complete.
            Console.WriteLine("REPORT COMPLETE");

            //Pause to let people read the report.
            Console.ReadLine();

        }
    }
}
