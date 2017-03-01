using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JP_Morgan_Tech_Test;


namespace JP_Morgan_Tech_Test_Unit_Tests
{
    [TestClass]
    public class JP_Morgan_Unit_Tests
    {
        [TestMethod]
        //This test will check the Utilities "AdjustDateToWorkingWeek" function.
        public void TestUtilitiesAdjustDateToWokingWeekFunction()
        {
            //This function takes a date and a three letter currency acronym.
            //If the supplied date falls on a non-working day, the function will
            //return the date for the next working day.
            //Currently, "AED" and "SAR" have a working week of Sunday to Thursday, and
            //all others have a working week of Monday to Friday.

            //First test will be with Tuesday 1st March 2016
            //This date should not be ajusted for any currency
            DateTime testDate = DateTime.Parse("01 Mar 2016");

            //Test the currency USD does not change the date
            DateTime adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "USD");
            Assert.AreEqual(testDate, adjustedDate);

            //Test the currency AED does not change the date
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "AED");
            Assert.AreEqual(testDate, adjustedDate);

            //Move date to Friday 4th March 2016
            testDate = DateTime.Parse("04 Mar 2016");

            //Test the currency USD does not change the date
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "USD");
            Assert.AreEqual(testDate, adjustedDate);

            //Test the currency AED changes the date to Sunday 6th March 2016
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "AED");
            Assert.AreEqual(testDate.AddDays(2), adjustedDate);

            //Move date to Saturday 5th March 2016
            testDate = DateTime.Parse("05 Mar 2016");

            //Test the currency USD changes the date to Monday 7th March 2016
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "USD");
            Assert.AreEqual(testDate.AddDays(2), adjustedDate);

            //Test the currency AED changes the date to Sunday 6th March 2016
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "AED");
            Assert.AreEqual(testDate.AddDays(1), adjustedDate);

            //Move date to Sunday 6th March 2016
            testDate = DateTime.Parse("06 Mar 2016");

            //Test the currency USD changes the date to Monday 7th March 2016
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "USD");
            Assert.AreEqual(testDate.AddDays(1), adjustedDate);

            //Test the currency AED does not change the date
            adjustedDate = JP_Morgan_Tech_Test.Utilities.GetUtilities().AdjustDateToWorkingWeek(testDate, "AED");
            Assert.AreEqual(testDate, adjustedDate);

        }



        [TestMethod]
        //This test will check that the class constructor and class accessors are working
        public void TestTransactionClassConstructor()
        {
            //Declare the values we will be passing to the constructor
            string entityName = "Foo";
            string transactionType = "B";
            double transactionAgreedFx = 0.5;
            string transactionCurrency = "SGP";
            DateTime transactionInstructionDate = DateTime.Parse("01 Jan 2016");
            DateTime transactionRequestedSettlementDate = DateTime.Parse("02 Jan 2016");
            int transactionUnits = 200;
            double transactionUnitPrice = 100.25;

            JP_Morgan_Tech_Test.Transaction testTransactionInstance = new Transaction(entityName, transactionType, transactionAgreedFx, transactionCurrency, transactionInstructionDate, transactionRequestedSettlementDate, transactionUnits, transactionUnitPrice);

            //Now to assert the values we used are what the instance contains.
            Assert.AreEqual(entityName, testTransactionInstance.Entity);
            Assert.AreEqual(transactionType, testTransactionInstance.TransactionType);
            Assert.AreEqual(transactionAgreedFx, testTransactionInstance.AgreedFx);
            Assert.AreEqual(transactionCurrency, testTransactionInstance.Currency);
            Assert.AreEqual(transactionInstructionDate, testTransactionInstance.InstructionDate);
            Assert.AreEqual(transactionRequestedSettlementDate, testTransactionInstance.RequestedSettlementDate);
            Assert.AreEqual(transactionUnits, testTransactionInstance.Units);
            Assert.AreEqual(transactionUnitPrice, testTransactionInstance.PricePerUnit);

        }

        [TestMethod]
        //This test will check that the total value (in USD) for a transaction is correctly calculated.
        public void TestTransactionValueCalculationValue()
        {
            //Declare the values we will be passing to the constructor
            string entityName = "Foo";
            string transactionType = "B";
            double transactionAgreedFx = 0.5;
            string transactionCurrency = "SGP";
            DateTime transactionInstructionDate = DateTime.Parse("01 Jan 2016");
            DateTime transactionRequestedSettlementDate = DateTime.Parse("02 Jan 2016");
            int transactionUnits = 200;
            double transactionUnitPrice = 100.25;

            JP_Morgan_Tech_Test.Transaction testTransactionInstance = new Transaction(entityName, transactionType, transactionAgreedFx, transactionCurrency, transactionInstructionDate, transactionRequestedSettlementDate, transactionUnits, transactionUnitPrice);

            //Locally calculate the transaction value expected.
            //This will be AgreedFx x Units x Unit Price
            double expectedValue = transactionAgreedFx * transactionUnits * transactionUnitPrice;

            //Now assert the values are the same
            Assert.AreEqual(expectedValue, testTransactionInstance.TransactionValue);

        }
    }
}
