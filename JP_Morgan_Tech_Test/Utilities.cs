using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Morgan_Tech_Test
{
    /// <summary>
    /// The Utilities class will be a Singleton
    /// </summary>
    public class Utilities
    {
        //Declare the SINGLE class instance that will be returned
        //when asked for
        private static Utilities singleClassInstance;

        //Lock synchronization object
        private static object syncLock = new object();

        /// <summary>
        /// Static class method used to either create the
        /// first (and only) instance of this class, or
        /// return the single instance of the class
        /// </summary>
        /// <returns>The single instance of the class</returns>
        public static Utilities GetUtilities()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked

            //Check if we have already created the single
            //instance of this class
            if (singleClassInstance == null)
            {
                //"lock" lock ensures that one thread does not 
                //enter a critical section of code while another 
                //thread is in the critical section. If another 
                //thread attempts to enter a locked code, it will 
                //wait, block, until the object is released.
                lock (syncLock)
                {
                    //Check again if we have already created 
                    //the single instance of this class
                    if (singleClassInstance == null)
                    {
                        singleClassInstance = new Utilities();
                    }
                }
            }

            //Send back the SINGLE instance of this class
            return singleClassInstance;
        }

        /// <summary>
        /// Load all the transactions to be processed/actioned
        /// </summary>
        /// <returns>A List<Transaction></returns>
        public List<Transaction> LoadTransactions()
        {
            //Declare the list we will be putting the loaded transactions into
            List<Transaction> allLoadedTransactions = new List<Transaction>();

            //HERE IS WHERE YOU WOULD PUT THE CODE TO EXTRACT THE TRANSACTION DATA AND
            //CREATE EACH INSTANCE OF THE Transaction CLASS.
            #region TestData
            //AS THE TEST STATES THIS IS NOT FROM A DATABASE OR FILE ON DISC, 
            //IT WILL BE A HARD WIRED METHOD.
            allLoadedTransactions.Add(new Transaction("Foo",         "B",   0.50,    "SGP", DateTime.Parse("01 Jan 2016"), DateTime.Parse("02 Jan 2016"), 200, 100.25));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "B" ,  0.70,    "GBP", DateTime.Parse("02 Jan 2016"), DateTime.Parse("02 Jan 2016"), 160, 95.5)); 
            allLoadedTransactions.Add(new Transaction("Bar",         "S",   0.22,    "AED", DateTime.Parse("05 Jan 2016"), DateTime.Parse("07 Jan 2016"), 450, 150.5));
            allLoadedTransactions.Add(new Transaction("Mega Inc",    "S",   0.63,    "SAR", DateTime.Parse("07 Jan 2016"), DateTime.Parse("09 Jan 2016"), 300, 137));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "B",   1.00,    "USD", DateTime.Parse("03 Jan 2016"), DateTime.Parse("04 Jan 2016"), 45,  24.6));
            allLoadedTransactions.Add(new Transaction("Aggricorp",   "S",   0.34,    "JPY", DateTime.Parse("04 Jan 2016"), DateTime.Parse("06 Jan 2016"), 500, 124));
            allLoadedTransactions.Add(new Transaction("Bar",         "S",   0.86,    "AUD", DateTime.Parse("09 Jan 2016"), DateTime.Parse("12 Jan 2016"), 225, 147.75));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "S",   1.00,    "USD", DateTime.Parse("01 Jan 2016"), DateTime.Parse("02 Jan 2016"), 50,  87.6));
            allLoadedTransactions.Add(new Transaction("Foo",         "B",   0.73,    "GBP", DateTime.Parse("02 Jan 2016"), DateTime.Parse("02 Jan 2016"), 300, 99.00));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "B",   0.25,    "AED", DateTime.Parse("09 Jan 2016"), DateTime.Parse("12 Jan 2016"), 200, 26.25));
            allLoadedTransactions.Add(new Transaction("Bar",         "B",   0.33,    "JPY", DateTime.Parse("07 Jan 2016"), DateTime.Parse("09 Jan 2016"), 300, 154.75));
            allLoadedTransactions.Add(new Transaction("Aggricorp",   "S",   0.88,    "AUD", DateTime.Parse("13 Jan 2016"), DateTime.Parse("13 Jan 2016"), 200, 118.5));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "S",   0.66,    "SAR", DateTime.Parse("07 Jan 2016"), DateTime.Parse("11 Jan 2016"), 400, 91.00));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "S",   0.73,    "GBP", DateTime.Parse("01 Jan 2016"), DateTime.Parse("09 Jan 2016"), 600, 24.90));
            allLoadedTransactions.Add(new Transaction("Mega Inc",    "B",   0.48,    "SGP", DateTime.Parse("10 Jan 2016"), DateTime.Parse("12 Jan 2016"), 450, 142.00));
            allLoadedTransactions.Add(new Transaction("Aggricorp",   "S",   1.00,    "USD", DateTime.Parse("12 Jan 2016"), DateTime.Parse("13 Jan 2016"), 350, 128));
            allLoadedTransactions.Add(new Transaction("Bar",         "S",   0.21,    "AED", DateTime.Parse("11 Jan 2016"), DateTime.Parse("11 Jan 2016"), 120, 148));
            allLoadedTransactions.Add(new Transaction("Foo",         "B",   0.68,    "GBP", DateTime.Parse("01 Jan 2016"), DateTime.Parse("04 Jan 2016"), 475, 98.5));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "S",   0.48,    "SGP", DateTime.Parse("05 Jan 2016"), DateTime.Parse("06 Jan 2016"), 750, 25.25));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "B",   0.60,    "SAR", DateTime.Parse("09 Jan 2016"), DateTime.Parse("09 Jan 2016"), 100, 94.25));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "B",   1.00,    "USD", DateTime.Parse("03 Jan 2016"), DateTime.Parse("04 Jan 2016"), 625, 24.75));
            allLoadedTransactions.Add(new Transaction("Bar",         "B",   0.33,    "JPY", DateTime.Parse("13 Jan 2016"), DateTime.Parse("13 Jan 2016"), 400, 152));
            allLoadedTransactions.Add(new Transaction("Mega Inc",    "S",   1.00,    "USD", DateTime.Parse("08 Jan 2016"), DateTime.Parse("09 Jan 2016"), 25,  140.5));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "S",   0.84,    "AUD", DateTime.Parse("11 Jan 2016"), DateTime.Parse("12 Jan 2016"), 950, 96));
            allLoadedTransactions.Add(new Transaction("Aggricorp",   "B",   0.24,    "AED", DateTime.Parse("05 Jan 2016"), DateTime.Parse("09 Jan 2016"), 125, 134));
            allLoadedTransactions.Add(new Transaction("Bar",         "S",   0.72,    "GBP", DateTime.Parse("10 Jan 2016"), DateTime.Parse("11 Jan 2016"), 500, 150.25));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "B",   0.88,    "AUD", DateTime.Parse("12 Jan 2016"), DateTime.Parse("13 Jan 2016"), 350, 93.75));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "B",   1.00,    "USD", DateTime.Parse("01 Jan 2016"), DateTime.Parse("04 Jan 2016"), 475, 26));
            allLoadedTransactions.Add(new Transaction("Foo",         "S",   0.62,    "SAR", DateTime.Parse("07 Jan 2016"), DateTime.Parse("07 Jan 2016"), 775, 101.75));
            allLoadedTransactions.Add(new Transaction("Mega Inc",    "B",   0.35,    "JPY", DateTime.Parse("11 Jan 2016"), DateTime.Parse("11 Jan 2016"), 400, 139.25));
            allLoadedTransactions.Add(new Transaction("Bar",         "S",   0.70,    "GBP", DateTime.Parse("01 Jan 2016"), DateTime.Parse("02 Jan 2016"), 850, 149.75));
            allLoadedTransactions.Add(new Transaction("Tech Core",   "B",   0.50,    "SGP", DateTime.Parse("06 Jan 2016"), DateTime.Parse("06 Jan 2016"), 275, 135.75));
            allLoadedTransactions.Add(new Transaction("Aggricorp",   "S",   1.00,    "USD", DateTime.Parse("06 Jan 2016"), DateTime.Parse("09 Jan 2016"), 900, 125.75));
            allLoadedTransactions.Add(new Transaction("Mega Inc",    "S",   1.00,    "USD", DateTime.Parse("12 Jan 2016"), DateTime.Parse("13 Jan 2016"), 825, 132.25));
            allLoadedTransactions.Add(new Transaction("Foo",         "S",   0.30,    "JPY", DateTime.Parse("01 Jan 2016"), DateTime.Parse("02 Jan 2016"), 100, 100));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "B",   0.69,    "GBP", DateTime.Parse("12 Jan 2016"), DateTime.Parse("12 Jan 2016"), 725, 25.75));
            allLoadedTransactions.Add(new Transaction("Bar",         "B",   0.59,    "SAR", DateTime.Parse("02 Jan 2016"), DateTime.Parse("04 Jan 2016"), 50,  151.5));
            allLoadedTransactions.Add(new Transaction("Mega Inc",    "B",   0.85,    "AUD", DateTime.Parse("11 Jan 2016"), DateTime.Parse("11 Jan 2016"), 650, 138.5));
            allLoadedTransactions.Add(new Transaction("Global PLC",  "S",   1.00,    "USD", DateTime.Parse("07 Jan 2016"), DateTime.Parse("07 Jan 2016"), 400, 25.5));
            allLoadedTransactions.Add(new Transaction("Foo",         "B",   0.22,    "AED", DateTime.Parse("03 Jan 2016"), DateTime.Parse("09 Jan 2016"), 375, 99.25));
            #endregion
            //NOTE: IT IS THE RESPONSIBLITY OF THIS FUNCTION TO VALIDATE AND CONVERT VALUES USED. THE CLASS IS STRONGLY TYPED, SO UNLIKELY TO HAVE INVALID OR UNUSABLE VALUES

            //END OF CODE TO CREATE THE LIST OF TRANSACTIONS

            //Return the created list of transactions
            return allLoadedTransactions;

        }

        /// <summary>
        /// Adjust a supplied date to fall on a working day, based on the currency
        /// </summary>
        /// <param name="myDate">The date to be tested and adjusted</param>
        /// <param name="myRegionalCurrency">The currency acronym</param>
        /// <returns>Date adjusted to fall on a working day</returns>
        public DateTime AdjustDateToWorkingWeek(DateTime myDate, string myRegionalCurrency)
        {
            //Declare the value to be passed back by the function.
            DateTime adjustedDate;

            //The first thing to consider is the currency for the transaction.
            //If it is AED (United Arab Emirates Dirham) or SAR (Saudi Arabia Riyal), the working week is Sunday to Thursday.
            if ((myRegionalCurrency.ToUpper() == "AED") || (myRegionalCurrency.ToUpper() == "SAR"))
            {
                //Get the day of the week.
                switch (myDate.DayOfWeek)
                {
                    //If it is Friday, add to two days to get Sunday
                    case DayOfWeek.Friday:
                        adjustedDate = myDate.AddDays(2);
                        break;

                    //If it is Saturday, add a day to get Sunday
                    case DayOfWeek.Saturday:
                        adjustedDate = myDate.AddDays(1);
                        break;

                    //The actual settlement date is the same as the requested settlement date
                    default:
                        adjustedDate = myDate;
                        break;
                }

            }
            else
            //For any other currency, the working week is Monday to Friday.
            {
                //Get the day of the week.
                switch (myDate.DayOfWeek)
                {
                    //If it is Saturday, add to two days to get Monday
                    case DayOfWeek.Saturday:
                        adjustedDate = myDate.AddDays(2);
                        break;

                    //If it is Sunday, add a day to get Monday
                    case DayOfWeek.Sunday:
                        adjustedDate = myDate.AddDays(1);
                        break;

                    //The actual settlement date is the same as the requested settlement date
                    default:
                        adjustedDate = myDate;
                        break;
                }
            }

            //Send back the working week adjusted date.
            return adjustedDate;
        }
    }
}
