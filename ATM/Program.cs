using ATM.BAL;
using ATM.Helper;
using System;

namespace ATM
{
    class Program
    {
        static AccountBAL accountBAL = new AccountBAL();
        public static void Main(string[] args)
        {
            Console.Title = "ATM Machine";
            ShowAtmOption();

        }

        private static void ShowAtmOption()
        {
            #region Card Number

            Console.WriteLine("Enter your ATM Card Number: ");
            string cardNumber = "";
            bool isValidCardNumber = false;
            do
            {
                cardNumber = Console.ReadLine();
                isValidCardNumber = accountBAL.ValidateCardNumber(cardNumber);
                if (!isValidCardNumber)
                {
                    Console.WriteLine("Invalid ATM card Number");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Enter your ATM Card Number:");
                }
            } while (!isValidCardNumber);

            #endregion

            #region Validate PIN

            Console.WriteLine("Enter your ATM Pin: ");
            int atmPIN = 0;
            bool isValidPIN = false;
            atmPIN = InputHelper.GetNumberInputWithSecureString();
            AccountBAL transactionBAL = new AccountBAL();
            isValidPIN = transactionBAL.ValidatePIN(cardNumber, atmPIN);
            if (!isValidPIN)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Invalid PIN");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Console.Clear();
                ShowAtmOption();
            }

            #endregion

            ShowOption();

            int inputOption = 0;

            #region Option
            do
            {
                var key = Console.ReadLine();
                if (!int.TryParse(key, out inputOption))
                {
                    Console.WriteLine("Invalid option");
                    Console.WriteLine("Please enter option again");
                }
                if (inputOption > 4)
                {
                    Console.WriteLine("Invalid option");
                    Console.WriteLine("Please enter option again");
                }
            }
            while (inputOption == 0 || inputOption > 4);
            #endregion

            Console.Clear();
            switch (inputOption)
            {
                case 1:
                    Console.WriteLine("************* ACCOUNT BALANCE *************");
                    float balance = accountBAL.GetAccountBalance(cardNumber);
                    Console.WriteLine("Your account balance = {0} ", balance);
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                    ShowAtmOption();
                    break;
                case 2:
                    Console.WriteLine("***************  WITHDRAW  ****************");
                    Console.WriteLine("Amount: ");
                    var amount = InputHelper.GetFloatNumber();
                    // we can put validation for minimum and maxium amout that user can withdraw at one time
                    Console.WriteLine("");
                    float accountBalanace = 0;
                    string message = accountBAL.WithDrawalAmount(cardNumber, amount, out accountBalanace);

                    if (!string.IsNullOrEmpty(message))
                        Console.WriteLine(message);
                    else
                    {
                        Console.WriteLine("Successfully withdraw {0} from your account", amount);
                        Console.WriteLine("\nYour remaining balance is: " + accountBalanace);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                    ShowAtmOption();
                    break;
                case 3:
                    int firstPin = 0, secondPin = 0;
                    Console.WriteLine("*************** CHANGE PIN ****************");
                    Console.WriteLine("Enter new PIN : ");
                    firstPin = InputHelper.GetNumberInputWithSecureString();
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Re-enter same password: ");
                    secondPin = InputHelper.GetNumberInputWithSecureString();
                    if (firstPin != secondPin)
                    {
                        Console.WriteLine("Pin doesn't match. Kindly enter pin again ");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        Console.Clear();
                        ShowAtmOption();

                    }
                    accountBAL.ChangePIN(cardNumber, firstPin);
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("PIN was successfully changed!");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                    ShowAtmOption();
                    break;
                case 4:
                    Console.WriteLine("\nTHANKS FOR USING OUR ATM SERVICE");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n\nInvalid Button");
                    Environment.Exit(0);
                    break;
            }
        }

        private static void ShowOption()
        {
            Console.WriteLine("\n\n#########Select ATM Service##########\n");
            Console.WriteLine("1. Balance Enquiry\n");
            Console.WriteLine("2. Cash Withdrawal\n");
            Console.WriteLine("3. Change PIN\n");
            Console.WriteLine("4. Exit\n");
            Console.WriteLine("#####################################\n\n");
            Console.Write("Select Options: ");
        }
    }
}