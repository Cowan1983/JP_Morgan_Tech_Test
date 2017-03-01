using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Morgan_Tech_Test
{
    public class Transaction
    {
        //The financial entity whose shares are to be bought or sold
        public string Entity { get; }
        //The date the transaction will be scheduled for. Adjusted to fall on a working day.
        public DateTime ActualSettlementDate { get; }
        //The total value (in USD) of the transaction
        public double TransactionValue { get; }
        //The transaction type. B = Buy, S = Sell
        public string TransactionType { get; }
        //The agreed exchange rate for foreign currency transactions
        public double AgreedFx { get; }
        //The currency being used for the transaction
        public string Currency { get; }
        //The date the transaction instruction was recieved
        public DateTime InstructionDate { get; }
        //The date the transaction instruction was requested to be actioned
        //We will keep this separate from the ActualSettlementDate for auditing purposes.
        public DateTime RequestedSettlementDate { get; }
        //The number of Units to be bought or sold
        public int Units { get; }
        //The price for each of the Units
        public double PricePerUnit { get; }

        ///Private default constructor as we have no use for an unpopulated Transcation class
        private Transaction()
        {

        }

        /// <summary>
        /// The only visible Transaction constructor
        /// </summary>
        /// <param name="myEntity">The financial entity whose shares are to be bought or sold</param>
        /// <param name="myTransactionType">The Buy/Sell flag. B = Buy. S = Sell</param>
        /// <param name="myAggreedFx">The foreign exchange rate with respect to USD that has been agreed</param>
        /// <param name="myCurrency">The three letter acronym for the currency being used</param>
        /// <param name="myInstructionDate">The date the instruction was made</param>
        /// <param name="myRequestedSettlementDate">The date on which the client wished for the instruction to be settled with respect to the instruction date/param>
        /// <param name="myUnits">The number of shares to be bought or sold</param>
        /// <param name="myPricePerUnit"></param>
        public Transaction(string myEntity, string myTransactionType, double myAggreedFx, string myCurrency,
            DateTime myInstructionDate, DateTime myRequestedSettlementDate, int myUnits, double myPricePerUnit)
        {
            //Most values can be written straight to member variables
            Entity = myEntity;
            TransactionType = myTransactionType;
            AgreedFx = myAggreedFx;
            Currency = myCurrency;
            InstructionDate = myInstructionDate;
            RequestedSettlementDate = myRequestedSettlementDate;
            Units = myUnits;
            PricePerUnit = myPricePerUnit;

            //Two values need some processing.

            //The first one is the value of the transaction.
            //We could do this by putting the calulation into the Accessor for TransactionValue,
            //but that would mean it is done every time we ask for the value.
            TransactionValue = PricePerUnit * Units * AgreedFx;

            //Finally we need to process the RequestedSettlementDate and adjust it if it falls on a non-working day.
            ActualSettlementDate = Utilities.GetUtilities().AdjustDateToWorkingWeek(RequestedSettlementDate, Currency.ToUpper());

        }

        //We have now created the Transaction class constructor we will be using.
    }
}

